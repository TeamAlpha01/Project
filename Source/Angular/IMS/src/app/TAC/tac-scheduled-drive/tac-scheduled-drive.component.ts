import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { ConnectionService } from 'src/app/Services/connection.service';

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

  //To store the filtered data in the array
  pool: any[] = [];
  drive: any[] = [];
  deptId: any;


  //To get the details from the db
  driveDetails: any;
  poolDetails: any;
  departmentDetails: any;

  constructor(private connection: ConnectionService) { }

  ngOnInit(): void {

    this.connection.GetScheduledDrives().subscribe((data: any) => {
      this.driveDetails = data;
      for (let item of this.driveDetails) {
        this.drive.push(item);
      }
    })
    this.connection.GetPools().subscribe((data: any) => {
      this.poolDetails = data;
    })
    this.connection.GetDepartments().subscribe((data: any) => {
      this.departmentDetails = data;
    })
  }



  filterDropdown() {
    //To filter cards based on the department and pool selection
    this.drive = [];

    // if (this._dept == '') {
    //   this._pool = ''
    // }

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


