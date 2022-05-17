import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-tac-scheduled-drive',
  templateUrl: './tac-scheduled-drive.component.html',
  styleUrls: ['./tac-scheduled-drive.component.css']
})
export class TacScheduledDriveComponent implements OnInit {

  title = 'Scheduled Drive'
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
        this.drive.push(item);
      }
      else if (this._dept == '' && item.drivePool == this._pool && item.fromDate <= this._date && this._date <= item.toDate) {
        this.drive.push(item);
      }
      else if (this._dept == '' && this._pool == '' && this._date == '') {
        this.drive.push(item);
      }
      else if (this._dept == '' && item.drivePool == this._pool && this._date == '') {
        this.drive.push(item);
      }
      else if (item.driveDepartment == this._dept && item.drivePool == this._pool && this._date == '') {
        this.drive.push(item);
      }
      else if (item.driveDepartment == this._dept && item.drivePool == this._pool && item.fromDate <= this._date && this._date <= item.toDate) {
        this.drive.push(item);
      }
      else if (item.driveDepartment == this._dept && this._pool == '' && this._date == '') {
        this.drive.push(item);
      }
      else if (item.driveDepartment == this._dept && this._pool == '' && item.fromDate <= this._date && this._date <= item.toDate) {
        this.drive.push(item);
      }
      else if (item.driveDepartment == this._dept && item.drivePool != this._pool) {
      }

    }

  }

}


