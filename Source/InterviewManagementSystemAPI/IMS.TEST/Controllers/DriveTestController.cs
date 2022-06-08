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
    private readonly Mock<MailService> _mailService = new Mock<MailService>();

    public DriveControllerTest()
    {
        _driveController = new DriveController(_logger.Object, _mailService.Object, _driveService.Object);
    }

    [Theory]
    [InlineData(null)]
    public void CreateDrive_ShouldReturnStatusCode400_WhenDriveObjectIsNull(Drive drive)
    {
        var Result = _driveController.CreateDrive(drive) as ObjectResult;
        Result.StatusCode.Should().Be(500);
    }

}
