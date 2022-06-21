using System.ComponentModel.DataAnnotations;
using System.Linq;
using FluentAssertions;
using IMS.DataAccessLayer;
using IMS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using UnitTesting.MockData;
using UnitTesting.Utility;
using Xunit;

namespace UnitTesting.DataAccessLayer
{
    public class DepartmentDataAccessLayerTest
    {
        private readonly IDepartmentDataAccessLayer _departmentDataAccessLayer;
        private readonly Mock<ILogger<DepartmentDataAccessLayer>> _logger = new Mock<ILogger<DepartmentDataAccessLayer>>();
        private readonly InterviewManagementSystemDbContext _db ;
        public DepartmentDataAccessLayerTest()
        {
            _db = DbUtility.GetInMemoryDbContext();
            _departmentDataAccessLayer = new DepartmentDataAccessLayer(_logger.Object,_db);
        }


        [Fact]        
        public void AddDepartmentToDatabase_ThrowsValidationException()
        {
            //Arrange
            DbUtility.SeedInMemoryDb(_db);
            Department testDepartment=new Department(){DepartmentName="BFS",IsActive=true};
          
            //Act
            var Result=()=>_departmentDataAccessLayer.AddDepartmentToDatabase(testDepartment);
        
            //Assert
            Result.Should().Throw<ValidationException>();
        }
         [Fact]
        public void AddDepartmentToDatabase_ReturnsTrue()
        {
            //Arrange
            Department testDepartment = new Department(){DepartmentId = 10,DepartmentName = "LocalDb",IsActive = true};
            //Act
            var Result = _departmentDataAccessLayer.AddDepartmentToDatabase(testDepartment);
            //Assert
            Assert.True(Result);
        }
        
        [Fact]        
        public void AddDepartmentToDatabase_ThrowsDbUpdateException()
        {
            //Arrange
            var DbMock = new Mock<InterviewManagementSystemDbContext>();
           //Act
           DbMock.Setup(d=>d.SaveChanges()).Throws<DbUpdateException>();
            var Result = ()=> _departmentDataAccessLayer.AddDepartmentToDatabase(new Department());
            //Assert
            Result.Should().Throw<DbUpdateException>();
        }
        [Fact]
        public void AddProjectToDatabase_ReturnsTrue()
        {
            Project testProject=new Project(){ProjectId=10,DepartmentId= 10,ProjectName="Test",IsActive=true};
            var Result=_departmentDataAccessLayer.AddProjectToDatabase(testProject);
            Assert.True(Result);
        }
        [Fact]
        public void AddProjectToDatabase_ThrowsDbUpdateException()
        {
            var DbMock=new Mock<InterviewManagementSystemDbContext>();
            DbMock.Setup(p=>p.SaveChanges()).Throws<DbUpdateException>();
            var Result=()=>_departmentDataAccessLayer.AddProjectToDatabase(new Project());
            Result.Should().Throw<DbUpdateException>();
        }
        
        


    }
}