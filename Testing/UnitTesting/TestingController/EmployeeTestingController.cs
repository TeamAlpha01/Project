using System.Linq;
using FluentAssertions;
using IMS.Controllers;
using IMS.DataAccessLayer;
using IMS.Models;
using IMS.Service;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace UnitTesting;

public class EmployeeTesting
{
    private IMS.DataAccessLayer.InterviewManagementSystemDbContext _db = IMS.DataFactory.DbContextDataFactory.GetInterviewManagementSystemDbContextObject();

    [Fact]
    public void ViewEmployees_ShouldReturn200Status()
    {
        // Arrange
        var employeeService = new Mock<IEmployeeService>();
        employeeService.Setup(_ => _.ViewEmployees()).Returns(_db.Employees.ToList());
        var sut = new EmployeeController(employeeService.Object);

        // Act
        var result = (OkObjectResult)sut.ViewEmployees();

        //Assert
        result.StatusCode.Should().Be(200);
    }



}