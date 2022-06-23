import { Component, OnInit } from '@angular/core';
import { ConnectionService } from 'src/app/Services/connection.service';

@Component({
  selector: 'app-tac-edit-pool-member',
  templateUrl: './tac-edit-pool-member.component.html',
  styleUrls: ['./tac-edit-pool-member.component.css']
})
export class TacEditPoolMemberComponent implements OnInit {
  title = 'Manage Pool Member'

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

  constructor(private connection: ConnectionService) { }

  ngOnInit(): void {
    this.GetRoles();
    this.GetPools();
    this.GetDepartment();
    this.GetEmployees();
  }
  GetRoles() {
    this.connection.GetRoles().subscribe((data: any) => {
      this.roleDetails = data;
      console.log(this.roleDetails)
    })
  }
  GetPools() {
    this.connection.GetPools().subscribe((data: any) => {
      this.poolDetails = data;
    })
  }
  GetDepartment() {
    this.connection.GetDepartments().subscribe((data: any) => {
      this.departmentDetails = data;
    })
  }
  GetEmployees() {
    this.connection.GetEmployees().subscribe((data: any) => {
      this.employeeDetails = data;
      console.warn(this.employeeDetails);
    })
  }

  poolMember() {
    for (let item of this.poolDetails) {
      if (this._pool == item.poolName) {
        this.pool = item.poolId;
      }
    }
    this.connection.GetPoolMembers(this.pool).subscribe((data: any) => {
      this.poolMembers = data;
    })
  }

}
