using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using FluentAssertions;
using IMS.Controllers;
using IMS.DataAccessLayer;
using IMS.Models;
using IMS.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using UnitTesting.MockData;
using Xunit;

namespace UnitTesting;

public class EmployeeControllerTest
{
    private readonly EmployeeController _employeeController;
    private readonly Mock<ILogger<EmployeeController>> _logger = new Mock<ILogger<EmployeeController>>();
    private readonly Mock<IEmployeeService> _employeeService = new Mock<IEmployeeService>();
    private readonly Mock<IMailService> _mailService = new Mock<IMailService>();
    public EmployeeControllerTest()
    {
        _employeeController = new EmployeeController(_logger.Object,_mailService.Object,_employeeService.Object);//
    }

    //Test Cases for CreateNewEmployee
    [Fact]
    public void CreateNewEmployee_ShouldReturnStatusCode200()
    {
        //Arrange
        List<Employee> employee = EmployeeMock.GetEmployeesMock();
        _employeeService.Setup(e => e.CreateNewEmployee(employee[0])).Returns(true);
        //Act
        var result = _employeeController.CreateNewEmployee(employee[0]) as ObjectResult;
        //Assert
        result.StatusCode.Should().Be(200);
        
    }
    [Fact]
    public void CreateNewEmployee_ShouldReturnStatusCode500()
    {
        //Arrange
        List<Employee> employee = EmployeeMock.GetEmployeesMock();
        _employeeService.Setup(e => e.CreateNewEmployee(employee[0])).Returns(false);
        //Act
        var result = _employeeController.CreateNewEmployee(employee[0]) as ObjectResult;
        //Assert
        result.StatusCode.Should().Be(500);
        
    }

    [Fact]
    public void CreateNewEmployee_ShouldReturnStatusCode400_ServiceThrowsValidationException()
    {
        //Arrange
        List<Employee> employee = EmployeeMock.GetEmployeesMock();
        _employeeService.Setup(employeeService => employeeService.CreateNewEmployee(employee[0])).Throws<ValidationException>();
        //Act
        var result = _employeeController.CreateNewEmployee(employee[0]) as ObjectResult;
        //Assert
        Assert.Equal(400, result.StatusCode);
    }
    [Fact]
    public void CreateNewEmployee_ShouldReturnStatusCode500_ServiceThrowsException()
    {
        //Arrange
        List<Employee> employee = EmployeeMock.GetEmployeesMock();
        _employeeService.Setup(employeeService => employeeService.CreateNewEmployee(employee[0])).Throws<Exception>();
        //Act
        var result = _employeeController.CreateNewEmployee(employee[0]) as ObjectResult;
        //Assert
        Assert.Equal(500, result.StatusCode);
    }

    //Test Cases For RemoveEmployee

    [Theory]
    [InlineData(1)]
    public void RemoveEmployee_ShouldReturnStatusCode200_WhenReturnsTure(int employeeId)
    {
        //Arrange
        _employeeService.Setup(e => e.RemoveEmployee(employeeId)).Returns(true);
        //Act
        var result = _employeeController.RemoveEmployee(employeeId) as ObjectResult;
        //Assert
        Assert.Equal(200, result.StatusCode);
    }
    [Theory]
    [InlineData(1)]
    public void RemoveEmployee_ShouldReturnStatusCode500_WhenReturnsFalse(int employeeId)
    {
        //Arrange
        _employeeService.Setup(e => e.RemoveEmployee(employeeId)).Returns(false);
        //Act
        var result = _employeeController.RemoveEmployee(employeeId) as ObjectResult;
        //Assert
        Assert.Equal(500, result.StatusCode);
    }
    [Theory]
    [InlineData(1)]
    public void RemoveEmployee_ShouldReturnStatusCode500_ServiceThrowsException(int employeeId)
    {
        //Arrange
        _employeeService.Setup(employeeService => employeeService.RemoveEmployee(employeeId)).Throws<Exception>();
        //Act
        var result = _employeeController.RemoveEmployee(employeeId) as ObjectResult;
        //Assert
        Assert.Equal(500, result.StatusCode);
    }
     [Theory]
    [InlineData(1)]
    public void RemoveEmployee_ShouldReturnStatusCode400_ServiceThrowsValidationException(int employeeId)
    {
        //Arrange
        _employeeService.Setup(employeeService => employeeService.RemoveEmployee(employeeId)).Throws<ValidationException>();
        //Act
        var result = _employeeController.RemoveEmployee(employeeId) as ObjectResult;
        //Assert
        Assert.Equal(400, result.StatusCode);
    }
    //Test Cases For ViewEmployees

