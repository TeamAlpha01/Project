using System.Collections.Generic;
using IMS.Models;

namespace UnitTesting.MockData
{
    public static class ProjectMock
    {
        public static List<Project> ListOfProjects()
        {
            List<Project> mockProject= new List<Project>();
            mockProject.Add( new Project { ProjectId = 1, ProjectName = "IMS_NET", DepartmentId = 1 });
            mockProject.Add( new Project { ProjectId = 2, ProjectName = "IMS_JAVA", DepartmentId = 2 });
            mockProject.Add( new Project { ProjectId = 3, ProjectName = "IMS_ORACLE", DepartmentId = 3 });
            return mockProject;
        } 
        public static Project CreateValidProject()
        {
            return new Project()
            {
                ProjectName="IMS_NET",
                DepartmentId=1,
                IsActive=true
            };
        }

        }
    }

     