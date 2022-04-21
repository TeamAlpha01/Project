using System;
public class Pool{

}


public class PoolServices{
    public void CreatePool(Pool pool);
    public void EditPool(int poolId);
    public void RemovePool(int poolId);
    public List<Pool> ViewPool(int departmentId);
}