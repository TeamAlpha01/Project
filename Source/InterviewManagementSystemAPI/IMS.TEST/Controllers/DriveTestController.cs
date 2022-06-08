using System;
using System.ComponentModel.DataAnnotations;
using FluentAssertions;
using IMS.Controllers;
using IMS.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using IMS.Models;


namespace UnitTesting.Controllers;

public class DriveControllerTest
{
    private readonly DriveController _driveController;
    private readonly Mock<ILogger<DriveController>> _logger = new Mock<ILogger<DriveController>>();
    private readonly Mock<IDriveService> _driveService = new Mock<IDriveService>();
    private readonly Mock<IMailService> _mailService = new Mock<IMailService>();

    public DriveControllerTest()
    {
        _driveController = new DriveController(_logger.Object, _mailService.Object, _driveService.Object);
    }

    //Create Drive

    [Theory]
    [InlineData(null)]
    public void CreateDrive_ShouldReturnStatusCode400_WhenDriveObjectIsNull(Drive drive)
    {
        var Result = _driveController.CreateDrive(drive) as ObjectResult;
        Result.StatusCode.Should().Be(400);
    }

    // [Theory]
    // [InlineData("")]
    // public void CreateDrive_ShouldReturnStatusCode200_WithProperDriveObject(Drive drive)
    // {
    //     _driveService.Setup(r => r.CreateDrive(drive)).Returns(true);

    //     var Result = _driveController.CreateDrive(drive) as ObjectResult;

    //     Result.StatusCode.Should().Be(200);
    // }

    // Cancel Drive

    [Theory]
    [InlineData(0,1,"TestReason")]
    [InlineData(1,0,"TestReason")]
    [InlineData(0,0,"TestReason")]

    public void CancelDrive_ShouldReturnStatusCode400_WhenNoProperInputs(int driveId, int tacId, string reason)
    {
        var Result = _driveController.CancelDrive(driveId,tacId,reason) as ObjectResult;
        Result.StatusCode.Should().Be(400);
    }

    // Include Mail Service for Status code 200

    // [Fact]
    // public void CancelDrive_ShouldReturnStatusCode200_WithProperInputs()
    // {
    //     int driveId = 1; 
    //     int tacId = 1; 
    //     string reason = "TestReason";

    //     _driveService.Setup(r => r.CancelDrive(driveId,tacId,reason)).Returns(true);

    //     var Result = _driveController.CancelDrive(driveId,tacId,reason) as ObjectResult;

    //     Result.StatusCode.Should().Be(200);
    // }

    [Fact]
    public void CancelDrive_ShouldReturnProblem_WithProperInputs()
    {
        int driveId = 1; 
        int tacId = 1; 
        string reason = "TestReason";

        _driveService.Setup(r => r.CancelDrive(driveId,tacId,reason)).Returns(false);

        var Result = _driveController.CancelDrive(driveId,tacId,reason) as ObjectResult;

        Result.StatusCode.Should().Be(500);
    }

    [Fact]
    public void CancelDrive_ShouldReturnBadRequest_WithImProperInputs()
    {
        int driveId = 1; 
        int tacId = 1; 
        string reason = "TestReason";

        _driveService.Setup(r => r.CancelDrive(driveId,tacId,reason)).Throws<ValidationException>();

        var Result = _driveController.CancelDrive(driveId,tacId,reason) as ObjectResult;

        Result.StatusCode.Should().Be(400);
    }

    // Add one more case for Drive cancelled but mail not triggered

    [Fact]
    public void CancelDrive_ShouldReturnStatusCode500_WithProperInputs()
    {
        int driveId = 1; 
        int tacId = 1; 
        string reason = "TestReason";

        _driveService.Setup(r => r.CancelDrive(driveId,tacId,reason)).Throws<Exception>();

        var Result = _driveController.CancelDrive(driveId,tacId,reason) as ObjectResult;

        Result.StatusCode.Should().Be(500);
    }

    // View Today Drives

