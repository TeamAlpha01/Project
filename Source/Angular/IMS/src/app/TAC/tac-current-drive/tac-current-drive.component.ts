import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-tac-current-drive',
  templateUrl: './tac-current-drive.component.html',
  styleUrls: ['./tac-current-drive.component.css']
})

export class TacCurrentDriveComponent implements OnInit {

  title = 'Current Drive'
  totalLength: any;
  page: number = 1;
  _dept = '';
  _pool = '';

  pool: any[] = [];
  drive: any[] = [];

  driveDetails: any;
  poolDetails: any;
  departmentDetails: any;
  deptId: any;
  constructor(private http: HttpClient) { }

  ngOnInit(): void {

    this.http
      .get<any>('https://localhost:7072/Drive/ViewTodayDrives')
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
    //To filter pool based on the department
    this.pool = [];

    if (this._dept == '') {
      this._pool = ''
    }
    else {
      //To get department id by department name given by the user
      for (let item of this.departmentDetails) {
        console.log(this._dept)
        if (item.departmentName == this._dept) {
          this.deptId = item.departmentId;
        }
      }

      for (let item of this.poolDetails) {
        if (item.departmentId == this.deptId) {
          this.pool.push(item);
          console.log(item)
        }
      }
    }

    //To filter cards based on the department and pool selection

    this.drive = [];

    for (let item of this.driveDetails) {
      if (this._dept == '' && this._pool == '') {
        this.drive.push(item);
      }
      else if (item.driveDepartment == this._dept && item.drivePool == this._pool) {
        this.drive.push(item);
      }

      else if (item.driveDepartment == this._dept && this._pool == '') {
        this.drive.push(item);
      }
      else if (item.driveDepartment == this._dept && item.drivePool != this._pool) {
      }

    }

  }

}

