import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ConnectionService } from 'src/app/Services/connection.service';

@Component({
  selector: 'app-admin-adddepartment',
  templateUrl: './admin-adddepartment.component.html',
  styleUrls: ['./admin-adddepartment.component.css'],
})
export class AdminAdddepartmentComponent implements OnInit {
  title = 'Add Department';
  
  //HTTP  RESPONSE
  response: string = '';  
  error: string = '';
  submitted: boolean = false;

  constructor(private service: ConnectionService, private fb: FormBuilder) { }
  
  ngOnInit(): void { }

  AddDepartmentForm = this.fb.group({
    //VALIDATE THE INPUT
    departmentName: [
      '',
      [
        Validators.required,
        Validators.minLength(3),
        Validators.maxLength(15),
        Validators.pattern("^(?!.*([ ])\\1)(?!.*([A-Za-z])\\2{2})\\w[a-zA-Z\\s]*$"),
      ],
    ],
  });

  getDepartmentName() {
    return this.AddDepartmentForm.get('departmentName')?.value;
  }

  addDepartment() {
    this.submitted = true;
    this.error = '';
    const department={
      departmentId:0,
      departmentName:this.getDepartmentName()?.value
    }

    if (this.AddDepartmentForm.valid) {
      this.service.AddDepartment(department).subscribe({
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
      this.AddDepartmentForm.reset();
    }, 2000);

  }
}
