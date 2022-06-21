import { Component, OnInit } from '@angular/core';
import { Project } from 'src/app/Model/Project';
import { Department } from 'src/app/Model/Department';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { ConnectionService } from 'src/app/Services/connection.service';

@Component({
  selector: 'app-admin-addproject',
  templateUrl: './admin-addproject.component.html',
  styleUrls: ['./admin-addproject.component.css']
})

export class AdminAddprojectComponent implements OnInit {
 title ='Manage Project'
 data:any;
 _department = '';
 _project = '';
 Department:any;
 ProjectName:string='';
 projectValue:Project[]=[];
 departmentValue:Department[]=[];
 ProjectId:number=0;
 DepartmentValue:number=0;

//   project: any={
//    departmentName :this._department,
//    projectName : this._project,
   
//  }
  constructor(private connection:ConnectionService, private http: HttpClient) { }
  
  addProject(){
    var projectDetails:any={
      "projectId":0,
      "projectName":this.ProjectName,
      "departmentId":this.DepartmentValue,
    };
    const headers={'constant-type':'application/json'}
    console.log(projectDetails);
    this.http.post<any>(`https://localhost:7072/Project/AddNewProject?departmentId=1&projectName=${this,this._project}`,this._project)
    .subscribe((data) => {
    console.log(data)
    }
    )
  }

  ngOnInit(): void {
    this.connection.GetDepartments().subscribe((data: any) => {
      this.departmentValue = data;
      console.log(this.departmentValue)
    })
  }

  
  //department: string[] = ['dotnet', 'java', 'lamp']

}

