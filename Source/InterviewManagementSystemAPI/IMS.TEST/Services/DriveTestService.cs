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
using System.Linq;

namespace UnitTesting.ServiceTests
{
    public class DriveTestService
    {
        private readonly DriveService _driveService;
        private readonly Mock<ILogger<DriveService>> _logger = new Mock<ILogger<DriveService>>();
        private readonly Mock<IDriveDataAccessLayer> _driveDataAccessLayer = new Mock<IDriveDataAccessLayer>();
        private Drive _drive;

        public DriveTestService()
        {
            _driveService = new DriveService(_logger.Object, _driveDataAccessLayer.Object);
            _drive = new Drive() { DriveId = 1, Name = "Test Drive", FromDate = System.DateTime.Now.AddDays(10), ToDate = System.DateTime.Now.AddDays(11), DepartmentId = 1, PoolId = 1, ModeId = 1, LocationId = 1, AddedBy = 1, UpdatedBy = 1 };
        }

        // Create Drive

        [Fact]
        public void CreateDrive_ThrowsValidationException_WithInvalidDriveName()
        {
            Drive drive = new Drive() { Name = "Test@3#4" };
            var Result = () => _driveService.CreateDrive(drive);

            Result.Should().Throw<ValidationException>();
        }
        [Fact]
        public void CreateDrive_ReturnsTrue_WithProperDrive()
        {
            //Arrange
            Drive drive = _drive;
            _driveDataAccessLayer.Setup(d => d.AddDriveToDatabase(drive)).Returns(true);

            //Act
            var Result = _driveService.CreateDrive(drive);

            //Assert
            Result.Should().BeTrue();
        }

        [Fact]
        public void CreateDrive_ReturnsFalse_WithProperDrive()
        {
            //Arrange
            Drive drive = _drive;
            _driveDataAccessLayer.Setup(d => d.AddDriveToDatabase(drive)).Returns(false);

            //Act
            var Result = _driveService.CreateDrive(drive);

            //Assert
            Result.Should().BeFalse();
        }
        [Fact]
        public void CreateDrive_ThrowsValidationException_WhenDALThrowsValidationException()
        {
            //Arrange
            Drive drive = _drive;
            _driveDataAccessLayer.Setup(d => d.AddDriveToDatabase(drive)).Throws<ValidationException>();

            //Act
            var Result = () => _driveService.CreateDrive(drive);

            //Assert
            Result.Should().Throw<ValidationException>();
        }
        [Fact]
        public void CreateDrive_ReturnsFalse_WhenDALThrowsValidationException()
        {
            //Arrange
            Drive drive = _drive;
            _driveDataAccessLayer.Setup(d => d.AddDriveToDatabase(drive)).Throws<Exception>();

            //Act
            var Result = _driveService.CreateDrive(drive);

            //Assert
            Result.Should().BeFalse();
        }


        // Other TestCases needs Entire Object

        // Cancel Drive

        [Theory]
        [InlineData(0, 1, "TestReason")]
        [InlineData(1, 0, "TestReason")]
        [InlineData(0, 0, "TestReason")]
        [InlineData(1, 1, "")]
        [InlineData(1, 1, null)]

        public void CancelDrive_ThrowsValidationException_WithInvalidInputs(int driveId, int tacId, string reason)
        {
            var Result = () => _driveService.CancelDrive(driveId, tacId, reason);

            Result.Should().Throw<ValidationException>();
        }

        // A method for " return _driveDataAccess.CancelDriveFromDatabase(driveId, tacId, reason); "

        [Fact]
        public void CancelDrive_ThrowsValidationException_When_DAL_ThrowsValidationException()
        {
            int driveId = 1;
            int tacId = 1;
            string reason = "TestReason";

            _driveDataAccessLayer.Setup(r => r.CancelDriveFromDatabase(driveId, tacId, reason)).Throws<ValidationException>();
            var Result = () => _driveService.CancelDrive(driveId, tacId, reason);
            Result.Should().Throw<ValidationException>();
        }

        [Fact]
        public void CancelDrive_ReturnsTrue_WithValidInput()
        {
            _driveDataAccessLayer.Setup(r => r.CancelDriveFromDatabase(1, 1, "reason")).Returns(true);
            var Result = _driveService.CancelDrive(1, 1, "reason");
            Result.Should().BeTrue();
        }

