using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using IMS.Models;

namespace IMS.Validations
{
    public static class PoolValidation
    {
         public static void IsCreatePoolValid(int departmentId,string poolName)
        {
            if(departmentId <= 0)  throw new ValidationException("Department Id cannot be null or negative");
            if(poolName==null) throw new ValidationException("Pool name cannot be null");
            if (String.IsNullOrEmpty(poolName)) throw new ValidationException("Pool Name cannot be Empty or Null");
            if(poolName.Length<=2) throw new ValidationException("Pool Name is too short.It cannot be less than or equql to two");
            if(!Regex.IsMatch(poolName,@"^[a-zA-Z0-9. ]{3,25}$")) throw new ValidationException("Pool Name must contain only alphabets and of lenght 3 to 25");
            
        }
        public static void IsRemovePoolValid(int poolId)
        {
           if ( poolId<=0)
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
            if(!Regex.IsMatch(poolName , @"^[a-zA-Z0-9. ]{3,25}$")) 
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


