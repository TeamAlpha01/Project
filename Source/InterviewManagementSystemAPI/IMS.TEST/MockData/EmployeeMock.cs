using System.Collections.Generic;
using IMS.Models;

namespace UnitTesting.MockData
{
    public static class EmployeeMock
    {
        public static List<Employee> GetEmployeesMock()
        {
            List<Employee> mockEmployee = new List<Employee>();
            mockEmployee.Add(new Employee { EmployeeId = 1, Name = "Prithvi", DepartmentId = 1, EmailId = "prithvi@gmail.com", EmployeeAceNumber = "ACE0001", Password = "Pass@12345", ProjectId = 1, RoleId = 1 });
            mockEmployee.Add(new Employee { EmployeeId = 2, Name = "Vinoth", DepartmentId = 1, EmailId = "vinoth@gmail.com", EmployeeAceNumber = "ACE0002", Password = "Pass@12345", ProjectId = 1, RoleId = 2 });
            mockEmployee.Add(new Employee { EmployeeId = 3, Name = "Sheik", DepartmentId = 1, EmailId = "Sheik@gmail.com", EmployeeAceNumber = "ACE0003", Password = "Pass@12345", ProjectId = 1, RoleId = 3 });
            mockEmployee.Add(new Employee { EmployeeId = 4, Name = "Darshana", DepartmentId = 2, EmailId = "darshana@gmail.com", EmployeeAceNumber = "ACE0004", Password = "Pass@12345", ProjectId = 2, RoleId = 1 });
            mockEmployee.Add(new Employee { EmployeeId = 5, Name = "Aravind", DepartmentId = 2, EmailId = "aravind@gmail.com", EmployeeAceNumber = "ACE0005", Password = "Pass@12345", ProjectId = 2, RoleId = 2 });
            mockEmployee.Add(new Employee { EmployeeId = 6, Name = "Kumaresh", DepartmentId = 2, EmailId = "kumaresh@gmail.com", EmployeeAceNumber = "ACE0006", Password = "Pass@12345", ProjectId = 2, RoleId = 3 });
            mockEmployee.Add(new Employee { EmployeeId = 7, Name = "Gokul", DepartmentId = 3, EmailId = "gokul@gmail.com", EmployeeAceNumber = "ACE0007", Password = "Pass@12345", ProjectId = 3, RoleId = 1 });
            mockEmployee.Add(new Employee { EmployeeId = 8, Name = "Deepika", DepartmentId = 3, EmailId = "deepika@gmail.com", EmployeeAceNumber = "ACE0008", Password = "Pass@12345", ProjectId = 3, RoleId = 2 });
            mockEmployee.Add(new Employee { EmployeeId = 9, Name = "Remuki", DepartmentId = 3, EmailId = "remuki@gmail.com", EmployeeAceNumber = "ACE0009", Password = "Pass@12345", ProjectId = 3, RoleId = 3 });
            mockEmployee.Add(new Employee { EmployeeId = 10, Name = "Vishnu", DepartmentId = 4, EmailId = "vishnu@gmail.com", EmployeeAceNumber = "ACE0010", Password = "Pass@12345", ProjectId = 4, RoleId = 9 });
            mockEmployee.Add(new Employee { EmployeeId = 11, Name = "Sandhiya", DepartmentId = 4, EmailId = "sandhiya@gmail.com", EmployeeAceNumber = "ACE0011", Password = "Pass@12345", ProjectId = 4, RoleId = 9 });
            mockEmployee.Add(new Employee { EmployeeId = 12, Name = "Mani", DepartmentId = 4, EmailId = "mani@gmail.com", EmployeeAceNumber = "ACE0012", Password = "Pass@12345", ProjectId = 4, RoleId = 10 });
            return mockEmployee;
        } 
    }
}