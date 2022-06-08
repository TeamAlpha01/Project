using System;
using System.ComponentModel.DataAnnotations;
using FluentAssertions;
using IMS.Controllers;
using IMS.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace UnitTesting.Controllers;

public class departmentControllerTest
{
    private readonly DepartmentController _departmentController;
    private readonly Mock<ILogger<DepartmentController>> _logger = new Mock<ILogger<DepartmentController>>();
    private readonly Mock<IDepartmentService> _departmentService = new Mock<IDepartmentService>();

    public departmentControllerTest ()
    {
        _departmentController = new DepartmentController(_logger.Object, _departmentService.Object);
    }

    //Test for Create department Method (5 TestCases)

    [Theory]
    [InlineData(null)]
    public void CreateNewdepartment_ShouldReturnStatusCode400_WhendepartmentNameIsNull(string departmentName)
    {
        var Result = _departmentController.CreateNewDepartment(departmentName) as ObjectResult;
        Result.StatusCode.Should().Be(400);
    }

    [Fact]
    public void CreateNewdepartment_ShouldReturnStatusCode200_WithProperdepartmentName()
    {
        string departmentName = "Dotnet";
        _departmentService.Setup(r => r.CreateDepartment(departmentName)).Returns(true);

        var Result = _departmentController.CreateNewDepartment(departmentName) as ObjectResult;

        Result.StatusCode.Should().Be(200);
    }

    [Fact]
    public void CreateNewdepartment_ShouldReturnStatusCode500_WithProperdepartmentName()
    {
        string departmentName = "Dotnet";
        _departmentService.Setup(r => r.CreateDepartment(departmentName)).Returns(false);
        var Result = _departmentController.CreateNewDepartment(departmentName) as ObjectResult;
        Result.StatusCode.Should().Be(500);
    }

    [Fact]
    public void CreateNewdepartment_ShouldReturnStatusCode400_WhenServiceThrowsValidationException()
    {
        string departmentName = "Dotnet";
        _departmentService.Setup(r => r.CreateDepartment(departmentName)).Throws<ValidationException>();
        var Result = _departmentController.CreateNewDepartment(departmentName) as ObjectResult;
        Result.StatusCode.Should().Be(400);
    }

    [Fact]
    public void CreateNewdepartment_ShouldReturnStatusCode500_WhenServiceThrowsException()
    {
        string departmentName = "Dotnet";
        _departmentService.Setup(r => r.CreateDepartment(departmentName)).Throws<Exception>();
        var Result = _departmentController.CreateNewDepartment(departmentName) as ObjectResult;
        Result.StatusCode.Should().Be(500);
    }

    //Test for Remove department Method (5 TestCases)

    [Theory]
    [InlineData(0)]
    public void Removedepartment_ShouldReturnStatusCode400_WhendepartmentNameIsZero(int departmentId)
    {
        var Result = _departmentController.RemoveDepartment(departmentId) as ObjectResult;
        Result.StatusCode.Should().Be(400);
    }

    [Fact]
    public void Removedepartment_ShouldReturnStatusCode200_WithProperdepartmentId()
    {
        int departmentId = 1;
        _departmentService.Setup(r => r.RemoveDepartment(departmentId)).Returns(true);
        var Result = _departmentController.RemoveDepartment(departmentId) as ObjectResult;
        Result.StatusCode.Should().Be(200);
    }

    [Fact]
    public void Removedepartment_ShouldReturnStatusCode500_WithProperdepartmentId()
    {
        int departmentId = 1;
        _departmentService.Setup(r => r.RemoveDepartment(departmentId)).Returns(false);
        var Result = _departmentController.RemoveDepartment(departmentId) as ObjectResult;
        Result.StatusCode.Should().Be(500);
    }

    [Fact]
    public void Removedepartment_ShouldReturnStatusCode400_WhenServiceThrowsValidationException()
    {
        int departmentId = 1;
        _departmentService.Setup(r => r.RemoveDepartment(departmentId)).Throws<Exception>();
        var Result = _departmentController.RemoveDepartment(departmentId) as ObjectResult;
        Result.StatusCode.Should().Be(400);
    }

    [Fact]
    public void Removedepartment_ShouldReturnStatusCode500_WhenServiceThrowsException()
    {
        int departmentId = 0;
        _departmentService.Setup(r => r.RemoveDepartment(departmentId)).Throws<ValidationException>();
        var Result = _departmentController.RemoveDepartment(departmentId) as ObjectResult;
        Result.StatusCode.Should().Be(400);
    }

    // Test for View department Method (2 TestCases)

    [Fact]
    public void Viewdepartment_ShouldReturnStatusCode200()
    {
        // Arrange
        _departmentService.Setup(departmentService => departmentService.ViewDepartments()).Returns(() => null);
        // Act
        var Result = _departmentController.ViewDepartments() as ObjectResult;
        //Assert
        Assert.Equal(200, Result.StatusCode);
    }

    [Fact]
    public void ViewDepartmrnt_ShouldReturnStatusCode400()
    {
        // Arrange
        _departmentService.Setup(departmentService => departmentService.ViewDepartments()).Throws<Exception>();
        // Act
        var Result = _departmentController.ViewDepartments() as ObjectResult;
        //Assert
        Assert.Equal(400, Result.StatusCode);
    }

}