    [Fact]
    public void ViewTodayDrive_ShouldReturnStatusCode200()
    {
        // Arrange
        _driveService.Setup(driveService => driveService.ViewTodayDrives()).Returns(() => null);
        // Act
        var Result = _driveController.ViewTodayDrives() as ObjectResult;
        //Assert
        Assert.Equal(200, Result.StatusCode);
    }

    [Fact]
    public void ViewTdayDrive_ShouldReturnStatusCode500()
    {
        // Arrange
        _driveService.Setup(driveService => driveService.ViewTodayDrives()).Throws<Exception>();
        // Act
        var Result = _driveController.ViewTodayDrives() as ObjectResult;
        //Assert
        Assert.Equal(500, Result.StatusCode);
    }

    // View Scheduled Drive

    [Fact]
    public void ViewScheduledDrive_ShouldReturnStatusCode200()
    {
        // Arrange
        _driveService.Setup(driveService => driveService.ViewScheduledDrives()).Returns(() => null);
        // Act
        var Result = _driveController.ViewScheduledDrives() as ObjectResult;
        //Assert
        Assert.Equal(200, Result.StatusCode);
    }

    [Fact]
    public void ViewScheduledDrive_ShouldReturnStatusCode500()
    {
        // Arrange
        _driveService.Setup(driveService => driveService.ViewScheduledDrives()).Throws<Exception>();
        // Act
        var Result = _driveController.ViewScheduledDrives() as ObjectResult;
        //Assert
        Assert.Equal(500, Result.StatusCode);
    }

    // View Upcoming Drives

    [Fact]
    public void ViewUpcomingDrive_ShouldReturnStatusCode200()
    {
        // Arrange
        _driveService.Setup(driveService => driveService.ViewUpcommingDrives()).Returns(() => null);
        // Act
        var Result = _driveController.ViewScheduledDrives() as ObjectResult;
        //Assert
        Assert.Equal(200, Result.StatusCode);
    }

    [Fact]
    public void ViewUpcomingDrive_ShouldReturnStatusCode500()
    {
        // Arrange
        _driveService.Setup(driveService => driveService.ViewUpcommingDrives()).Throws<Exception>();
        // Act
        var Result = _driveController.ViewUpcommingDrives() as ObjectResult;
        //Assert
        Assert.Equal(500, Result.StatusCode);
    }

    // View Non Cancelled Drives

    [Fact]
    public void ViewNonCancelledDrive_ShouldReturnStatusCode200()
    {
        // Arrange
        _driveService.Setup(driveService => driveService.ViewNonCancelledDrives()).Returns(() => null);
        // Act
        var Result = _driveController.ViewNonCancelledDrives() as ObjectResult;
        //Assert
        Assert.Equal(200, Result.StatusCode);
    }

    [Fact]
    public void ViewNonCancelledDrive_ShouldReturnStatusCode500()
    {
        // Arrange
        _driveService.Setup(driveService => driveService.ViewNonCancelledDrives()).Throws<Exception>();
        // Act
        var Result = _driveController.ViewNonCancelledDrives() as ObjectResult;
        //Assert
        Assert.Equal(500, Result.StatusCode);
    }

    // All Cancelled Drives

    [Fact]
    public void ViewAllCancelledDrive_ShouldReturnStatusCode200()
    {
        // Arrange
        _driveService.Setup(driveService => driveService.ViewAllCancelledDrives()).Returns(() => null);
        // Act
        var Result = _driveController.ViewAllCancelledDrives() as ObjectResult;
        //Assert
        Assert.Equal(200, Result.StatusCode);
    }

    [Fact]
    public void ViewAllCancelledDrive_ShouldReturnStatusCode500()
    {
        // Arrange
        _driveService.Setup(driveService => driveService.ViewAllCancelledDrives()).Throws<Exception>();
        // Act
        var Result = _driveController.ViewAllCancelledDrives() as ObjectResult;
        //Assert
        Assert.Equal(500, Result.StatusCode);
    }

    // View Drive

    [Theory]
    [InlineData(0)]

    public void ViewDrive_ShouldReturnStatusCode400_WhenDriveIdIsZero(int driveId)
    {
        var Result = _driveController.ViewDrive(driveId) as ObjectResult;
        Result.StatusCode.Should().Be(400);
    }

