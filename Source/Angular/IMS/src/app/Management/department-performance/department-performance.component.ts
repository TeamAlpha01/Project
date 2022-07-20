import { Component, OnInit } from '@angular/core';
import { ConnectionService } from 'src/app/Services/connection.service';

@Component({
  selector: 'app-department-performance',
  templateUrl: './department-performance.component.html',
  styleUrls: ['./department-performance.component.css']
})
export class DepartmentPerformanceComponent implements OnInit {
  poolDetails: any;
  title = "Department Performance";

  driveList = 'driveName';

  _name = '';
  _drive = {
    driveId: 0,
    driveName: ''
  }
  _pool = ''
  _fromDate = ''
  _toDate = ''
  Drive: boolean = false
  Date: boolean = true

  page: number = 1;
  totalLength: any;
  driveResponse: any[] = [];
  employeesPerformance: any[] = [];
  driveDetails: any;
  departmentEmployees: any;
  driveId = 0;

  constructor(private connection: ConnectionService) { }

  ngOnInit(): void {
    this.GetPools();
    this.GetEmployeesPerformance();
    this.GetDrivesForCurrentUser();
  }

  GetPools() {
    this.connection.GetPools().subscribe({
      next: (data: any) => { this.poolDetails = data }
    })
  }

  // GetDepartmentEmployeesForCurrentUser() {
  //   this.connection.GetDepartmentEmployeesForCurrentUser().subscribe({
  //     next: (data: any) => { this.departmentEmployees = data, console.warn(this.departmentEmployees) }
  //   })
  // }

  GetDrivesForCurrentUser() {
    this.connection.GetDrivesForCurrentUser().subscribe({
      next: (data: any) => { this.driveDetails = data, console.warn(this.driveDetails) }
    })
  }

  GetDrives(driveId: number) {
    this.connection.GetDashboardDriveResponse(driveId).subscribe({
      next: (data: any) =>{ this.driveResponse = data,console.warn(this.driveResponse)},
    })
  }

  GetEmployeesPerformance() {
    const dataRange={From: this._fromDate,To:this._toDate}
    this.connection.GetEmployeePerformance(dataRange).subscribe({
      next: (data: any) => { this.employeesPerformance = data },
    })
  }

  drive() {
    this._fromDate = ''
    this._toDate = ''
    this._pool = ''
  }

  date() {
    this._pool = ''
    this._drive = { driveId: 0, driveName: '' }
  }

  pool() {
    this._drive = { driveId: 0, driveName: '' }
  }

  Apply() {
    console.warn("10")
    if (this._drive.driveName == undefined || this._drive.driveName == '') {
      this._drive = {
        driveId: 0,
        driveName: ''
      }
      if (this._drive.driveName == '') {
        console.warn("3");
        this.Drive = false;
        this.Date = true;
        this.GetEmployeesPerformance();
        if (this._pool != '') {
          this.Drive = false;
          this.Date = true;
          console.warn("1");
        }
        else if (this._fromDate != '' || this._toDate != '') {
          this.Drive = false;
          this.Date = true;
          const dateRange = {FromDate : this._fromDate,ToDate:this._toDate}
          this.connection.GetEmployeePerformance(dateRange);
          console.warn("5");
        }
        else {
          console.warn("7")
        }
      }
    }
    if (this._drive.driveName != '') {
      console.warn("2");
      this.Drive = true;
      this.Date = false;
      this.GetDrives(this._drive.driveId);
    }




    // this.GetDrives();
    // this.Drive = true;
    // this.Date = false;
    // if (this._drive.driveName === '') {
    //   this.GetPools();
    //   this.Drive = false;
    //   this.Date = true;
    // }
  }
}
