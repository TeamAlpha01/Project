using IMS.Models;
using IMS.DataAccessLayer;
using IMS.Validations;
using IMS.DataFactory;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace IMS.Service
{
    public class TokenService : ITokenService
    {
        private IEmployeeDataAccessLayer _employeeDataAccessLayer;
        private ILogger<TokenService> _logger;
        private IConfiguration _configuration;

        public TokenService(ILogger<TokenService> logger, IConfiguration configuration, IEmployeeDataAccessLayer employeeDataAccessLayer)
        {
            _logger = logger;
            _configuration = configuration;
            _employeeDataAccessLayer = employeeDataAccessLayer;// DataFactory.EmployeeDataFactory.GetEmployeeDataAccessLayerObject(logger);
        }

        public object AuthToken(string employeeAceNumber, string password)
        {
            try
            {
                var user = _employeeDataAccessLayer.CheckLoginCrendentials(employeeAceNumber, password);

                var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("ACE Number",user.EmployeeAceNumber),
                        new Claim("UserId", user.EmployeeId.ToString()),
                        new Claim(ClaimTypes.Role,user.RoleId.ToString()),
                    };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                        claims,
                    expires: DateTime.UtcNow.AddHours(6),
                    signingCredentials: signIn);

                var Result = new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    ExpiryInMinutes = 360,
                    IsAdmin = user.RoleId == 10 ? true : false,
                    IsTAC = user.RoleId == 9 ? true : false,
                    IsManagement=user.RoleId == 11 ? true : false
                };

                return Result;

            }
            catch (ValidationException loginCredentialsNotValid)
            {
                _logger.LogInformation($"Employee DAL : CheckLoginCredentails throwed an exception : {loginCredentialsNotValid.Message}");
                throw loginCredentialsNotValid;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Employee DAL : CheckLoginCredentails throwed an exception : {exception.Message}");
                throw exception;
            }
        }

    }
}