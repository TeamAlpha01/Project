using System;


public class PoolServices
{
    public void CreatePool(Pool pool);
    public void EditPool(int poolId);
    public void RemovePool(int poolId);
    public List<Pool> ViewPool(int departmentId);
}

public class PoolMembersServices
{
    public void CreatePool(Employee employeeId);
    public void RemovePool(int employeeId);
    public List<Employee> ViewMembers(int departmentId, int employeeId);

}