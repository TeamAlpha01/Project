using System;
public class Department
{

}

public class DepartmentServices
{

    public bool CreateDepartment(Department department);
    public List<Department> ViewDepartments();
    public bool RemoveDepartment(int departmentId);

    public bool CreateProject(Project project);
    public bool RemoveProject(int projectId);
    public List<Project> ViewProjects(int departmentId);

}