    [Fact]
    public void ViewEmployees_ShouldReturnStatusCode200()
    {
        //Arrange
        _employeeService.Setup(employeeService => employeeService.ViewEmployees()).Returns(EmployeeMock.GetEmployeesMock());
        //Act
        var result = _employeeController.ViewEmployees() as ObjectResult;
        //Assert
        Assert.Equal(200, result.StatusCode);
    }

    //Test Cases For ViewProfile
    [Theory]
    [InlineData(1)]
    public void ViewProfile_ShouldReturnStatusCode200(int employeeId)
    {
        //Arrange
        _employeeService.Setup(e => e.ViewProfile(employeeId)).Returns(true);
        //Act
        var result = _employeeController.ViewProfile(employeeId) as ObjectResult;
        //Assert
        Assert.Equal(200, result.StatusCode);
    }

    [Theory]
    [InlineData(1)]
    public void ViewProfile_ShouldReturnStatusCode500_ServiceThrowsException(int employeeId)
    {
        //Arrange
        _employeeService.Setup(employeeService => employeeService.ViewProfile(employeeId)).Throws<Exception>();
        //Act
        var result = _employeeController.ViewProfile(employeeId) as ObjectResult;
        //Assert
        Assert.Equal(500, result.StatusCode);
    }    

    //Test Cases For ViewEmployeesByDepartment

    [Theory]
    [InlineData(1)]
    public void ViewEmployeesByDepartment_ShouldReturnStatusCode200(int departmentId)
    {
        //Arrange
        _employeeService.Setup(e => e.ViewEmployeesByDepartment(departmentId)).Returns(true);
        //Act
        var result = _employeeController.ViewEmployeesByDepartment(departmentId) as ObjectResult;
        //Assert
        Assert.Equal(200, result.StatusCode);
    }
    [Theory]
    [InlineData(1)]
    public void ViewEmployeesByDepartment_ShouldReturnStatusCode500_ServiceThrowsException(int departmentId)
    {
        //Arrange
        _employeeService.Setup(employeeService => employeeService.ViewEmployeesByDepartment(departmentId)).Throws<Exception>();
        //Act
        var result = _employeeController.ViewEmployeesByDepartment(departmentId) as ObjectResult;
        //Assert
        Assert.Equal(500, result.StatusCode);
    }   
    [Theory]
    [InlineData(1)]
    public void ViewEmployeesByDepartment_ShouldReturnStatusCode400_ServiceThrowsValidationException(int departmentId)
    {
        //Arrange
        _employeeService.Setup(employeeService => employeeService.ViewEmployeesByDepartment(departmentId)).Throws<ValidationException>();
        //Act
        var result = _employeeController.ViewEmployeesByDepartment(departmentId) as ObjectResult;
        //Assert
        Assert.Equal(400, result.StatusCode);
    }   

    //Test Cases For ViewEmployeeByApprovalStatus

    [Theory]
    [InlineData(true)]
    public void ViewEmployeeByApprovalStatus_ShouldReturnStatusCode200(bool isAdminAccepted)
    {
        //Arrange
        _employeeService.Setup(e => e.ViewEmployeeByApprovalStatus(isAdminAccepted)).Returns(EmployeeMock.GetEmployeesMock());
        //Act
        var result = _employeeController.ViewEmployeeByApprovalStatus(isAdminAccepted) as ObjectResult;
        //Assert
        Assert.Equal(200, result.StatusCode);
    }
    [Theory]
    [InlineData(true)]
    public void ViewEmployeeByApprovalStatus_ShouldReturnStatusCode500_WhenServiceThrowsException(bool isAdminAccepted)
    {
        //Arrange
        _employeeService.Setup(e => e.ViewEmployeeByApprovalStatus(isAdminAccepted)).Throws<Exception>();
        //Act
        var result = _employeeController.ViewEmployeeByApprovalStatus(isAdminAccepted) as ObjectResult;
        //Assert
        Assert.Equal(500, result.StatusCode);
    }

    //Test Cases For ViewEmployeeRequest

    [Fact]
    public void ViewEmployeeRequest_ShouldReturnStatusCode200()
    {
        //Arrange
        _employeeService.Setup(employeeService => employeeService.ViewEmployeeRequest()).Returns(EmployeeMock.GetEmployeesMock());
        //Act
        var result = _employeeController.ViewEmployeeRequest() as ObjectResult;
        //Assert
        Assert.Equal(200, result.StatusCode);
    }
}