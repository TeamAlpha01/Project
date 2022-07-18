using Microsoft.AspNetCore.Mvc;
using IMS.Service;
using IMS.Models;
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
        /// <param name="user"></param>
        /// <returns></returns>


        [HttpPost]
        public IActionResult Login(User user)
        {
            if (user.EmailId == null && user.EmailId == null)
                return BadRequest("Mail Id and Password cannot be null");
            try
            {
                var Result = _tokenService.AuthToken(user.EmailId, user.Password!);
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