    [Fact]
    public void ViewDrive_ShouldReturnStatusCode200_WithProperDriveId()
    {
        int driveId = 1; 

        _driveService.Setup(r => r.ViewDrive(driveId)).Returns(true);

        var Result = _driveController.ViewDrive(driveId) as ObjectResult;

        Result.StatusCode.Should().Be(200);
    }

    [Fact]
    public void ViewDrive_ShouldReturn_ValidationException_WithProperDriveId()
    {
        int driveId = 1; 

        _driveService.Setup(r => r.ViewDrive(driveId)).Throws<ValidationException>();

        var Result = _driveController.ViewDrive(driveId) as ObjectResult;

        Result.StatusCode.Should().Be(400);
    }

    [Fact]
    public void ViewDrive_ShouldReturnStatusCode500_WithProperDriveId()
    {
        int driveId = 1; 

        _driveService.Setup(r => r.ViewDrive(driveId)).Throws<Exception>();

        var Result = _driveController.ViewDrive(driveId) as ObjectResult;

        Result.StatusCode.Should().Be(500);
    }

    // View Invites

    [Theory]
    [InlineData(0)]

    public void ViewInvites_ShouldReturnStatusCode400_WhenEmployeeIdIsZero(int employeeId)
    {
        var Result = _driveController.ViewInvites(employeeId) as ObjectResult;
        Result.StatusCode.Should().Be(400);
    }

    [Fact]
    public void ViewInvites_ShouldReturnStatusCode200_WithProperEmployeeId()
    {
        int employeeId = 1; 

        _driveService.Setup(r => r.ViewDriveInvites(employeeId)).Returns(true);

        var Result = _driveController.ViewInvites(employeeId) as ObjectResult;

        Result.StatusCode.Should().Be(200);
    }

    [Fact]
    public void ViewInvites_ShouldReturn_Exception_WithProperEmployeeId()
    {
        int employeeId = 1; 

        _driveService.Setup(r => r.ViewDriveInvites(employeeId)).Throws<Exception>();

        var Result = _driveController.ViewInvites(employeeId) as ObjectResult;

        Result.StatusCode.Should().Be(500);
    }

    // View Dashboard

    [Theory]
    [InlineData(0)]

    public void Viewdashboard_ShouldReturnStatusCode400_WhenTACIdIsZero(int tacId)
    {
        var Result = _driveController.ViewDashboard(tacId) as ObjectResult;
        Result.StatusCode.Should().Be(400);
    }

    [Fact]
    public void ViewDashboard_ShouldReturnStatusCode200_WithProperTACId()
    {
        int tacId = 1; 

        _driveService.Setup(r => r.ViewTACDashboard(tacId)).Returns(() => null);

        var Result = _driveController.ViewDashboard(tacId) as ObjectResult;

        Result.StatusCode.Should().Be(200);
    }

    [Fact]
    public void ViewDashboard_ShouldReturn_Exception_WithProperTACId()
    {
        int tacId = 1; 

        _driveService.Setup(r => r.ViewTACDashboard(tacId)).Throws<Exception>();

        var Result = _driveController.ViewDashboard(tacId) as ObjectResult;

        Result.StatusCode.Should().Be(500);
    }

    [Fact]
    public void ViewDashboard_ShouldReturn_ValidationException_WithProperTACId()
    {
        int tacId = 1; 

        _driveService.Setup(r => r.ViewTACDashboard(tacId)).Throws<ValidationException>();

        var Result = _driveController.ViewDashboard(tacId) as ObjectResult;

        Result.StatusCode.Should().Be(400);
    }

    // Add Response
    // Set Time Slot

    //View Todays Interview

    [Theory]
    [InlineData(0)]

    public void ViewTodayInterview_ShouldReturnStatusCode400_WhenEmployeeIdIsZero(int employeeId)
    {
        var Result = _driveController.ViewTodaysInterview(employeeId) as ObjectResult;
        Result.StatusCode.Should().Be(400);
    }

