using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using IMS.Models;

namespace IMS.Validations
{
    public static class PoolValidation
    {
        public static void IsCreatePoolValid(int departmentId,string poolName)
        {
         
            if (departmentId == 0 || poolName == null  )
                throw new ValidationException("Pool can't be null");
           
            if (String.IsNullOrEmpty(poolName)) 
                throw new ValidationException("Pool Name cannot be null");
            if(!Regex.IsMatch(poolName , @"^[A-Za-z]{2,30}$")) 
                throw new ValidationException("Pool Name must contain only alphabets and length of the name should be 2 to 30 char");    
                


        }
        public static void IsRemovePoolValid(int poolId)
        {
           if ( poolId<0)
                throw new ValidationException("Pool Id cannot be negative value");  
           
        }
        public static void IsEditPoolValid(int poolId,string poolName )
        {
             if(poolId == 0 || poolName == null)
                throw new ValidationException("PoolId or PoolName cannot be null");
            if( poolName=="")    
                throw new ValidationException("PoolId or PoolName cannot be empty");
            if (String.IsNullOrEmpty(poolName)) 
                throw new ValidationException("Pool Name cannot be null");
            if(!Regex.IsMatch(poolName , @"^[A-Za-z]{2,30}$")) 
                throw new ValidationException("Pool Name must contain only alphabets and length of the name should be 2 to 30 char");    
                

        }
        public static void IsValidDepartmentId(int departmentId)
        {
            if(departmentId<=0) throw new ValidationException("Invalid Department Id");
          
        }
        public static void IsValidPoolMember(int employeeId,int poolId)
        {
            if (employeeId == 0 || poolId == 0)
                throw new ValidationException("EmployeeId or PoolId  cannot be null");
            

        }
        public static void IsAddPoolMemberValid(PoolMembers poolMembers)
        {
        if (poolMembers== null)
                throw new ValidationException("PoolMembers can't be empty");
        }
         public static void IsAddPoolMembersValid(int employeeId, int poolId)
        {
           if(employeeId<=0 || poolId<=0) 
                throw new ValidationException("EmployeeId or PoolId cannot be negative or Zero");
        }
        public static void IsRemovePoolMembersValid(int poolMemberId)
        {
          if(poolMemberId==0)
                throw new ValidationException("Pool Member Id cannot be null");
            

        }
        public static void IsValidPoolId(int poolId)
        {
              if(poolId==0)
                throw new ValidationException("Pool Member Id cannot be null");

        }
        public static void IsAddPoolValid(Pool pool)
        {
            if (pool == null)
                throw new ValidationException("Pool can't be empty");
        }
        public static void IsPoolIdValid(int poolId)
        {
            if(poolId<=0)
            throw new ValidationException("Pool Id cannot be negative or null");
        }
       

    }
}

// if (employee == null) throw new ValidationException("Employee object cannot be null");

          

           

//             if (String.IsNullOrEmpty(employee.EmployeeAceNumber)) throw new ValidationException("EmployeeACEnumber cannot be null");
            
//             else if (employee.EmployeeAceNumber.Length != 7) throw new ValidationException("ACE number must be 7 characters");

//             else if (employee.EmployeeAceNumber == "ACE0000") throw new ValidationException("Invalid ACE number");

//             else if (!Regex.IsMatch(employee.EmployeeAceNumber,@"^ACE[0-9]{4}$")) throw new ValidationException("Invalid ACE number");

//             if (String.IsNullOrEmpty(employee.EmailId)) throw new ValidationException("EmailId cannot be null");

//             else if (!Regex.IsMatch(employee.EmailId,@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z")) throw new ValidationException ("Email Wrong Please enter valid email");

//             if (String.IsNullOrEmpty(employee.Password)) throw new ValidationException("Password cannot be null"); 

//             else if (!Regex.IsMatch(employee.Password,@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$")) throw new ValidationException ("Password must be between 8 and 15 characters and atleast contain one uppercase letter, one lowercase letter, one digit and one special character.");            

//         }
//         public static void IsEmployeeId(int employeeId)
//         {
//             if (String.IsNullOrEmpty(employeeId)) throw new ValidationException("Employee Id cannot be null");
//             else if(employeeId < 0)  throw new ValidationException("Employee Id cannot be negative characters");
//         }
//     }
// }                                                        }

