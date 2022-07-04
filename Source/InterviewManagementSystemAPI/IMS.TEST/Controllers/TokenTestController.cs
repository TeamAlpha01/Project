using IMS.Service;
using System;
using FluentAssertions;
using IMS.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using UnitTesting.MockData;
using Xunit;

namespace UnitTesting.Controllers;
public class TokenControllerTest
{
    private readonly TokenController _tokenController;
    private readonly Mock<ILogger<TokenController>> _logger=new Mock<ILogger<TokenController>>();
   private readonly Mock<TokenService> _tokenService=new Mock<TokenService>();
    public TokenControllerTest()
    {
       _tokenController=new TokenController(_tokenService.Object,_logger.Object);

    }
    [Fact]
    public void AuthToken_ShouldReturnStatusCode_WithProperInput()
    {
        string employeeACENumber="ACE0001";
        string password="Pass@12345";
        _tokenService.Setup(a=>a.AuthToken(employeeACENumber,password)).Returns(new object());
        var Result=_tokenController.AuthToken(employeeACENumber,password)as ObjectResult;
        Result.StatusCode.Should().Be(200);
    }



}
