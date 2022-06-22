import { Component, OnInit } from '@angular/core';
import { ConnectionService } from 'src/app/Services/connection.service';

@Component({
  selector: 'app-tac-employee-dashboard',
  templateUrl: './tac-employee-dashboard.component.html',
  styleUrls: ['./tac-employee-dashboard.component.css']
})
export class TacEmployeeDashboardComponent implements OnInit {
  title = 'Employee Dashboard'

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
  employeeDashboardDetails: any;

  
  constructor(private connection: ConnectionService) { }

  ngOnInit(): void {
    this.connection.GetRoles().subscribe((data: any) => {
      this.roleDetails = data;
    })
    this.connection.GetPools().subscribe((data: any) => {
      this.poolDetails = data;
    })
    this.connection.GetDepartments().subscribe((data: any) => {
      this.departmentDetails = data;
    })
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

  

  GetEmployeeDashboard(employeeId: number) {
    this.connection.GetEmployeesDashboard(employeeId).subscribe((data: any) => {
      this.employeeDashboardDetails = data;
      console.log(this.employeeDashboardDetails);
    })
  }
}
