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
    this.connection.GetTodayDrives().subscribe({
      next: (data: any) => {
        this.driveDetails = data;
        for (let item of this.driveDetails) {
          this.drive.push(item);
        }
      }
    })

    this.connection.GetPools().subscribe((data: any) => this.poolDetails = data)

    this.connection.GetDepartments().subscribe((data: any) => this.departmentDetails = data)
  }


  filterDropdown() {
    // console.warn(this.poolDetails);

    console.log("Department Name : " + this._dept);
    console.log("Pool Name : " + this._pool);

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
    if (this._dept != '') {
      this._pool='';
      // console.warn("1")
    }

    this.pool=[];
    for(let item of this.poolDetails){
      if(item.departmentName==this._dept){
        this.pool.push(item);
      }
    }
    console.warn("Department Name : " + this._dept);
    console.warn("Pool Name : " + this._pool);
  }

}

