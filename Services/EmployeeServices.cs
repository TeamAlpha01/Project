using System;
public class Employee
{

};

public class EmployeeServices
{

    //For Employee Entity
    public bool CreateEmployee(Employee employee);
    public bool DeleteEmployee(int employeeId);
    public bool Login(Employee employee);
    public Employee ViewProfile(int employeeId);
};