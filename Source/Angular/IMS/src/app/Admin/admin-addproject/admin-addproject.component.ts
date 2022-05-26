import { Component, OnInit } from '@angular/core';
import { Project } from 'src/app/Model/Project';
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

  project: any={
   departmentName :this._department,
   projectName : this._project,
   
 }
  constructor(private connection:ConnectionService, private http: HttpClient) { }
  
  addProject(){
    const headers={'constant-type':'application/json'}
    console.log(this.project)
    this.http.post<any>(`https://localhost:7072/Project/AddNewProject?projectName=${this._project}`,this._project)
    .subscribe((data) => {
    console.log(data)
    }
    )
  }

  ngOnInit(): void {
    this.connection.GetDepartments().subscribe((data: any) => {
      this.data = data;
      console.log(this.data)
    })
  }

  
  department: string[] = ['dotnet', 'java', 'lamp']

}

