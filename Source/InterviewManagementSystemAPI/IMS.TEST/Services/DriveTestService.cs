using System;
using System.ComponentModel.DataAnnotations;
using FluentAssertions;
using IMS.DataAccessLayer;
using IMS.Models;
using IMS.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using UnitTesting.MockData;
using Xunit;
using UnitTesting.Utility;


namespace UnitTesting.ServiceTests
{
    public class DriveTestService
    {
    private readonly DriveService _driveService;
    private readonly Mock<ILogger<DriveService>> _logger = new Mock<ILogger<DriveService>>();
    private readonly Mock<IDriveDataAccessLayer> _driveDataAccessLayer = new Mock<IDriveDataAccessLayer>();

    public DriveTestService()
    {
        _driveService = new DriveService(_logger.Object, _driveDataAccessLayer.Object);
    }

    // Create Drive

    [Theory]
    [InlineData(null)]
    public void CreateDrive_ThrowsValidationException_WithInvalidDriveName(Drive drive)
    {
        var Result = () => _driveService.CreateDrive(drive);

        Result.Should().Throw<ValidationException>();
    }

    // Other TestCases needs Entire Object

    // Cancel Drive

    [Theory]
    [InlineData(0,1,"TestReason")]
    [InlineData(1,0,"TestReason")]
    [InlineData(0,0,"TestReason")]
    public void CancelDrive_ThrowsValidationException_WithInvalidCredintials(int driveId, int tacId, string reason)
    {
        var Result = () => _driveService.CancelDrive( driveId,  tacId,  reason);

        Result.Should().Throw<ValidationException>();
    }

    // A method for " return _driveDataAccess.CancelDriveFromDatabase(driveId, tacId, reason); "

    [Fact]
    public void CancelDrive_ReturnFalse_When_DAL_ThrowsValidationException()
    {            
        int driveId = 1; 
        int tacId = 1; 
        string reason = "TestReason";

        _driveDataAccessLayer.Setup(r=>r.CancelDriveFromDatabase(driveId,  tacId,  reason)).Throws<ValidationException>();
        var Result = () => _driveService.CancelDrive(driveId,  tacId,  reason);
        Result.Should().Throw<ValidationException>();
    }

    [Fact]
    public void CancelDrive_ReturnFalse_When_DAL_ThrowsException()
    {            
        int driveId = 1; 
        int tacId = 1; 
        string reason = "TestReason";

        _driveDataAccessLayer.Setup(r=>r.CancelDriveFromDatabase(driveId,tacId,reason)).Returns(false);
        var Result = _driveService.CancelDrive(driveId,  tacId,  reason);
        Result.Should().BeFalse();
    }

    // View Today Drive

        [Fact]
        public void ViewTodayDrive_ShouldReturnListofDrives()
        {
            _driveDataAccessLayer.Setup(DriveDataAccessLayer => DriveDataAccessLayer.GetDrivesByStatus(true)).Returns(() => null);
            var Result = _driveService.ViewTodayDrives();
            Result = null;
        }

        [Fact]
        public void ViewTodayDrive_ShouldReturnsException()
        {
            _driveDataAccessLayer.Setup(DriveDataAccessLayer => DriveDataAccessLayer.GetDrivesByStatus(true)).Throws<Exception>();
            var Result = () => _driveService.ViewTodayDrives();
            Result.Should().Throw<Exception>();
        }


    }
}