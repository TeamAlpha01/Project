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

  List: any[] = [];

  page: number = 1;
  totalLength: any;
  driveResponse: any[] = [];
  employeesPerformance: any[] = [];
  driveDetails: any;
  departmentEmployees: any;
  driveId = 0;
  error: any;

  performance = [{
    dashboardCount: {
      AcceptedDrives: 0,
      CancelledInterview: 0,
      DeniedDrives: 0,
      IgnoredDrives: 0,
      NotUtilizedInterviews: 0,
      SlotAvailabiltyGiven: 0,
      TotalAvailability: 0,
      TotalDrives: 0,
      UtilizedInterviews: 0
    },
    employee: {
      employeeACENumber: "",
      employeeName: "",
      employeeRole: ""
    }
  },
  ]

  // employeePerformance = {
  //   dashboardCount: {
  //     AcceptedDrives: 0,
  //     CancelledInterview: 0,
  //     DeniedDrives: 0,
  //     IgnoredDrives: 0,
  //     NotUtilizedInterviews: 0,
  //     SlotAvailabiltyGiven: 0,
  //     TotalAvailability: 0,
  //     TotalDrives: 0,
  //     UtilizedInterviews: 0
  //   },
  //   employee: {
  //     employeeACENumber: "",
  //     employeeName: "",
  //     employeeRole: ""
  //   }
  // }

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
      next: (data: any) => { this.driveDetails = data },
      // error:(error:any)=>this.error=error,
    })
  }

  GetDrives(driveId: number) {
    this.connection.GetDashboardDriveResponse(driveId).subscribe({
      next: (data: any) => { this.driveResponse = data },
    })
  }

  GetEmployeesPerformance() {
    const dataRange = { From: this._fromDate, To: this._toDate }
    this.connection.GetEmployeePerformance(dataRange).subscribe({
      next: (data: any) => {
        this.performance = data,
          this.List = data
      },
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
    if (this._drive.driveName == undefined || this._drive.driveName == '') {
      this._drive = {
        driveId: 0,
        driveName: ''
      }
      if (this._drive.driveName == '') {
        this.Drive = false;
        this.Date = true;
        this.GetEmployeesPerformance();
        if (this._pool != '') {
          this.Drive = false;
          this.Date = true;
        }
        else if (this._fromDate != '' || this._toDate != '') {
          this.Drive = false;
          this.Date = true;
          const dateRange = { FromDate: this._fromDate, ToDate: this._toDate }
          this.connection.GetEmployeePerformance(dateRange);
        }
      }
    }
    if (this._drive.driveName != '') {
      this.Drive = true;
      this.Date = false;
      this.GetDrives(this._drive.driveId);
    }
  }

  filter() {
    this.List = []
    this.List = this.performance.filter((data: any) => data.employee.employeeName.toLowerCase().includes(this._name.toLowerCase()));
  }
}
