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
using System.Collections.Generic;

namespace UnitTesting.ServiceTests
{
    public class EmployeeTestService
    {
        private readonly EmployeeService _employeeService;
        private readonly Mock<ILogger<EmployeeService>> _logger = new Mock<ILogger<EmployeeService>>();
        //private readonly InterviewManagementSystemDbContext _db;
        private readonly Mock<IEmployeeDataAccessLayer> _employeeDataAccessLayer = new Mock<IEmployeeDataAccessLayer>();
        private readonly Mock<IDepartmentDataAccessLayer> _departmentDataAccessLayer = new Mock<IDepartmentDataAccessLayer>();
        private readonly Mock<IRoleDataAccessLayer> _roleDataAccessLayer = new Mock<IRoleDataAccessLayer>();

        public EmployeeTestService()
        {
            _employeeService = new EmployeeService(_logger.Object, _employeeDataAccessLayer.Object,_departmentDataAccessLayer.Object,_roleDataAccessLayer.Object);
        }
        //Test Cases For CreateNewEmployee
        [Theory]
        [InlineData(null)]
        public void CreateNewEmployee_WhenEmployeeIsNull(Employee employee)
        {
            //Arrange
            //Act
            var result = () => _employeeService.CreateNewEmployee(employee);
            //Assert
            result.Should().Throw<ValidationException>();
        }
        [Fact]
        public void CreateNewEmployee_ReturnsTrue()
        {
            //Arrange
            List<Employee> employee = EmployeeMock.GetEmployeesMock();
            _employeeDataAccessLayer.Setup(e => e.AddEmployeeToDatabase(employee[0])).Returns(true);
            //Act
            var result = _employeeService.CreateNewEmployee(employee[0]);
            //Assert
            result.Should().BeTrue();
        }
        [Fact]
        public void CreateNewEmployee_ReturnsFalse()
        {
            //Arrange
            List<Employee> employee = EmployeeMock.GetEmployeesMock();
            _employeeDataAccessLayer.Setup(e => e.AddEmployeeToDatabase(employee[0])).Returns(false);
            //Act
            var result = _employeeService.CreateNewEmployee(employee[0]);
            //Assert
            result.Should().BeFalse();
        }
        [Fact]
        public void CreateNewEmployee_WhenDALThrowsValidationException()
        {
            //Arrange
            List<Employee> employee = EmployeeMock.GetEmployeesMock();
            _employeeDataAccessLayer.Setup(e => e.AddEmployeeToDatabase(employee[0])).Throws<ValidationException>();
            //Act
            var result = () => _employeeService.CreateNewEmployee(employee[0]);
            //Assert
            result.Should().Throw<ValidationException>();
        }
         [Fact]
        public void CreateNewEmployee_WhenDALThrowsAnException()
        {
            //Arrange
            List<Employee> employee = EmployeeMock.GetEmployeesMock();
            _employeeDataAccessLayer.Setup(e => e.AddEmployeeToDatabase(employee[0])).Throws<Exception>();
            //Act
            var result = () => _employeeService.CreateNewEmployee(employee[0]);
            //Assert
            result.Should().Throw<Exception>();
        }
        //Test Cases For RemoveEmployee
        [Theory]
        [InlineData(0)]
        public void RemoveEmployee_ThorwsValidationException_WhenEmployeeIdIsZero(int employeeId)
        {
            //Arrange
            //Act
            var result = () => _employeeService.RemoveEmployee(employeeId);
            //Assert
            result.Should().Throw<ValidationException>();
        }
        [Theory]
        [InlineData(1)]
        public void RemoveEmployee_ReturnsTrue(int employeeId)
        {
            //Arrange
            _employeeDataAccessLayer.Setup(e=>e.RemoveEmployeeFromDatabase(employeeId)).Returns(true);
            //Act
            var result = _employeeService.RemoveEmployee(employeeId);
            //Assert
            result.Should().BeTrue();
        }
        [Theory]
        [InlineData(1)]
        public void RemoveEmployee_ReturnsFalse(int employeeId)
        {
            //Arrange
            _employeeDataAccessLayer.Setup(e=>e.RemoveEmployeeFromDatabase(employeeId)).Returns(false);
            //Act
            var result = _employeeService.RemoveEmployee(employeeId);
            //Assert
            result.Should().BeFalse();
        }
        [Theory]
        [InlineData(1)]
        public void RemoveEmployee_ThorwsArgumentException(int employeeId)
        {
            //Arrange
            _employeeDataAccessLayer.Setup(e => e.RemoveEmployeeFromDatabase(employeeId)).Throws<ArgumentException>();
            //Act
            var result = () => _employeeService.RemoveEmployee(employeeId);
            //Assert
            result.Should().Throw<ArgumentException>();
        }
        [Theory]
        [InlineData(1)]
        public void RemoveEmployee_ThorwsValidationException(int employeeId)
        {
            //Arrange
            _employeeDataAccessLayer.Setup(e => e.RemoveEmployeeFromDatabase(employeeId)).Throws<ValidationException>();
            //Act
            var result = () => _employeeService.RemoveEmployee(employeeId);
            //Assert
            result.Should().Throw<ValidationException>();
        }
        [Theory]
        [InlineData(1)]
        public void RemoveEmployee_ThorwsException(int employeeId)
        {
            //Arrange
            _employeeDataAccessLayer.Setup(e => e.RemoveEmployeeFromDatabase(employeeId)).Throws<Exception>();
            //Act
            var result = () => _employeeService.RemoveEmployee(employeeId);
            //Assert
            result.Should().Throw<Exception>();
        }


        //Test Cases For ViewProfile
        [Theory]
        [InlineData(0)]
        public void ViewProfile_ThorwsValidationException_WhenEmployeeIdIsZero(int employeeId)
        {
            //Arrange
            //Act
            var result = () => _employeeService.ViewProfile(employeeId);
            //Assert
            result.Should().Throw<ValidationException>();
        }
        [Theory]
        [InlineData(1)]
        public void ViewProfile_ReturnsEmployeeDetails(int employeeId)
        {
            //Arrange
            List<Employee> employee = EmployeeMock.GetEmployeesMock();
            _employeeDataAccessLayer.Setup(e => e.ViewProfile(employeeId)).Returns(employee[0]);
            //Act
            var result = _employeeService.ViewProfile(employeeId);
            //Assert
            result.Should().BeEquivalentTo(employee[0]);
        }
    }
}