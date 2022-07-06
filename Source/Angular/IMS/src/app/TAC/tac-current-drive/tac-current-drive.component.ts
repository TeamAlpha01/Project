import { Component, OnInit } from '@angular/core';
import { ConnectionService } from 'src/app/Services/connection.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-tac-current-drive',
  templateUrl: './tac-current-drive.component.html',
  styleUrls: ['./tac-current-drive.component.css']
})

export class TacCurrentDriveComponent implements OnInit {

  title = 'Current Drive'

  //PAGINATION
  totalLength: any;
  page: number = 1;

  //TO GET INPUT FROM THE USER
  _dept = '';
  _pool = '';

  //TO STORE THE FILTERED DATA
  pool: any[] = [];
  drive: any[] = [];


  //TO STORE THE DATA FROM THE DATABASE
  driveDetails: any;
  poolDetails: any;
  departmentDetails: any;

  //TO STORE THE HTTP RESPONSE
  error: any;
  showErrorMessage: boolean = false;

  constructor(private connection: ConnectionService, private route: Router) { }

  ngOnInit(): void {
    this.GetPools();
    this.GetDepartments();
    this.GetTodaysDrives();
  }

  GetPools() {
    this.connection.GetPools().subscribe({ next: (data: any) => this.poolDetails = data });
  }

  GetDepartments() {
    this.connection.GetDepartments().subscribe({ next: (data: any) => this.departmentDetails = data });
  }

  GetTodaysDrives() {
    this.connection.GetTodayDrives().subscribe({
      next: (data: any) => {
        this.driveDetails = data;
        for (let item of this.driveDetails) {
          this.drive.push(item);
        }
      }
    });
  }

  filterDropdown() {

    console.log("Department Name : " + this._dept);
    console.log("Pool Name : " + this._pool);

    //TO FILTER DRIVE BASED ON THE DEPARTMENT AND POOL SELECTION
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

    //TO CLEAR POOL SELECTION ONCE THE DEPARTMENT SELECTION IS CHANGED
    if (this._dept != '') {
      this._pool = '';
    }

    // TO FILTER POOL BASED ON DEPARTMENT SELECTION
    this.pool = [];
    for (let item of this.poolDetails) {
      if (item.departmentName == this._dept) {
        this.pool.push(item);
      }
    }
    console.warn("Department Name : " + this._dept);
    console.warn("Pool Name : " + this._pool);
  }

}

