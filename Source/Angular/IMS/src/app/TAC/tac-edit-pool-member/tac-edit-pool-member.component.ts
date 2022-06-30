  import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { data } from 'jquery';

import { ConnectionService } from 'src/app/Services/connection.service';

@Component({
  selector: 'app-tac-edit-pool-member',
  templateUrl: './tac-edit-pool-member.component.html',
  styleUrls: ['./tac-edit-pool-member.component.css']
})
export class TacEditPoolMemberComponent implements OnInit {

  title = 'Current Drive'

  //To get the inputs from the user
  _dept = '';
  _pool = '';
  _role = '';
  _search = '';

  //To get the details from the db
  roleDetails: any;
  poolDetails: any;
  poolMembers: any;
  departmentDetails: any;
  employeeDetails: any;
  pool: any;
  poolEnabler: boolean = true;
  response: string='';
  error: any;
  poolId: number = 0;

  constructor(private connection: ConnectionService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.poolId = params['poolId']
    })
    this.GetRoles();
    this.GetPools();
    this.GetEmployees();
    this.PoolMember();    
  }
  GetRoles() {
    this.connection.GetRoles().subscribe((data: any) => {
      this.roleDetails = data;
    })
  }

  GetPools() {
    this.connection.GetPools().subscribe((data: any) => {
      this.poolDetails = data;
      for (let item of this.poolDetails) {
        if (this.poolId == item.poolId) {
          this._pool = item.poolName;
          this._dept = item.departmentName;
        }
      }
    })
  }

  GetEmployees() {
    this.connection.GetEmployees().subscribe((data: any) => {
      this.employeeDetails = data;
    })
    
  }

  PoolMember() {
    this.connection.GetPoolMembers(this.poolId).subscribe((data: any) => {
      this.poolMembers = data;
    })
  }

  AddPoolMember(employeeId: number) {
    this.response=''
    this.connection.AddPoolMember(employeeId, this.poolId).subscribe({
      next: (data) => {
        this.response = data.message
        this.PoolMember()
      },
      error: (error) => {
        this.error = error.error.message;
        setTimeout(() => { this.error = ''}, 2000);
      },
      //complete: () => this.clearFields(),
    });
    
  }
  
  RemovePoolMember(poolMemberId: number) {
    this.response=''
    this.connection.RemovePoolMember(poolMemberId).subscribe({
      next: (data) => {
        this.response = data.message;
        this.PoolMember()
      },
      error: (error) => {
        this.error = error.error.message;
      },
      //complete: () => thiindex.es.PoolMember(),
    });
    

  }

  clearFields() {

    if (this.error.length == 0) {
      setTimeout(() => {
        this.response = '';
      }, 2000);
    }
  }

}
