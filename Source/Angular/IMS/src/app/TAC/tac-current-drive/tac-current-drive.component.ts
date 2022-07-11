import { Component, OnInit } from '@angular/core';
import { ConnectionService } from 'src/app/Services/connection.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-tac-current-drive',
  templateUrl: './tac-current-drive.component.html',
  styleUrls: ['./tac-current-drive.component.css'],
})

export class TacCurrentDriveComponent implements OnInit {
  title = 'Current Drive';

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

  constructor(private connection: ConnectionService) { }

  ngOnInit(): void {
    this.GetPools();
    this.GetDepartments();
    this.GetTodaysDrives();
  }

  GetPools() {
    this.connection.GetPools().subscribe({
      next: (data: any) => (this.poolDetails = data),
    });
  }

  GetDepartments() {
    this.connection.GetDepartments().subscribe({
      next: (data: any) => (this.departmentDetails = data),
    });
  }

  GetTodaysDrives() {
    this.connection.GetTodayDrives().subscribe({
      next: (data: any) => {
        this.driveDetails = data;
        for (let item of this.driveDetails) {
          this.drive.push(item);
        }
      },
    });
  }

  OnDepartmentChange() {
    this._pool = '';
    this.filterDropdown(this._dept);
  }

  filterDropdown(_dept: string) {
    //TO FILTER DRIVE BASED ON THE DEPARTMENT AND POOL SELECTION
    this.drive = [];
    for (let item of this.driveDetails) {
      if (_dept == '' && this._pool == '') {
        this.drive.push(item);
      } else if (item.driveDepartment == _dept && item.drivePool == this._pool) {
        this.drive.push(item);
      } else if (item.driveDepartment == _dept && this._pool == '') {
        this.drive.push(item);
      }
    }
  }
}
