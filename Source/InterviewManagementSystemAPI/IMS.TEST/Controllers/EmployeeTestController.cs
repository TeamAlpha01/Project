using System;
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
    private readonly Mock<EmployeeService> _employeeService = new Mock<EmployeeService>();
    private readonly Mock<MailService> _mailService = new Mock<MailService>();
    public EmployeeControllerTest()
    {
        _employeeController = new EmployeeController(_logger.Object,_mailService.Object,_employeeService.Object);//
    }

    [Fact]
    public void CreateNewEmployee_ShouldReturnStatusCode200()
    {
        //Arrange
        Employee employee = new Employee();
        //employee.EmployeeId = 1;employee.Name="ksk";employee.DepartmentId = 1;employee.EmailId = "ksk@gmail.com";employee.EmployeeAceNumber = "ACE9900";employee.Password = "Pass@12345";employee.RoleId = 1;employee.ProjectId = 1;
        _employeeService.Setup(e => e.CreateNewEmployee(employee)).Returns(true);
        //Act
        var result = _employeeController.CreateNewEmployee(employee) as ObjectResult;
        //Assert
        result.StatusCode.Should().Be(200);
        
    }
    [Fact]
    public void CreateNewEmployee_ShouldReturnStatusCode500()
    {
        //Arrange
        Employee employee = new Employee();
        //employee.EmployeeId = 1;employee.Name="ksk";employee.DepartmentId = 1;employee.EmailId = "ksk@gmail.com";employee.EmployeeAceNumber = "ACE9900";employee.Password = "Pass@12345";employee.RoleId = 1;employee.ProjectId = 1;
        _employeeService.Setup(e => e.CreateNewEmployee(employee)).Returns(false);
        //Act
        var result = _employeeController.CreateNewEmployee(employee) as ObjectResult;
        //Assert
        result.StatusCode.Should().Be(500);
        
    }

    [Fact]
    public void CreateNewEmployee_ShouldReturnStatusCode400_ServiceThrowsValidationException()
    {
        //Arrange
        Employee employee = new Employee();
        _employeeService.Setup(employeeService => employeeService.CreateNewEmployee(employee)).Throws<ValidationException>();
        //Act
        var result = _employeeController.CreateNewEmployee(employee) as ObjectResult;
        //Assert
        Assert.Equal(400, result.StatusCode);
    }
    [Fact]
    public void CreateNewEmployee_ShouldReturnStatusCode500_ServiceThrowsException()
    {
        //Arrange
        Employee employee = new Employee();
        _employeeService.Setup(employeeService => employeeService.CreateNewEmployee(employee)).Throws<Exception>();
        //Act
        var result = _employeeController.CreateNewEmployee(employee) as ObjectResult;
        //Assert
        Assert.Equal(500, result.StatusCode);
    }
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
    [Fact]
    public void RemoveEmployee_ShouldReturnStatusCode400()
    {
        //Arrange
        int employeeId = 1;
        _employeeService.Setup(employeeService => employeeService.RemoveEmployee(employeeId)).Throws<ValidationException>();
        //Act
        var result = _employeeController.RemoveEmployee(employeeId) as ObjectResult;
        //Assert
        Assert.Equal(400, result.StatusCode);
    }
}