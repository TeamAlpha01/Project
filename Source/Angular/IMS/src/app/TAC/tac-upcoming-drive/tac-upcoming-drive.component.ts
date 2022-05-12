import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-tac-upcoming-drive',
  templateUrl: './tac-upcoming-drive.component.html',
  styleUrls: ['./tac-upcoming-drive.component.css']
})
export class TacUpcomingDriveComponent implements OnInit {
  title = 'UpComing Drive'
  totalLength: any;
  page: number = 1;
  _dept = '';
  _pool = '';
  _date = '';

  pool: any[] = [];
  drive: any[] = [];

  driveDetails: any;
  poolDetails: any;
  departmentDetails: any;
  deptId: any;
  constructor(private http: HttpClient) { }

  ngOnInit(): void {

    this.http
      .get<any>('https://localhost:7072/Drive/ViewScheduledDrives')
      .subscribe((data) => {
        this.driveDetails = data;
        this.drive = data;
        console.log(this.driveDetails)
      });

    this.http
      .get<any>('https://localhost:7072/Pool/ViewPools')
      .subscribe((data) => {
        this.poolDetails = data;
        console.log(this.poolDetails)
      });

    this.http
      .get<any>('https://localhost:7072/Deparment/ViewDepartments')
      .subscribe((data) => {
        this.departmentDetails = data;
        console.log(this.departmentDetails)
      });

  }


  filterDropdown() {
    //To filter cards based on the department and pool selection
    this.drive = [];
    for (let item of this.driveDetails) {

      if (this._dept == '' && this._pool == '' && item.fromDate <= this._date && this._date <= item.toDate) {
        console.log(this._date)
        console.warn(item.toDate)
        this.drive.push(item);
        console.log("0")
      }
      else if (this._dept == '' && item.fromDate <= this._date && this._date <= item.toDate) {
        this._pool = '';
        this.drive.push(item);
        console.log("true")
      }
      else if (this._dept == '' && this._date == '') {
        this._pool = '';
        this.drive.push(item);
        console.log("false")
      }
      else if (this._dept == '' && this._pool == '' && this._date == '') {
        this.drive.push(item);
        console.log("1")
      }

      else if (item.driveDepartment == this._dept && item.drivePool == this._pool && this._date == '') {
        this.drive.push(item);
        console.log("2")
      }
      else if (item.driveDepartment == this._dept && item.drivePool == this._pool && item.fromDate <= this._date && this._date <= item.toDate) {
        this.drive.push(item);
        console.log("3")
      }
      else if (item.driveDepartment == this._dept && this._pool == '' && this._date == '') {
        this.drive.push(item);
        console.log("4")
      }
      else if (item.driveDepartment == this._dept && this._pool == '' && item.fromDate <= this._date && this._date <= item.toDate) {
        this.drive.push(item);
        console.log("5")
      }
      else if (item.driveDepartment == this._dept && item.drivePool != this._pool) {
      }

    }

  }

}