using System;
public class Project{

}

public class ProjectServices{

    public void CreateProject(Project project);
    public void RemoveProject(int projectId);
    public List<Project> ViewProjects(int departmentId);
}