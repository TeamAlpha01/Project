import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ConnectionService } from 'src/app/Services/connection.service';

@Component({
  selector: 'app-tac-scheduled-drive-history',
  templateUrl: './tac-scheduled-drive-history.component.html',
  styleUrls: ['./tac-scheduled-drive-history.component.css']
})
export class TacScheduledDriveHistoryComponent implements OnInit {

  title = 'Scheduled Drive History'
  totalLength: any;
  page: number = 1;

  //To get the inputs from the user
  _dept = '';
  _pool = '';

  //To store the filtered data in the array
  pool: any[] = [];
  drive: any[] = [];
  deptId: any;


  //To get the details from the db
  driveDetails: any;
  poolDetails: any;
  departmentDetails: any;
  error: any;
  showErrorMessage: boolean = false;

  constructor(private connection: ConnectionService, private route: Router) { }

  ngOnInit(): void {
    this.GetNonCancelledDrives();
    this.GetPools();
    this.GetDepartments();
  }
  
  GetNonCancelledDrives() {
    this.connection.GetNonCancelledDrives().subscribe({
      next: (data: any) => {
        this.driveDetails = data;
        for (let item of this.driveDetails) {
          this.drive.push(item);
        }
      },
      error: (error: any) => this.error = error.error.message,
    })
  }

  GetPools() {
    this.connection.GetPools().subscribe({
      next: (data: any) => this.poolDetails = data,
      error: (error: any) => this.error = error.error.message,
    });
  }

  GetDepartments() {
    this.connection.GetDepartments().subscribe({
      next: (data: any) => this.driveDetails = data,
      error: (error: any) => this.error = error.error.message,
    });
  }

  OnDepartmentChange() {
    this._pool = ''
    this.filterDropdown(this._dept);
  }

  //To filter cards based on the department and pool selection
  filterDropdown(_dept: string) {
    this.drive = [];
    for (let item of this.driveDetails) {
      if (_dept == '' && this._pool == '') {
        this.drive.push(item);
      }
      else if (item.driveDepartment == _dept && item.drivePool == this._pool) {
        this.drive.push(item);
      }
      else if (item.driveDepartment == _dept && this._pool == '') {
        this.drive.push(item);
      }
    }
  }
}
