using System;
public class Employee
{

};

public class EmployeeServices
{

    //For Employee Entity
    public void CreateEmployee(Employee employee);
    public void DeleteEmployee(int employeeId);
    public void Login(Employee employee);
    public Employee ViewProfile(int employeeId);
};