    [Fact]
    public void ViewTodayInterview_ShouldReturnStatusCode200_WithProperEmployeeId()
    {
        int employeeId = 1; 

        _driveService.Setup(r => r.ViewTodayInterviews(employeeId)).Returns(() => null);

        var Result = _driveController.ViewTodaysInterview(employeeId) as ObjectResult;

        Result.StatusCode.Should().Be(200);
    }

    [Fact]
    public void ViewTodayInterview_ShouldReturnStatusCode500_WithProperEmployeeId()
    {
        int employeeId = 1; 

        _driveService.Setup(r => r.ViewTodayInterviews(employeeId)).Throws<Exception>();

        var Result = _driveController.ViewTodaysInterview(employeeId) as ObjectResult;

        Result.StatusCode.Should().Be(500);
    }

    // View Scheduled Interviews

    [Theory]
    [InlineData(0)]

    public void ViewScheduledInterview_ShouldReturnStatusCode400_WhenEmployeeIdIsZero(int employeeId)
    {
        var Result = _driveController.ViewScheduledInterview(employeeId) as ObjectResult;
        Result.StatusCode.Should().Be(400);
    }

    [Fact]
    public void ViewScheduledInterview_ShouldReturnStatusCode200_WithProperEmployeeId()
    {
        int employeeId = 1; 

        _driveService.Setup(r => r.ViewScheduledInterview(employeeId)).Returns(() => null);

        var Result = _driveController.ViewScheduledInterview(employeeId) as ObjectResult;

        Result.StatusCode.Should().Be(200);
    }

    [Fact]
    public void ViewScheduledInterview_ShouldReturnStatusCode500_WithProperEmployeeId()
    {
        int employeeId = 1; 

        _driveService.Setup(r => r.ViewScheduledInterview(employeeId)).Throws<Exception>();

        var Result = _driveController.ViewScheduledInterview(employeeId) as ObjectResult;

        Result.StatusCode.Should().Be(500);
    }

    // View Upcoming Interview

    [Theory]
    [InlineData(0)]

    public void ViewUpcomingInterview_ShouldReturnStatusCode400_WhenEmployeeIdIsZero(int employeeId)
    {
        var Result = _driveController.ViewUpcomingInterview(employeeId) as ObjectResult;
        Result.StatusCode.Should().Be(400);
    }

    [Fact]
    public void ViewUpcomingInterview_ShouldReturnStatusCode200_WithProperEmployeeId()
    {
        int employeeId = 1; 

        _driveService.Setup(r => r.ViewUpcomingInterview(employeeId)).Returns(() => null);

        var Result = _driveController.ViewUpcomingInterview(employeeId) as ObjectResult;

        Result.StatusCode.Should().Be(200);
    }

    [Fact]
    public void ViewUpcomingInterview_ShouldReturnStatusCode500_WithProperEmployeeId()
    {
        int employeeId = 1; 

        _driveService.Setup(r => r.ViewUpcomingInterview(employeeId)).Throws<Exception>();

        var Result = _driveController.ViewUpcomingInterview(employeeId) as ObjectResult;

        Result.StatusCode.Should().Be(500);
    }

    // View All Interview

    [Theory]
    [InlineData(0)]

    public void ViewAllInterview_ShouldReturnStatusCode400_WhenEmployeeIdIsZero(int employeeId)
    {
        var Result = _driveController.ViewAllInterview(employeeId) as ObjectResult;
        Result.StatusCode.Should().Be(400);
    }

    [Fact]
    public void ViewAllInterview_ShouldReturnStatusCode200_WithProperEmployeeId()
    {
        int employeeId = 1; 

        _driveService.Setup(r => r.ViewAllInterview(employeeId)).Returns(() => null);

        var Result = _driveController.ViewAllInterview(employeeId) as ObjectResult;

        Result.StatusCode.Should().Be(200);
    }

    [Fact]
    public void ViewAllInterview_ShouldReturnStatusCode500_WithProperEmployeeId()
    {
        int employeeId = 1; 

        _driveService.Setup(r => r.ViewAllInterview(employeeId)).Throws<Exception>();

        var Result = _driveController.ViewAllInterview(employeeId) as ObjectResult;

        Result.StatusCode.Should().Be(500);
    }

    // Schedule Interview

