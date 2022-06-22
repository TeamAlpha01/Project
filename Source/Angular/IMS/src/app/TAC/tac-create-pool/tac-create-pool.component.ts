import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ConnectionService } from 'src/app/Services/connection.service';

@Component({
  selector: 'app-tac-create-pool',
  templateUrl: './tac-create-pool.component.html',
  styleUrls: ['./tac-create-pool.component.css']
})
export class TacCreatePoolComponent implements OnInit {
  title = 'Add Pool'
  data: any;
  response: string = '';


  constructor(private connection: ConnectionService, private fb: FormBuilder) { }
  submitted: boolean = false;
  AddPoolForm = this.fb.group({
    poolName: ['', [Validators.required, Validators.minLength(3), Validators.pattern('[A-Za-z\\s]*')]],
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
    return this.AddPoolForm.get('poolName')
  }
  getdepartmentId() {
    return this.AddPoolForm.get('departmentId')
  }
  addPool() {
    this.submitted = true
    if (this.AddPoolForm.valid) {
      console.log(true)
      this.connection.AddPool(this.getpoolName()?.value, this.getdepartmentId()?.value).subscribe((data) => this.response = data.message);
      setTimeout(() => { this.response = ''; this.AddPoolForm.reset() }, 1000);
      this.submitted = false;
    }
  }

}
