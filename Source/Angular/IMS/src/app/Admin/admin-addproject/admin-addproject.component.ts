import { Component, OnInit } from '@angular/core';
import { ConnectionService } from 'src/app/Services/connection.service';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-admin-addproject',
  templateUrl: './admin-addproject.component.html',
  styleUrls: ['./admin-addproject.component.css']
})

export class AdminAddprojectComponent implements OnInit {
  title = 'Add Project'
  data: any;
  //HTTP RESPONSE
  response: string = '';
  error: string = '';


  constructor(private connection: ConnectionService, private fb: FormBuilder) { }
  submitted: boolean = false;
  AddProjectForm = this.fb.group({
    projectName: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(15), Validators.pattern('[A-Za-z\\s]*')]],
    departmentId: ['', [Validators.required]]
  });
  getProjectName() {
    return this.AddProjectForm.get('projectName')
  }
  getdepartmentId() {
    return this.AddProjectForm.get('departmentId')
  }

  ngOnInit(): void {
    this.GetDepartments();
  }
  GetDepartments() {
    this.connection.GetDepartments().subscribe((data: any) => {
      this.data = data;
    })
  }
  addProject() {
    this.submitted = true;
    this.error = '';

    if (this.AddProjectForm.valid) {
      //POST METHOD CALLED AT CONNECTION SERVICE
      this.connection.AddProject(this.getProjectName()?.value, this.getdepartmentId()?.value).subscribe({
        next: (data) => this.response = data.message,
        error: (error) => this.error = error.error.message,
        complete: () => this.clearInputFields(),
      });
    }
  }


  //RESET AFTER SUBMIT                                                                                      
  clearInputFields() {

    this.submitted = false;
    setTimeout(() => {
      this.response = '';
      this.AddProjectForm.reset();
    }, 1000);

  }

}

