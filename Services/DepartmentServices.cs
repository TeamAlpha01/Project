using System;
public class Department{

}

public class DepartmentServices{

    public void CreateDepartment(Department department);
    public List<Department> ViewDepartment();
    public void RemoveDepartment(int departmentId);

    public void CreateProject(Project project);
    public void RemoveProject(int projectId);
    public List<Project> ViewProjects(int departmentId);
    
}