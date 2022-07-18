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
  employeesPerformance: any[]=[];

  constructor(private connection: ConnectionService) { }

  ngOnInit(): void {
    this.GetPools();
    this.GetEmployeesPerformance();
  }

  GetPools() {
    this.connection.GetPools().subscribe({
      next: (data: any) => this.poolDetails = data,
    })
  }

  GetDrives() {
    this.connection.GetDashboardDriveResponse(25).subscribe({
      next: (data: any) => this.driveResponse = data,
    })
  }

  GetEmployeesPerformance() {
    this.connection.GetEmployeesPerformance().subscribe({
      next: (data: any) =>{ this.employeesPerformance = data},
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



  // user = [
  //   {
  //     id: 1,
  //     name: "Aravind",
  //     AceNumber: "ACE0001",
  //     role: "Software Engineer",
  //     totalNumberOfDrives: 10,
  //     availability: 8,
  //     denied: 1,
  //     ignored: 1,
  //     utilized: 6,
  //     notUtilized: 2,
  //     cancel: 2,
  //     pool: "Fresher .NET"
  //   }, {
  //     id: 2,
  //     name: "Deepika",
  //     AceNumber: "ACE0002",
  //     role: "Software Engineer",
  //     totalNumberOfDrives: 15,
  //     availability: 11,
  //     denied: 3,
  //     ignored: 1,
  //     utilized: 9,
  //     notUtilized: 4,
  //     cancel: 2
  //   }, {
  //     id: 1,
  //     name: "Kumaresh",
  //     AceNumber: "ACE0003",
  //     role: "Software Engineer",
  //     totalNumberOfDrives: 10,
  //     availability: 8,
  //     denied: 1,
  //     ignored: 1,
  //     utilized: 6,
  //     notUtilized: 2,
  //     cancel: 2,
  //     pool: "Fresher .NET"
  //   }, {
  //     id: 2,
  //     name: "Gokul",
  //     AceNumber: "ACE0004",
  //     role: "Software Engineer",
  //     totalNumberOfDrives: 15,
  //     availability: 11,
  //     denied: 3,
  //     ignored: 1,
  //     utilized: 9,
  //     notUtilized: 4,
  //     cancel: 2
  //   }, {
  //     id: 1,
  //     name: "Sheik",
  //     AceNumber: "ACE0005",
  //     role: "Software Engineer",
  //     totalNumberOfDrives: 10,
  //     availability: 8,
  //     denied: 1,
  //     ignored: 1,
  //     utilized: 6,
  //     notUtilized: 2,
  //     cancel: 2,
  //     pool: "Fresher .NET"
  //   }, {
  //     id: 2,
  //     name: "prithvi",
  //     AceNumber: "ACE0006",
  //     role: "Software Engineer",
  //     totalNumberOfDrives: 15,
  //     availability: 11,
  //     denied: 3,
  //     ignored: 1,
  //     utilized: 9,
  //     notUtilized: 4,
  //     cancel: 2
  //   }]

}
