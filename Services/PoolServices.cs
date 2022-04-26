using System;

public class Pool
{

}
public class PoolMembers { }
public class PoolServices
{
    public bool CreatePool(string poolName,string poolDepartment);
    public bool EditPool(Pool pool);
    public bool RemovePool(int poolId);
    public List<Pool> ViewPools(int departmentId);
    //PoolMembers
    public bool CreatePool(Employee employeeId);
    public bool RemovePool(int employeeId);
    public List<Employee> ViewMembers(int departmentId, int employeeId);
}