    [Theory]
    [InlineData(0)]

    public void ScheduleInterview_ShouldReturnStatusCode400_WhenEmployeeAvailabilityIdIsZero(int employeeAvailabilityId)
    {
        var Result = _driveController.ViewAllInterview(employeeAvailabilityId) as ObjectResult;
        Result.StatusCode.Should().Be(400);
    }

    // Include Mail Service for Status code 200

    // [Fact]
    // public void ScheduleInterview_ShouldReturnStatusCode200_WithProperEmployeeAvailabilityId()
    // {
    //     int employeeAvailabilityId = 1; 

    //     _driveService.Setup(r => r.ScheduleInterview(employeeAvailabilityId)).Returns(true);

    //     var Result = _driveController.ScheduleInterview(employeeAvailabilityId) as ObjectResult;

    //     Result.StatusCode.Should().Be(200);
    // }

    [Fact]
    public void  ScheduleInterview_ShouldReturnStatusCode500_WithProperEmployeeAvailabilityId()
    {
       int employeeAvailabilityId = 1; 

       _driveService.Setup(r => r.ScheduleInterview(employeeAvailabilityId)).Returns(false);

       var Result = _driveController.ScheduleInterview(employeeAvailabilityId) as ObjectResult;

       Result.StatusCode.Should().Be(500);
    }

   [Fact]
   public void  ScheduleInterview_Should_Return_ValidationException()
    {
       int employeeAvailabilityId = 1; 

        _driveService.Setup(r => r.ScheduleInterview(employeeAvailabilityId)).Throws<ValidationException>();

        var Result = _driveController.ScheduleInterview(employeeAvailabilityId) as ObjectResult;

        Result.StatusCode.Should().Be(400);
    }

    // Add one more case for Drive cancelled but mail not triggered

   [Fact]
   public void  ScheduleInterview_ShouldReturn_Exception_WithImProperEmployeeAvailabilityID()
    {
        int employeeAvailabilityId = 1; 

        _driveService.Setup(r => r.ScheduleInterview(employeeAvailabilityId)).Throws<Exception>();

        var Result = _driveController.ScheduleInterview(employeeAvailabilityId) as ObjectResult;

        Result.StatusCode.Should().Be(500);
    }

    // Cancel Interview

    [Theory]
    [InlineData(0,"NoReason","TestReason")]
    [InlineData(0,"NoReason",null)]

    public void CancelInterview_ShouldReturnStatusCode400_WhenNoProperInputs(int employeeAvailabilityId, string Cancellationreason, string? comments)
    {
        var Result = _driveController.CancelInterview(employeeAvailabilityId,Cancellationreason,comments) as ObjectResult;
        Result.StatusCode.Should().Be(400);
    }

    // Include Mail Service for Status code 200

    // [Fact]
    // public void CancelInterview_ShouldReturnStatusCode200_WithProperInputs()
    // {
    //     int employeeAvailabilityId = 1;
    //     string Cancellationreason = "Reason"; 
    //     string? comments = null;

    //     _driveService.Setup(r => r.CancelInterview(employeeAvailabilityId,Cancellationreason,comments)).Returns(true);

    //     var Result = _driveController.CancelInterview(employeeAvailabilityId,Cancellationreason,comments) as ObjectResult;

    //     Result.StatusCode.Should().Be(200);
    // }

    [Fact]
    public void CancelInterview_ShouldReturnStatusCode500_WithProperInputs()
    {
        int employeeAvailabilityId = 1;
        string Cancellationreason = "Reason"; 
        string? comments = null;

        _driveService.Setup(r => r.CancelInterview(employeeAvailabilityId,Cancellationreason,comments)).Returns(false);

        var Result = _driveController.CancelInterview(employeeAvailabilityId,Cancellationreason,comments) as ObjectResult;

        Result.StatusCode.Should().Be(500);
    }

    [Fact]
    public void CancelInterview_ShouldReturnStatusCode400_WithProperInputs()
    {
        int employeeAvailabilityId = 1;
        string Cancellationreason = "Reason"; 
        string? comments = null;

        _driveService.Setup(r => r.CancelInterview(employeeAvailabilityId,Cancellationreason,comments)).Throws<ValidationException>();

        var Result = _driveController.CancelInterview(employeeAvailabilityId,Cancellationreason,comments) as ObjectResult;

        Result.StatusCode.Should().Be(400);
    }