        [Fact]
        public void CancelDrive_Returnsfalse_WithValidInput()
        {
            _driveDataAccessLayer.Setup(r => r.CancelDriveFromDatabase(1, 1, "reason")).Returns(false);
            var Result = _driveService.CancelDrive(1, 1, "reason");
            Result.Should().BeFalse();
        }

        // View Today Drive

        [Fact]
        public void ViewTodayDrive_ReturnListofDrives()
        {
            _driveDataAccessLayer.Setup(DriveDataAccessLayer => DriveDataAccessLayer.GetDrivesByStatus(false)).Returns(DriveMock.GetDriveMockNonCancelled());
            var Result = _driveService.ViewTodayDrives();
            Result.Should().BeEquivalentTo(DriveMock.GetTodaysDriveMock());
        }

        [Fact]
        public void ViewTodayDrive_ThrowsException()
        {
            _driveDataAccessLayer.Setup(DriveDataAccessLayer => DriveDataAccessLayer.GetDrivesByStatus(false)).Throws<Exception>();
            var Result = () => _driveService.ViewTodayDrives();
            Result.Should().Throw<Exception>();
        }

    //View Scheduled Drives
        [Fact]
        public void ViewScheduledDrive_ReturnListofDrives()
        {
            _driveDataAccessLayer.Setup(DriveDataAccessLayer => DriveDataAccessLayer.GetDrivesByStatus(false)).Returns(DriveMock.GetDriveMockNonCancelled());
            var Result = _driveService.ViewScheduledDrives();
            Result.Should().BeEquivalentTo(DriveMock.GetScheduledDriveMock());
        }
        [Fact]
        public void ViewScheduledDrive_ThrowsException()
        {
            _driveDataAccessLayer.Setup(DriveDataAccessLayer => DriveDataAccessLayer.GetDrivesByStatus(false)).Throws<Exception>();
            var Result = () => _driveService.ViewScheduledDrives();
            Result.Should().Throw<Exception>();
        }
   
    //View Upcomming Drives
        [Fact]
        public void ViewUpcommingDrive_ReturnListofDrives()
        {
            _driveDataAccessLayer.Setup(DriveDataAccessLayer => DriveDataAccessLayer.GetDrivesByStatus(false)).Returns(DriveMock.GetDriveMockNonCancelled());
            var Result = _driveService.ViewUpcommingDrives();
            Result.Should().BeEquivalentTo(DriveMock.GetUpcommingDriveMock());
        }
        [Fact]
        public void ViewUpcommingDrive_ThrowsException()
        {
            _driveDataAccessLayer.Setup(DriveDataAccessLayer => DriveDataAccessLayer.GetDrivesByStatus(false)).Throws<Exception>();
            var Result = () => _driveService.ViewUpcommingDrives();
            Result.Should().Throw<Exception>();
        }
    //View Non Cancelled Drives
        [Fact]
        public void ViewNonCancelledDrive_ReturnListofDrives()
        {
            _driveDataAccessLayer.Setup(DriveDataAccessLayer => DriveDataAccessLayer.GetDrivesByStatus(false)).Returns(DriveMock.GetDriveMockNonCancelled());
            var Result = _driveService.ViewNonCancelledDrives();
            Result.Should().BeEquivalentTo(DriveMock.GetUpcommingDriveMock().Concat(DriveMock.GetScheduledDriveMock()).Concat(DriveMock.GetTodaysDriveMock()));
        }
        [Fact]
        public void ViewNonCancelledDrive_ThrowsException()
        {
            _driveDataAccessLayer.Setup(DriveDataAccessLayer => DriveDataAccessLayer.GetDrivesByStatus(false)).Throws<Exception>();
            var Result = () => _driveService.ViewNonCancelledDrives();
            Result.Should().Throw<Exception>();
        }
    //View Cancelled Drives
        [Fact]
        public void ViewCancelledDrive_ReturnListofDrives()
        {
            _driveDataAccessLayer.Setup(DriveDataAccessLayer => DriveDataAccessLayer.GetDrivesByStatus(true)).Returns(DriveMock.GetDriveMockForCancelled());
            var Result = _driveService.ViewAllCancelledDrives();
            Result.Should().BeEquivalentTo(DriveMock.GetCancelledDriveMock());
        }
        [Fact]
        public void ViewCancelledDrive_ThrowsException()
        {
            _driveDataAccessLayer.Setup(DriveDataAccessLayer => DriveDataAccessLayer.GetDrivesByStatus(true)).Throws<Exception>();
            var Result = () => _driveService.ViewAllCancelledDrives();
            Result.Should().Throw<Exception>();
        }

    }
}