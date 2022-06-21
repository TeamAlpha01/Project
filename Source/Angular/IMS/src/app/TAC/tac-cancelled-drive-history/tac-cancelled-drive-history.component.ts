import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ConnectionService } from 'src/app/Services/connection.service';

@Component({
  selector: 'app-tac-cancelled-drive-history',
  templateUrl: './tac-cancelled-drive-history.component.html',
  styleUrls: ['./tac-cancelled-drive-history.component.css']
})
export class TacCancelledDriveHistoryComponent implements OnInit {

  title = 'cancelled Drive History'
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


    this.connection.GetCancelledDrives().subscribe({
      next: (data: any) => {
        this.driveDetails = data;
        for (let item of this.driveDetails) {
          this.drive.push(item);
        }
      },
      error: (error: any) => {
        if (error.status == 404) {
          this.route.navigateByUrl("errorPage");
        }
      }
    })


    this.connection.GetPools().subscribe((data: any) => {
      this.poolDetails = data;
    },
      (error: any) => {
        this.showErrorMessage = true;
        console.warn("1");
        console.warn(error);
        if (error.status == 404) {
          this.route.navigateByUrl("errorPage");
        }
      })


    this.connection.GetDepartments().subscribe((data: any) => {
      this.departmentDetails = data;
    },
      (error: any) => {
        this.showErrorMessage = true;
        console.warn("1");
        console.warn(error);
        if (error.status == 404) {
          this.route.navigateByUrl("errorPage");
        }
      })
  }


  filterDropdown() {

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