     // Add one more case for Drive cancelled but mail not triggered

     [Fact]
    public void CancelInterview_ShouldThrows_Exception_WithProperInputs()
    {
        int employeeAvailabilityId = 1;
        string Cancellationreason = "Reason"; 
        string? comments = null;

        _driveService.Setup(r => r.CancelInterview(employeeAvailabilityId,Cancellationreason,comments)).Throws<Exception>();

        var Result = _driveController.CancelInterview(employeeAvailabilityId,Cancellationreason,comments) as ObjectResult;

        Result.StatusCode.Should().Be(500);
    }

    // View Available Members For Drive

    [Theory]
    [InlineData(0)]
    public void ViewAvailableMemeberForDrive_ShouldReturnStatusCode400_WhenDriveIdIsZero(int driveId)
    {
        var Result = _driveController.ViewAvailableMembersForDrive(driveId) as ObjectResult;
        Result.StatusCode.Should().Be(400);
    }

     [Fact]
    public void ViewAvailableMemeberForDrive_ShouldReturnStatusCode200_WhenProperDriveId()
    {
        int driveId = 1; 

        _driveService.Setup(r => r.ViewAvailableMembersForDrive(driveId)).Returns(true);

        var Result = _driveController.ViewAvailableMembersForDrive(driveId) as ObjectResult;

        Result.StatusCode.Should().Be(200);
    }

     [Fact]
   public void  ViewAvailableMemeberForDrive_ShouldReturnStatusCode400_WhenProperDriveId()
    {
       int driveId = 1; 

        _driveService.Setup(r => r.ViewAvailableMembersForDrive(driveId)).Throws<ValidationException>();

        var Result = _driveController.ViewAvailableMembersForDrive(driveId) as ObjectResult;

        Result.StatusCode.Should().Be(400);
    }

   [Fact]
   public void  ViewAvailableMemeberForDrive_ShouldReturnStatusCode500_WhenProperDriveId()
    {
        int driveId = 1; 

        _driveService.Setup(r => r.ViewAvailableMembersForDrive(driveId)).Throws<Exception>();

        var Result = _driveController.ViewAvailableMembersForDrive(driveId) as ObjectResult;

        Result.StatusCode.Should().Be(500);
    }

    // View Employee Dashboard

    [Theory]
    [InlineData(0)]
    public void ViewEmployeeDashboard_ShouldReturnStatusCode400_WhenEmployeeIdIsZero(int employeeId)
    {
        var Result = _driveController.ViewEmployeeDashboard(employeeId) as ObjectResult;
        Result.StatusCode.Should().Be(400);
    }

     [Fact]
    public void ViewEmployeeDashboard_ShouldReturnStatusCode200_WhenProperEmployeeId()
    {
        int employeeId = 1; 

        _driveService.Setup(r => r.ViewEmployeeDashboard(employeeId)).Returns(() => null);

        var Result = _driveController.ViewEmployeeDashboard(employeeId) as ObjectResult;

        Result.StatusCode.Should().Be(200);
    }

     [Fact]
   public void  VViewEmployeeDashboard_ShouldReturnStatusCode400_WhenProperEmployeeId()
    {
       int employeeId = 1; 

        _driveService.Setup(r => r.ViewEmployeeDashboard(employeeId)).Throws<ValidationException>();

        var Result = _driveController.ViewEmployeeDashboard(employeeId) as ObjectResult;

        Result.StatusCode.Should().Be(400);
    }

   [Fact]
   public void  ViewEmployeeDashboard_ShouldReturnStatusCode500_WhenProperEmployeeId()
    {
        int employeeId = 1; 

        _driveService.Setup(r => r.ViewEmployeeDashboard(employeeId)).Throws<Exception>();

        var Result = _driveController.ViewEmployeeDashboard(employeeId) as ObjectResult;

        Result.StatusCode.Should().Be(500);
    }

    // View Total Drive

