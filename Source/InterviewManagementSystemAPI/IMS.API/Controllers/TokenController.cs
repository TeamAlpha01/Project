using Microsoft.AspNetCore.Mvc;
using IMS.Service;
using System.ComponentModel.DataAnnotations;



namespace IMS.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TokenController : ControllerBase
    {
        private readonly ILogger<TokenController> _logger;

        private ITokenService _tokenService;
        public TokenController(TokenService tokenService, ILogger<TokenController> logger)
        {
            _logger = logger;
            _tokenService = tokenService;
        }

        [HttpPost("Login")]
        public IActionResult AuthToken(string employeeAceNumber, string password)
        {
            try
            {
                var Result = _tokenService.AuthToken(employeeAceNumber, password);                
                return Ok(Result);
            }
            catch (ValidationException validationException)
            {
                _logger.LogError($"Token Service : AuthToken() : {validationException.Message}");
                return BadRequest(validationException.Message);
            }
            catch (Exception exception)
            {
                _logger.LogError($"Token Service : AuthToken() : {exception.Message}");
                return Problem("Sorry some internal error occured");
            }
        }
    }
}