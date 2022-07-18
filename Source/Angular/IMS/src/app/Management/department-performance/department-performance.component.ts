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

  keyword = 'poolName';

  _name = ''
  _drive = ''
  _pool = ''
  _fromDate = ''
  _toDate = ''
  Drive: boolean = false
  Date: boolean = true

  page: number = 1;
  totalLength: any;
  driveResponse: any[] = [];
  employeesPerformance: any[] = [];

  constructor(private connection: ConnectionService) { }

  ngOnInit(): void {
    this.GetPools();
    this.GetEmployeesPerformance();
  }

  GetPools() {
    this.connection.GetPools().subscribe({
      next: (data: any) => { this.poolDetails = data }

    })
  }

  GetDrives() {
    this.connection.GetDashboardDriveResponse(25).subscribe({
      next: (data: any) => this.driveResponse = data,
    })
  }

  GetEmployeesPerformance() {
    this.connection.GetEmployeesPerformance().subscribe({
      next: (data: any) => { this.employeesPerformance = data },
    })
  }

  drive() {
    this._fromDate = ''
    this._toDate = ''
  }

  date() {
    this._pool = ''
    this._drive = ''
  }

  Apply() {
    this.GetDrives();
    this.Drive = true;
    this.Date = false;
    if (this._drive === '') {
      this.GetPools();
      this.Drive = false;
      this.Date = true;
    }
  }
}
