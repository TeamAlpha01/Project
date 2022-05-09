using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using IMS.Models;

namespace IMS.Validations
{
    public static class RoleValidation
    {
        public static bool IsRoleValid(string roleName)
        {
            if(roleName==null) throw new ValidationException("role name cannot be null");
            if(roleName.Length<2) throw new ValidationException("role name is too short");
            if(!Regex.IsMatch(roleName,@"^[a-zA-Z]$")) throw new ValidationException("role name cannot contain symbols or numbers");
            return true;
        }
    }
}