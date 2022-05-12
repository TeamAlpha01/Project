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
 _department = '';
 _project = '';

  project: any={
   departmentName :this._department,
   projectName : this._project,
   
 }
  constructor(private connectionService:ConnectionService) { }
  addProject(){
    console.log(this.project)
  }
  ngOnInit(): void {
  }
  
  department: string[] = ['dotnet', 'java', 'lamp']

}

