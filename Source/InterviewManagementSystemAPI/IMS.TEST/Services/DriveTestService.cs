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

    }
}