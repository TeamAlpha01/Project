// using IMS.Models;
// using IMS.DataAccessLayer;
// using System.Linq;
// using System.ComponentModel.DataAnnotations;
// namespace IMS.Services
// {
//     public class PoolService:IPoolService
//     {
//         private IPoolDataAccessLayer _PoolDataAccessLayer = DataFactory.PoolDataFactory.GetPoolDataAccessLayerObject();
//         private Pool _Pool = DataFactory.PoolDataFactory.GetPoolObject();
//         private PoolMembers _PoolMembers = DataFactory.PoolDataFactory.GetPoolMembersObject();



//         /*  
//             Returns False when Exception occured in Data Access Layer
            
//             Throws ArgumentNullException when Pool Name is not passed to this service method
//         */
//         public bool CreatePool( int DepartmentId,string PoolName)
//         {
//             if (DepartmentId == 0 || PoolName == null  )
//                 throw new ArgumentNullException("Pool can't be empty");

//             try
//             {
//                 _Pool.PoolName = PoolName;
//                 _Pool.DepartmentId=DepartmentId;
//                 return _PoolDataAccessLayer.AddPoolToDatabase(_Pool) ? true : false; // LOG Error in DAL;
//             }
//             catch (Exception)
//             {
//                 // Log "Exception Occured in Data Access Layer"
//                 return false;
//             }
//         }

//         /*  
//             Returns False when Exception occured in Data Access Layer
            
//             Throws ArgumentNullException when Pool Id is not passed to this service method
//         */

//         public bool RemovePool(int DepartmentId,int PoolID)
//         {
//             if (DepartmentId == 0 || PoolID == 0)
//                 throw new ArgumentNullException("Pool Name or Department Name is not provided");

//             try
//             {
//                 return _PoolDataAccessLayer.RemovePoolFromDatabase(DepartmentId,PoolID) ? true :false; // LOG Error in DAL;
//             }
//             catch (Exception)
//             {
//                 // Log "Exception Occured in Data Access Layer"
//                 return false;
//             }
//         }
//         public bool EditPool(int PoolId,string PoolName)
//         {
//             if(PoolId==0 || PoolName== null)
//                 throw new ArgumentNullException("Pool nmae is not provided");

//              try
//              {
//                  return _PoolDataAccessLayer.EditPoolFromDatabase(PoolId,PoolName)?true:false;
//              } 
//              catch(Exception)
//              {
//                  return false;

//              }  

//         }

//         /*  
//             Throws Exception when Exception occured in DAL while fetching Pools
//         */
//         public IEnumerable<Pool> ViewPools(int DepartmentId)
//         {
//             try
//             {
//                 IEnumerable<Pool> Pools = new List<Pool>();
//                 return Pools = from Pool in _PoolDataAccessLayer.GetPoolsFromDatabase(DepartmentId) where Pool.IsActive == true select Pool;
//             }
//             catch (Exception)
//             {
//                 //Log "Exception occured in DAL while fetching Pools"
//                 throw new Exception();
//             }
//         }
    

//          public bool AddPoolMembers (int EmployeeId, int PoolId)
//         {
//             if (EmployeeId == 0 || PoolId == 0)
//                 throw new ArgumentNullException("PoolID is not provided");

//             try
//             {
//                 _PoolMembers.EmployeeId=EmployeeId;
//                 _PoolMembers.PoolId = PoolId;
//                 return _PoolDataAccessLayer.AddPoolMembersToDatabase(_PoolMembers) ? true : false; // LOG Error in DAL;
//             }
//             catch (Exception)
//             {
//                 // Log "Exception Occured in Data Access Layer"
//                 return false;
//             }
//         }

//             public bool RemovePoolMembers (int EmployeeID, int PoolId)
//         {
//             if (EmployeeID == 0 || PoolId == 0)
//                 throw new ArgumentNullException("PoolID is not provided");

//             try
//             {
                
//                 return _PoolDataAccessLayer.RemovePoolMembersFromDatabase(EmployeeID,PoolId) ? true : false; // LOG Error in DAL;
//             }
//             catch (Exception exception)
//             {
//                 // Log "Exception Occured in Data Access Layer"
//                 return false;
//             }
//         } 
//         public IEnumerable<PoolMembers> ViewPoolMembers(int PoolId)
//         {
//             try
//             {
//                 IEnumerable<PoolMembers> poolMembers = new List<PoolMembers>();
//                 return poolMembers = from PoolMembers in _PoolDataAccessLayer.GetPoolMembersFromDatabase(PoolId) where PoolMembers.IsActive == true select PoolMembers;
//             }
            
//             catch (Exception exception)
//             {
//                 //Log "Exception occured in DAL while fetching Pools"
//                 throw new Exception();
//             }
//         }



//     }
// }