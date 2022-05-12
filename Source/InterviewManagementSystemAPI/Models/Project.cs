using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace IMS.Models
{
    public class Project
    {
         public Project()
        {
           
            EmployeesUnderProject = new HashSet<Employee>();
        }
     [Key]
     public int ProjectId{get; set;}
     public string ProjectName {get;set;}
     public bool IsActive { get; set; } = true;
     public int  DepartmentId{get;set;}


     [ForeignKey("DepartmentId")]
     [InverseProperty("Projects")]
     public virtual Department? department { get; set; }

     [InverseProperty("Project")] 
     public ICollection<Employee> EmployeesUnderProject { get; set; }
     
    }
}