import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Department } from 'src/app/Model/Department';
import { ConnectionService } from 'src/app/Services/connection.service';

@Component({
  selector: 'app-admin-adddepartment',
  templateUrl: './admin-adddepartment.component.html',
  styleUrls: ['./admin-adddepartment.component.css'],
})
export class AdminAdddepartmentComponent implements OnInit {
  title = 'Add Department';
  response: string = '';
  submitted: boolean = false;

  constructor(private service: ConnectionService, private fb: FormBuilder) {}

  AddDepartmentForm = this.fb.group({
    departmentName: [
      '',
      [
        Validators.required,
        Validators.minLength(3),
        Validators.pattern('[A-Za-z\\s]*'),
      ],
    ],
  });

  getDepartmentName() {
    return this.AddDepartmentForm.get('departmentName');
  }

  addDepartment() {
    //this.http.post<any>(`https://localhost:7072/Deparment/CreateNewDeparment?departmentName=${this._department}`,this._department)
    this.submitted = true;

    if (this.getDepartmentName()?.valid) 
    {
      this.service
        .AddDepartment(this.getDepartmentName()?.value)
        .subscribe((data) => {
          this.response = data.message;
        });
      setTimeout(() => {
        this.response = '';
        this.AddDepartmentForm.reset();
      }, 1000);
      this.submitted = false;
    }
  }

  ngOnInit(): void {}
}
