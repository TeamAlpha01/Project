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


public class ProjectTestController
{
    private readonly ProjectController _projectController;
    private readonly Mock<ILogger<ProjectController>> _logger =new Mock<ILogger<ProjectController>>();
    private readonly Mock<IDepartmentService> _departmentService =new Mock<IDepartmentService>();

    public ProjectTestController()
    {
        _projectController=new ProjectController(_logger.Object,_departmentService.Object);

    }

    
}
