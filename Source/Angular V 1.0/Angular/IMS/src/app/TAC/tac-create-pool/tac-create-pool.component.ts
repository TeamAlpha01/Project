import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ConnectionService } from 'src/app/Services/connection.service';

@Component({
  selector: 'app-tac-create-pool',
  templateUrl: './tac-create-pool.component.html',
  styleUrls: ['./tac-create-pool.component.css']
})

export class TacCreatePoolComponent implements OnInit {
  title = 'Add Pool' //This gives the title for the page
  data: any;

  //To get HTTP responses
  response: string = '';
  error: any;

  constructor(private connection: ConnectionService, private fb: FormBuilder) { }
  submitted: boolean = false;
  AddPoolForm = this.fb.group({
    poolName: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(25), Validators.pattern('[A-Za-z\\s]*')]],
    departmentId: ['', [Validators.required]]
  });

  ngOnInit(): void {
    this.GetDepartments();
  }
  GetDepartments() {
    this.connection.GetDepartments().subscribe((data: any) => {
      this.data = data;
    })
  }
  getpoolName() {
    return this.AddPoolForm.get('poolName')?.value;
  }
  getdepartmentId() {
    return this.AddPoolForm.get('departmentId')?.value;
  }
  addPool() {
    this.submitted = true;
    this.error = '';
    if (this.AddPoolForm.valid) {
      this.connection.AddPool(this.getpoolName(), this.getdepartmentId()).subscribe({
        next: (data) => this.response = data.message,
        error: (error) => this.error = error.error.message,
        complete: () => this.clearInputFields(),
      })
    };
  }

  //This method clears the input fields and triggers snackbar
  clearInputFields() {
    this.submitted = false;
    setTimeout(() => {
      this.response = '';
      this.AddPoolForm.reset();
    }, 2000);

  }
}


