using System;

class Pool
{
    
}
public class PoolServices
{
    public bool CreatePool(Pool pool);
    public bool EditPool(Pool pool);
    public bool RemovePool(int poolId);
    public List<Pool> ViewPools(int departmentId);
}

//PoolMembers
public class PoolMembers
{
    public bool CreatePool(Employee employeeId);
    public bool RemovePool(int employeeId);
    public List<Employee> ViewMembers(int departmentId, int employeeId);

}