    [Theory]
    [InlineData(0)]
    public void ViewTotalDrives_ShouldReturnStatusCode400_WhenEmployeeIdIsZero(int employeeId)
    {
        var Result = _driveController.ViewToatlDrives(employeeId) as ObjectResult;
        Result.StatusCode.Should().Be(400);
    }

    [Fact]
    public void ViewTotalDrives_ShouldReturnStatusCode200_WhenProperEmployeeId()
    {
        int employeeId = 1; 

        _driveService.Setup(r => r.ViewTotalDrives(employeeId)).Returns(() => null);

        var Result = _driveController.ViewToatlDrives(employeeId) as ObjectResult;

        Result.StatusCode.Should().Be(200);
    }

   [Fact]
   public void  ViewTotalDrives_ShouldReturnStatusCode500_WhenProperEmployeeId()
    {
        int employeeId = 1; 

        _driveService.Setup(r => r.ViewTotalDrives(employeeId)).Throws<Exception>();

        var Result = _driveController.ViewToatlDrives(employeeId) as ObjectResult;

        Result.StatusCode.Should().Be(500);
    }

    // Accepted Drives

    [Theory]
    [InlineData(0)]
    public void ViewAcceptedDrives_ShouldReturnStatusCode400_WhenEmployeeIdIsZero(int employeeId)
    {
        var Result = _driveController.ViewAcceptedDrives(employeeId) as ObjectResult;
        Result.StatusCode.Should().Be(400);
    }

    [Fact]
    public void ViewAcceptedDrives_ShouldReturnStatusCode200_WhenProperEmployeeId()
    {
        int employeeId = 1; 

        _driveService.Setup(r => r.ViewAcceptedDrives(employeeId)).Returns(() => null);

        var Result = _driveController.ViewAcceptedDrives(employeeId) as ObjectResult;

        Result.StatusCode.Should().Be(200);
    }

   [Fact]
   public void  ViewAcceptedDrives_ShouldReturnStatusCode500_WhenProperEmployeeId()
    {
        int employeeId = 1; 

        _driveService.Setup(r => r.ViewAcceptedDrives(employeeId)).Throws<Exception>();

        var Result = _driveController.ViewAcceptedDrives(employeeId) as ObjectResult;

        Result.StatusCode.Should().Be(500);
    }

    //Denied Drives

    [Theory]
    [InlineData(0)]
    public void ViewDeniedDrives_ShouldReturnStatusCode400_WhenEmployeeIdIsZero(int employeeId)
    {
        var Result = _driveController.ViewDeniedDrives(employeeId) as ObjectResult;
        Result.StatusCode.Should().Be(400);
    }

    [Fact]
    public void ViewDeniedDrives_ShouldReturnStatusCode200_WhenProperEmployeeId()
    {
        int employeeId = 1; 

        _driveService.Setup(r => r.ViewDeniedDrives(employeeId)).Returns(() => null);

        var Result = _driveController.ViewDeniedDrives(employeeId) as ObjectResult;

        Result.StatusCode.Should().Be(200);
    }

   [Fact]
   public void  ViewDeniedDrives_ShouldReturnStatusCode500_WhenProperEmployeeId()
    {
        int employeeId = 1; 

        _driveService.Setup(r => r.ViewDeniedDrives(employeeId)).Throws<Exception>();

        var Result = _driveController.ViewDeniedDrives(employeeId) as ObjectResult;

        Result.StatusCode.Should().Be(500);
    }

    // Ignored Drives

    [Theory]
    [InlineData(0)]
    public void ViewIgnoredDrives_ShouldReturnStatusCode400_WhenEmployeeIdIsZero(int employeeId)
    {
        var Result = _driveController.ViewIgnoredDrives(employeeId) as ObjectResult;
        Result.StatusCode.Should().Be(400);
    }

    [Fact]
    public void ViewIgnoredDrives_ShouldReturnStatusCode200_WhenProperEmployeeId()
    {
        int employeeId = 1; 

        _driveService.Setup(r => r.ViewIgnoredDrives(employeeId)).Returns(() => null);

        var Result = _driveController.ViewIgnoredDrives(employeeId) as ObjectResult;

        Result.StatusCode.Should().Be(200);
    }

