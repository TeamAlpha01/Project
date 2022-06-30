using System.Collections.Generic;
using IMS.Models;

namespace UnitTesting.MockData
{
    public static class DepartmentMock
    {
        public static List<Department>  ListOfDepartments()
        {
            List<Department> departmentMock=new List<Department>();
            departmentMock.Add(new Department{DepartmentName="Java"});
            departmentMock.Add(new Department{DepartmentName="Oracle"});
            departmentMock.Add(new Department{DepartmentName="LAMP"});
            return departmentMock;
        }
    }
}