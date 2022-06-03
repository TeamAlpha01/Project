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
public class PoolControllerTest
{
private readonly PoolController _poolController;
private readonly Mock<ILogger<PoolController>> _logger = new Mock<ILogger<PoolController>>();
    private readonly Mock<IPoolService> _roleService = new Mock<IPoolService>();
    public PoolControllerTest()
    {
        _poolController = new RoleController(_logger.Object, _poolService.Object);
    }

}
