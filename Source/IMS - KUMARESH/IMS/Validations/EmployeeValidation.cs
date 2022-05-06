using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using IMS.Model;

namespace IMS.Validations
{
    public static class EmployeeValidation
    {
        public static void IsEmployeeValid(Employee employee)
        {
            // if (employee == null) throw new ValidationException("Employee object cannot be null");
            // if (employee.EmployeeName.Length <= 2 && employee.EmployeeName.Length >= 30) throw new ValidationException("Employee name is too short or too big");
            // if (employee.EmployeeAceNumber.Length != 7) throw new ValidationException("Enter correct ACE number");
            // if (!Regex.IsMatch(employee.EmployeeAceNumber.Substring(0,3),"[a-zA-Z]")) throw new ValidationException("1st 3 char of EmployeeAceNumber cannot contain symbols or numbers");
            // if (!Regex.IsMatch(employee.EmployeeAceNumber.Substring(3,employee.EmployeeAceNumber.Length),"[1-9]")) throw new ValidationException("last 4 char of EmployeeAceNumber cannot contain symbols or Alphabets");
            // if (!Regex.IsMatch(employee.EmailId,@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")) throw new ValidationException ("Email Wrong Please enter valid email");
        }
    }
}                                                        
