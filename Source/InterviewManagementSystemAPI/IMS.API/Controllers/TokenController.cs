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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeeMail"></param>
        /// <param name="password"></param>
        /// <returns></returns>

        [HttpPost("Login")]
        public IActionResult AuthToken(string employeeMail, string password)
        {
            if(employeeMail==null && password==null)
                return BadRequest("Mail Id and Password cannot be null");
            try
            {
                var Result = _tokenService.AuthToken(employeeMail, password);                
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