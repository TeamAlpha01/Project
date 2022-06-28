using System;
using System.ComponentModel.DataAnnotations;
using FluentAssertions;
using IMS.Controller;
using IMS.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using UnitTesting.MockData;
using Xunit;


namespace UnitTesting.Controllers;


public class ProjectTestController
{
    private readonly ProjectController _projectController;
    private readonly Mock<ILogger<ProjectController>> _logger =new Mock<ILogger<ProjectController>>();
    private readonly Mock<IDepartmentService> _departmentService =new Mock<IDepartmentService>();

    public ProjectTestController()
    {
        _projectController = new ProjectController(_logger.Object,_departmentService.Object);

    }
    [Fact]
    public void CreateProject_ShouldReturnStatusCode200_WithProperInputs()
    {
        int departmentId = 1; 
        string projectName = "TestProject";

        _departmentService.Setup(r => r.CreateProject(departmentId,projectName)).Returns(true);

        var Result = _projectController.CreateNewProject(departmentId,projectName) as ObjectResult;

        Result.StatusCode.Should().Be(200);
    }
    [Theory]
    [InlineData(0,null)]
    public void CreateProject_ShouldReturnStatusCode400_WhenDepartmentIdAndProjectNameIsNull(int departmentId,string projectName)
    {
        var Result=_projectController.CreateNewProject(departmentId,projectName) as ObjectResult;
        Result.StatusCode.Should().Be(400);

    }

    [Fact]
    public void CreateProject_ShouldReturnStatusCode500_WithImProperInputs()
    {
        int departmentId = 1; 
        string projectName = "TestProject";

        _departmentService.Setup(r => r.CreateProject(departmentId,projectName)).Returns(false);

        var Result = _projectController.CreateNewProject(departmentId,projectName) as ObjectResult;

        Result.StatusCode.Should().Be(500);
    }

    [Fact]
    public void CreateProject_ShouldReturnStatusCode400_WhenServiveThrowsValidationException()
    {
        int departmentId = 1; 
        string projectName = "TestProject";

        _departmentService.Setup(r => r.CreateProject(departmentId,projectName)).Throws<ValidationException>();

        var Result = _projectController.CreateNewProject(departmentId,projectName) as ObjectResult;

        Result.StatusCode.Should().Be(400);
    }

    [Fact]
    public void CreateProject_ShouldReturnProblem_WhenServiceThrowsException()
    {
        int departmentId = 1; 
        string projectName = "TestProject";

        _departmentService.Setup(r => r.CreateProject(departmentId,projectName)).Throws<Exception>();

        var Result = _projectController.CreateNewProject(departmentId,projectName ) as ObjectResult;

        Result.StatusCode.Should().Be(500);
    }

    
    //Test for Remove Project Method (5 TestCases)

    [Theory]
    [InlineData(0)]
    public void RemoveProject_ShouldReturnStatusCode400_WhenProjectIdIsZero(int projectId)
    {
        var Result = _projectController.RemoveProject(projectId) as ObjectResult;
        Result.StatusCode.Should().Be(400);
    }

     [Fact]
     public void RemoveProject_ShouldReturnStatusCode200_WithProperProjectId()
    {
        int projectId = 1;
        _departmentService.Setup(r => r.RemoveProject(projectId)).Returns(true);
        var Result = _projectController.RemoveProject(projectId) as ObjectResult;
        Result.StatusCode.Should().Be(200);
    }

    [Fact]
    public void RemoveProject_ShouldReturnStatusCode500_WithInvalidprojectId()
    {
        int projectId = 1;
        _departmentService.Setup(r => r.RemoveProject(projectId)).Returns(false);
        var Result = _projectController.RemoveProject(projectId) as ObjectResult;
        Result.StatusCode.Should().Be(500);
    }

    [Fact]
    public void RemoveProject_ShouldReturnStatusCode400_WhenServiceThrowsException()
    {
        int projectId = 1;
        _departmentService.Setup(r => r.RemoveProject(projectId)).Throws<Exception>();
        var Result = _projectController.RemoveProject(projectId) as ObjectResult;
        Result.StatusCode.Should().Be(500);
    }

    [Fact]
    public void RemoveProject_ShouldReturnStatusCode500_WhenServiceThrowsValidationException()
    {
        int projectId = 0;
        _departmentService.Setup(r => r.RemoveProject(projectId)).Throws<ValidationException>();
        var Result = _projectController.RemoveProject(projectId) as ObjectResult;
        Result.StatusCode.Should().Be(400);
    }
     // Test for View Project Method (2 TestCases)

    [Fact]
    public void Viewprojects_ShouldReturnStatusCode200()
    {
        var projects=ProjectMock.ListOfProjects();
        // Arrange
        _departmentService.Setup(departmentService => departmentService.ViewProjects()).Returns(projects);
        // Act
        var Result = _projectController.ViewProjects() as ObjectResult;
        //Assert
        Assert.Equal(projects,Result?.Value);
    }

    [Fact]
    public void ViewProject_ShouldReturnStatusCode400_WhenServiceThrowsException()
    {
        // Arrange
        _departmentService.Setup(departmentService => departmentService.ViewProjects()).Throws<Exception>();
        // Act
        var Result = _projectController.ViewProjects() as ObjectResult;
        //Assert
        Assert.Equal(500, Result.StatusCode);
    }


    
}
