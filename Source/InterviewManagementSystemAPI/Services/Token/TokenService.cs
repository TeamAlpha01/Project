using IMS.Models;
using IMS.DataAccessLayer;
using IMS.Validations;
using IMS.DataFactory;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

// namespace IMS.Service
// {
//     public class TokenService : ITokenService
//     {
//         private ITokenDataAccessLayer _tokenDataAccessLayer;


//         public bool AuthToken(string employeeAceNumber, string password)
//         {
//             try
//             {
//                 return _employeeDataAccessLayer.CheckLoginCrendentials(employeeAceNumber, password) ? true : false;

//             }
//             catch (Exception exception)
//             {
//                 _logger.LogInformation($"Employee DAL : CheckLoginCredentails throwed an exception : {exception.Message}");
//                 throw exception;
//             }
//         }

//     }
// }