   [Fact]
   public void  ViewIgnoredDrives_ShouldReturnStatusCode500_WhenProperEmployeeId()
    {
        int employeeId = 1; 

        _driveService.Setup(r => r.ViewIgnoredDrives(employeeId)).Throws<Exception>();

        var Result = _driveController.ViewIgnoredDrives(employeeId) as ObjectResult;

        Result.StatusCode.Should().Be(500);
    }

    // Utilized Interviews

    [Theory]
    [InlineData(0)]
    public void ViewUtilizedInterviews_ShouldReturnStatusCode400_WhenEmployeeIdIsZero(int employeeId)
    {
        var Result = _driveController.ViewUtilizedInterviews(employeeId) as ObjectResult;
        Result.StatusCode.Should().Be(400);
    }

    [Fact]
    public void ViewUtilizedInterviews_ShouldReturnStatusCode200_WhenProperEmployeeId()
    {
        int employeeId = 1; 

        _driveService.Setup(r => r.ViewUtilizedInterviews(employeeId)).Returns(() => null);

        var Result = _driveController.ViewUtilizedInterviews(employeeId) as ObjectResult;

        Result.StatusCode.Should().Be(200);
    }

   [Fact]
   public void  ViewUtilizedInterviews_ShouldReturnStatusCode500_WhenProperEmployeeId()
    {
        int employeeId = 1; 

        _driveService.Setup(r => r.ViewUtilizedInterviews(employeeId)).Throws<Exception>();

        var Result = _driveController.ViewUtilizedInterviews(employeeId) as ObjectResult;

        Result.StatusCode.Should().Be(500);
    }

    // Not Utilized Interviews

    [Theory]
    [InlineData(0)]
    public void ViewNotUtilizedInterviews_ShouldReturnStatusCode400_WhenEmployeeIdIsZero(int employeeId)
    {
        var Result = _driveController.ViewNotUtilizedInterviews(employeeId) as ObjectResult;
        Result.StatusCode.Should().Be(400);
    }

    [Fact]
    public void ViewNotUtilizedInterviews_ShouldReturnStatusCode200_WhenProperEmployeeId()
    {
        int employeeId = 1; 

        _driveService.Setup(r => r.ViewNotUtilizedInterviews(employeeId)).Returns(() => null);

        var Result = _driveController.ViewNotUtilizedInterviews(employeeId) as ObjectResult;

        Result.StatusCode.Should().Be(200);
    }

   [Fact]
   public void  ViewNotUtilizedInterviews_ShouldReturnStatusCode500_WhenProperEmployeeId()
    {
        int employeeId = 1; 

        _driveService.Setup(r => r.ViewNotUtilizedInterviews(employeeId)).Throws<Exception>();

        var Result = _driveController.ViewNotUtilizedInterviews(employeeId) as ObjectResult;

        Result.StatusCode.Should().Be(500);
    }

    // View Total Availability

    [Theory]
    [InlineData(0)]
    public void ViewTotalAvailability_ShouldReturnStatusCode400_WhenEmployeeIdIsZero(int employeeId)
    {
        var Result = _driveController.ViewTotalAvailability(employeeId) as ObjectResult;
        Result.StatusCode.Should().Be(400);
    }

    [Fact]
    public void ViewTotalAvailability_ShouldReturnStatusCode200_WhenProperEmployeeId()
    {
        int employeeId = 1; 

        _driveService.Setup(r => r.ViewTotalAvailability(employeeId)).Returns(() => null);

        var Result = _driveController.ViewTotalAvailability(employeeId) as ObjectResult;

        Result.StatusCode.Should().Be(200);
    }

   [Fact]
   public void  ViewTotalAvailability_ShouldReturnStatusCode500_WhenProperEmployeeId()
    {
        int employeeId = 1; 

        _driveService.Setup(r => r.ViewTotalAvailability(employeeId)).Throws<Exception>();

        var Result = _driveController.ViewTotalAvailability(employeeId) as ObjectResult;

        Result.StatusCode.Should().Be(500);
    }

}