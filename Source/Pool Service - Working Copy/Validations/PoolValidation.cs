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
                throw new ArgumentNullException("Pool can't be empty");
             if(poolName.Length < 2 && poolName.Length > 20 ) throw new ValidationException("Pool name must be greater than 2 and less than 20"); 
              if(departmentId==""|| poolName=="")    throw new ArgumentException("PoolId or PoolName cannot be empty");   


        }
        public static void IsRemovePoolValid(int poolId)
        {
           if ( poolId == 0)
                throw new ArgumentNullException("Pool Id or Department Id cannot be null");  
            if(poolId=="") throw new ArgumentException("PoolId cannot be empty");     
        }
        public static void IsEditPoolValid(int poolId,string poolName )
        {
             if(poolId == 0 || poolName == null)
                throw new ArgumentNullException("PoolId or PoolName cannot be null");
            if(poolId==""|| poolName=="")    throw new ArgumentException("PoolId or PoolName cannot be empty");
        }
        public static void IsValidPoolMember(int employeeId,int poolId)
        {
            if (employeeId == 0 || poolId == 0)
                throw new ArgumentNullException("EmployeeId or PoolId  cannot be null");
            if (employeeId=="" || poolId=="") throw new ArgumentException("EmployeeId or PoolId cannot be empty");    


        }

    }
}

