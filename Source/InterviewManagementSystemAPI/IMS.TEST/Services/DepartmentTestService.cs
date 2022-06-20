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
    public class DepartmentTestService
    {
        private readonly DepartmentService _DepartmentService;
        private readonly Mock<ILogger<DepartmentService>> _logger = new Mock<ILogger<DepartmentService>>();
        private readonly InterviewManagementSystemDbContext _db ;
        private readonly Mock<IDepartmentDataAccessLayer> _DepartmentDataAccessLayer = new Mock<IDepartmentDataAccessLayer>();

        public DepartmentTestService()
        {
            _DepartmentService = new DepartmentService(_logger.Object, _DepartmentDataAccessLayer.Object);
        }

        //TestCases for Create Department Method

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void CreateDepartment_ThrowsValidationException_WithInvalidDepartmentName(string departmentName)
        {
            var Result = () => _DepartmentService.CreateDepartment (departmentName);

            Result.Should().Throw<ValidationException>();
        }

        [Fact]
        public void CreateDepartment_ReturnsTrue_WithValidDepartmentName()
        {            
            _DepartmentDataAccessLayer.Setup(r=>r.AddDepartmentToDatabase(It.Is<Department>(r=>r.DepartmentName == "Chennai"))).Returns(true);

            var Result = _DepartmentService.CreateDepartment("Chennai");
            Result.Should().BeTrue();
        }
        
        [Fact]
        public void CreateDepartment_ReturnsFalse_WithValidDepartmentName()
        {            
            _DepartmentDataAccessLayer.Setup(r=>r.AddDepartmentToDatabase(It.Is<Department>(r=>r.DepartmentName == "Chennai"))).Returns(false);

            var Result = _DepartmentService.CreateDepartment("Chennai");
            Result.Should().BeFalse();
        }

        [Fact]
        public void CreateDepartment_ThrowsValidationException_When_DAL_ThrowsValidationException()
        {            
            _DepartmentDataAccessLayer.Setup(r=>r.AddDepartmentToDatabase(It.Is<Department>(r=>r.DepartmentName == "Chennai"))).Throws<ValidationException>();

            var Result = () => _DepartmentService.CreateDepartment("Chennai");
            Result.Should().Throw<ValidationException>();
        }
        [Fact]
        public void CreateDepartment_ReturnFalse_When_DAL_ThrowsException()
        {            
            _DepartmentDataAccessLayer.Setup(r=>r.AddDepartmentToDatabase(It.Is<Department>(r=>r.DepartmentName == "Chennai"))).Throws<Exception>();

            var Result = _DepartmentService.CreateDepartment("Chennai");
            Result.Should().BeFalse();
        }

        //TestCases for Remove Department Method

        // [Theory]
        // [InlineData(null)]
        // public void RemoveDepartment_ThrowsValidationException_WithInvalidDepartmentId(int departmentId)
        // {
        //     var Result = () => _DepartmentService.RemoveDepartment(departmentId);

        //     Result.Should().Throw<ValidationException>();
        // }

        [Fact]
        public void RemoveDepartment_ReturnsTrue_WithValidDepartmentId()
        {            
            int DepartmentId = 1;
           _DepartmentDataAccessLayer.Setup(r => r.RemoveDepartmentFromDatabase(DepartmentId)).Returns(true);
            var Result = _DepartmentService.RemoveDepartment(DepartmentId);
            Result.Should().BeTrue();
        }

         [Fact]
        public void RemoveDepartment_ReturnsFalse_WithValidDepartmentId()
        {            
            int DepartmentId = 1;
           _DepartmentDataAccessLayer.Setup(r => r.RemoveDepartmentFromDatabase(DepartmentId)).Returns(false);
            var Result = _DepartmentService.RemoveDepartment(DepartmentId);
            Result.Should().BeFalse();
        }
        
        [Fact]
        public void RemoveDepartment_ReturnFalse_When_DAL_ThrowsArgumentException()
        {            
            int DepartmentId = 1;
            _DepartmentDataAccessLayer.Setup(r=>r.RemoveDepartmentFromDatabase(DepartmentId)).Throws<ArgumentException>();
            var Result = _DepartmentService.RemoveDepartment(DepartmentId);
            Result.Should().BeFalse();
        }

        [Fact]
        public void RemoveDepartment_ReturnFalse_When_DAL_ThrowsValidationException()
        {            
            int DepartmentId = 1;
            _DepartmentDataAccessLayer.Setup(r=>r.RemoveDepartmentFromDatabase(DepartmentId)).Throws<ValidationException>();
            var Result = () => _DepartmentService.RemoveDepartment(DepartmentId);
            Result.Should().Throw<ValidationException>();
        }

        [Fact]
        public void RemoveDepartment_ReturnFalse_When_DAL_ThrowsException()
        {            
            int DepartmentId = 1;
            _DepartmentDataAccessLayer.Setup(r=>r.RemoveDepartmentFromDatabase(DepartmentId)).Throws<Exception>();
            var Result = _DepartmentService.RemoveDepartment(DepartmentId);
            Result.Should().BeFalse();
        }

        //Testcases for View Department Method

        [Fact]
        public void ViewDepartment_ThrowsException_When_DAL_ThrowsException()
        { 
            _DepartmentDataAccessLayer.Setup(r=>r.GetDepartmentsFromDatabase()).Throws<Exception>();
            var Result = () => _DepartmentService.ViewDepartments();
            Result.Should().Throw<Exception>();
        }

        // [Fact]
        // public void ViewDepartment_ShouldReturnListofDepartments()
        // {
        //     _DepartmentDataAccessLayer.Setup(DepartmentDataAccessLayer => DepartmentDataAccessLayer.GetDepartmentsFromDatabase()).Returns(() => null);
        //     var Result = _DepartmentService.ViewDepartments();
        //     Result = null ;
        // }
        [Theory]
        [InlineData(0,"#Internal123")]
        public void Createproject_ThrowsValidationException_WithInvalidCredintials(int departmentId, string projectName)
        {
            var Result = () => _DepartmentService.CreateProject(departmentId,projectName);

            Result.Should().Throw<ValidationException>();
        }
        
        [Fact]
        public void Createproject_ReturnsTrue_WithValidpoolName()
        {            
            _DepartmentDataAccessLayer.Setup(r=>r.AddProjectToDatabase(It.Is<Project>(r=>r.ProjectName == "Internal"))).Returns(true);

            var Result = _DepartmentService.CreateProject(1,"Internal");
            Result.Should().BeTrue();
        }
           
        [Fact]
        public void Createpool_ReturnsFalse_WithValidpoolName()
        {            
            _DepartmentDataAccessLayer.Setup(r=>r.AddProjectToDatabase(It.Is<Project>(r=>r.ProjectName == "Internal"))).Returns(false);

            var Result = _DepartmentService.CreateProject(1,"Internal");
            Result.Should().BeFalse();
        }
         [Theory]
        [InlineData(0,"#Internal123")]
        public void Createproject_ThrowsException_WithInvalidCredintials(int departmentId, string projectName)
        {
            var Result = () => _DepartmentService.CreateProject(departmentId,projectName);

            Result.Should().Throw<Exception>();
        }
        
        [Theory]
        [InlineData(0)]
        public void Removeproject_ThrowsValidationException_WithInvalidCredintials(int projectId)
        {
            var Result = () => _DepartmentService.RemoveProject(projectId);

            Result.Should().Throw<ValidationException>();
        }
          [Fact]
        public void Removeproject_ReturnsTrue_WithValidprojectId()
        {            
            int projectId = 1;
           _DepartmentDataAccessLayer.Setup(r => r.RemoveProjectFromDatabase(projectId)).Returns(true);
            var Result = _DepartmentService.RemoveProject(projectId);
            Result.Should().BeTrue();
        }
         [Fact]
        public void Removeproject_ReturnsFalse_WithValidprojectId()
        {            
            int projectId = 1;
           _DepartmentDataAccessLayer.Setup(r => r.RemoveProjectFromDatabase(projectId)).Returns(false);
            var Result = _DepartmentService.RemoveProject(projectId);
            Result.Should().BeFalse();
        }
      
        [Fact]
        public void Removeproject_ReturnFalse_When_DAL_ThrowsValidationException()
        {            
            int projectId = 1;
            _DepartmentDataAccessLayer.Setup(r=>r.RemoveProjectFromDatabase(projectId)).Throws<ValidationException>();
            var Result = () => _DepartmentService.RemoveProject(projectId);
            Result.Should().Throw<ValidationException>();
        }
          [Fact]
        public void Viewproject_ThrowsException_When_DAL_ThrowsException()
        { 
            _DepartmentDataAccessLayer.Setup(r=>r.GetProjectsFromDatabase()).Throws<Exception>();
            var Result = () => _DepartmentService.ViewProjects();
            Result.Should().Throw<Exception>();
        }
        // [Fact]
        // public void Viewproject_ShouldReturnListofProjects()
        // {
        //     _DepartmentDataAccessLayer.Setup(DepartmentDataAccessLayer => DepartmentDataAccessLayer.GetProjectsFromDatabase()).Returns(() => null);
        //     var Result = _DepartmentService.ViewProjects();
        //     Result = null ;
        // }





        


    }
}
 