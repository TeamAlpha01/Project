using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using IMS.Model;

namespace IMS.Validations
{
    public static class EmployeeValidation
    {
        public static void IsEmployeeValid(Employee employee)
        {
            if (employee == null) throw new ValidationException("Employee object cannot be null");

            if (String.IsNullOrEmpty(employee.EmployeeName))
            {
                throw new ValidationException("Employee Name cannot be null");
            }
            if(!Regex.IsMatch(employee.EmployeeName,@"^[a-zA-Z]{3,30}$")) throw new ValidationException("Employee Name must contain only alphabets and lenght of the name should be 3 to 30 char");

            // if (employee.EmployeeAceNumber == null) 
            // {
            //     throw new ValidationException("Employee ACE Number cannot be null");

            // }
            // else if(employee.EmployeeAceNumber.Length != 7)
            // {
            //     throw new ValidationException("Enter correct ACE number");
            // }

            // if (employee.EmailId == null) throw new ValidationException("EmailId cannot be null");

            // if (employee.Password == null) throw new ValidationException("Password cannot be null");      

            // if (!Regex.IsMatch(employee.EmployeeAceNumber.Substring(0,3),"[a-zA-Z]")) throw new ValidationException("1st 3 char of EmployeeAceNumber cannot contain symbols or numbers");

            // if (!Regex.IsMatch(employee.EmployeeAceNumber.Substring(3,employee.EmployeeAceNumber.Length),"[1-9]")) throw new ValidationException("last 4 char of EmployeeAceNumber cannot contain symbols or Alphabets");

            // if (!Regex.IsMatch(employee.EmailId,@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")) throw new ValidationException ("Email Wrong Please enter valid email");
        }
    }
}                                                        
