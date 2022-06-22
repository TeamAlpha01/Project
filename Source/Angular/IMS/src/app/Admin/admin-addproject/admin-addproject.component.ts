import { Component, OnInit } from '@angular/core';
import { ConnectionService } from 'src/app/Services/connection.service';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-admin-addproject',
  templateUrl: './admin-addproject.component.html',
  styleUrls: ['./admin-addproject.component.css']
})

export class AdminAddprojectComponent implements OnInit {
 title ='Add Project'
 data:any;
 response:string='';


  constructor(private connection:ConnectionService, private fb: FormBuilder) { }
  submitted:boolean=false;
  AddProjectForm = this.fb.group({
    projectName :['',[Validators.required,Validators.minLength(3),Validators.pattern('[A-Za-z\\s]*')]],
    departmentId :['',[Validators.required]]
  });
  getProjectName(){
    return this.AddProjectForm.get('projectName')
  }
  getdepartmentId(){
    return this.AddProjectForm.get('departmentId')
  }
  
  ngOnInit(): void {
    this.GetDepartments();
  }
  GetDepartments(){
    this.connection.GetDepartments().subscribe((data: any) => {
      this.data = data;
    })
  }
  addProject(){
    this.submitted=true
    if(this.AddProjectForm.valid)
    {
      console.log(true)
      this.connection.AddProject(this.getProjectName()?.value,this.getdepartmentId()?.value).subscribe((data)=>this.response = data.message);
      setTimeout(()=>{this.response = '';this.AddProjectForm.reset()}, 1000);
      this.submitted=false;
    }
  }

}

