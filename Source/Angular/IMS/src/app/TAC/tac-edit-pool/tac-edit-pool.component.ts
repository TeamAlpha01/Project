import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ConnectionService } from 'src/app/Services/connection.service';

@Component({
  selector: 'app-tac-edit-pool',
  templateUrl: './tac-edit-pool.component.html',
  styleUrls: ['./tac-edit-pool.component.css']
})
export class TacEditPoolComponent implements OnInit {
  title = 'Edit Pool'
  data: any;
  response: string = '';
  poolId: any;
  


  constructor(private connection: ConnectionService, private fb: FormBuilder, private route:ActivatedRoute) { }
  submitted: boolean = false;
  AddPoolForm = this.fb.group({
    poolName: ['', [Validators.required, Validators.minLength(3), Validators.pattern('[A-Za-z\\s]*')]],
    departmentId: ['', [Validators.required]]
  });
 

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.poolId = params['poolId']});
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
