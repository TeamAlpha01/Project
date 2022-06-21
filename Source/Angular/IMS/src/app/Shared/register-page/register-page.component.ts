import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { ConnectionService } from 'src/app/Services/connection.service';

@Component({
  selector: 'app-register-page',
  templateUrl: './register-page.component.html',
  styleUrls: ['./register-page.component.css']
})
export class RegisterPageComponent implements OnInit {
  formSubmitted: boolean = false;
  departmentDetails: any;
  roleDetails:any;
  projectDetails: any;
  _dept='';


  registerForm = this.FB.group({
    Name: ['', [Validators.required, Validators.maxLength(20), Validators.pattern("^[A-Za-z ]+$")]],
    ACENumber: ['', [Validators.required]],
    Department: ['', [Validators.required, Validators.pattern('[a-zA-Z][*@#.]*')]],
    Role: ['', [Validators.required, Validators.pattern('[a-zA-Z]*')]],
    Project: ['', [Validators.required, Validators.pattern('[a-zA-Z][20]*')]],
    Email: ['', [Validators.required, Validators.pattern("([a-zA-Z0-9-_\.]+)@(aspiresys.com)")]],
    Password: ['', [Validators.required, Validators.pattern('')]],
    ConfirmPassword: ['', [Validators.required, Validators.pattern('')]]


  });

  constructor(private FB: FormBuilder, private connection:ConnectionService) { }

  ngOnInit(): void {
    this.connection.GetDepartments().subscribe((data: any) => {
      this.departmentDetails = data;
    })
    this.connection.GetRoles().subscribe((data: any) => {
      this.roleDetails = data;
    })
    this.connection.GetProjects().subscribe((data: any) => {
      this.projectDetails = data;
    })
  }

  submit(){
   const user={
    employeeId: 0,
    employeeAceNumber: this.registerForm.value['ACENumber'],
    name: this.registerForm.value['Name'],
    departmentId: this.registerForm.value['Department'],
    roleId: this.registerForm.value['Role'],
    projectId: this.registerForm.value['Project'],
    emailId: this.registerForm.value['Email'],
    password: this.registerForm.value['Password'],
   }
    console.log(user);
    this.connection.CreateEmployee(user)
  }
}
