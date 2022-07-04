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
    public class PoolTestService
    {
        private readonly PoolService _poolService;
        private readonly Mock<ILogger<PoolService>> _logger = new Mock<ILogger<PoolService>>();
        private readonly InterviewManagementSystemDbContext _db ;
        private readonly Mock<IPoolDataAccessLayer> _poolDataAccessLayer = new Mock<IPoolDataAccessLayer>();

        public PoolTestService()
        {
            _poolService = new PoolService(_logger.Object, _poolDataAccessLayer.Object);
        }

        [Theory]
        [InlineData(0,"#Freshers2022")]
        public void Createpool_ThrowsValidationException_WithInvalidCredintials(int departmentId, string poolName)
        {
            var Result = () => _poolService.CreatePool(departmentId,poolName);

            Result.Should().Throw<ValidationException>();
        }

        [Fact]
        public void Createpool_ReturnsTrue_WithValidpoolName()
        {            
            _poolDataAccessLayer.Setup(r=>r.AddPoolToDatabase(It.Is<Pool>(r=>r.PoolName == "Freshers"))).Returns(true);

            var Result = _poolService.CreatePool(1,"Freshers");
            Result.Should().BeTrue();
        }
        
        [Fact]
        public void Createpool_ReturnsFalse_WithValidpoolName()
        {            
            _poolDataAccessLayer.Setup(r=>r.AddPoolToDatabase(It.Is<Pool>(r=>r.PoolName == "Freshers"))).Returns(false);

            var Result = _poolService.CreatePool(1,"Freshers");
            Result.Should().BeFalse();
        }

        // [Theory]
        // [InlineData(0,"#Freshers2022")]
        // public void Createpool_ThrowsArgumentException_WithInvalidCredintials(int departmentId, string poolName)
        // {
        //     var Result = () => _poolService.CreatePool(departmentId,poolName);

        //     Result.Should().Throw<ArgumentException>();
        // }

        [Theory]
        [InlineData(0,"#Freshers2022")]
        [InlineData(1,"Freshers")]
        public void Createpool_ThrowsException_WithInvalidCredintials(int departmentId, string poolName)
        {
            var Result = () => _poolService.CreatePool(departmentId,poolName);

            Result.Should().Throw<Exception>();
        }

        [Theory]
        [InlineData(0,"#Freshers2022")]
        public void Createpool_Throws_departmentNotFound_WithInvalidCredintials(int departmentId, string poolName)
        {
            var Result = () => _poolService.CreatePool(departmentId,poolName);

            Result.Should().Throw<ValidationException>();
        }

        [Theory]
        [InlineData(0)]
        public void Removepool_ThrowsValidationException_WithInvalidCredintials(int poolId)
        {
            var Result = () => _poolService.RemovePool(poolId);

            Result.Should().Throw<ValidationException>();
        }

        // [Fact]
        // public void Removepool_ReturnsTrue_WithValidpoolName()
        // {            
        //     _poolDataAccessLayer.Setup(r=>r.RemovePoolFromDatabase(It.Is<Pool>(r=>r.PoolId == 1))).Returns(true);

        //     var Result = _poolService.CreatePool(1,"Freshers");
        //     Result.Should().BeTrue();
        // }
        
    }
}