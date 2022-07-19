import { Component, OnInit } from '@angular/core';
import { ConnectionService } from 'src/app/Services/connection.service';

@Component({
  selector: 'app-interviewer-cancelled-drives',
  templateUrl: './interviewer-cancelled-drives.component.html',
  styleUrls: ['./interviewer-cancelled-drives.component.css']
})
export class InterviewerCancelledDrivesComponent implements OnInit {

  title = 'Cancelled Drives';

  //TO GET DATA FROM DATABASE
  CancelledDrives: any;

  //PAGINATION
  totalLength: any;
  page: number = 1;

  //TO GET USER INPUT
  _pool = '';
  _date = '';

  //To store the filtered data in the array
  pool: any[] = [];
  drive: any[] = [];

  //To get the details from the db
  driveDetails: any;
  poolDetails: any;

  constructor(private connection: ConnectionService) { }

  ngOnInit(): void {
    //GET METHOD CALLED AT CONNECTION SERVICE
    this.connection.GetCancelledinterviews().subscribe((data: any) => {
      this.CancelledDrives = data;
      this.drive = data;
    })

    //GET METHOD CALLED AT CONNECTION SERVICE
    this.connection.GetPoolsbyId().subscribe((data: any) => {
      this.poolDetails = data;
    })
  }

  //THIS METHOD IS CALLED ON CHANGE IN DROPDOWN FILTER 
  filterDropdown() {

    this.drive = [];

    for (let item of this.CancelledDrives) {
      if (this._pool == '' && item.fromDate <= this._date && this._date <= item.toDate) {
        this.drive.push(item);
      }
      else if (item.drivePool == this._pool && item.fromDate <= this._date && this._date <= item.toDate) {
        this.drive.push(item);
      }
      else if (this._pool == '' && this._date == '') {
        this.drive.push(item);
      }
      else if (item.drivePool == this._pool && this._date == '') {
        this.drive.push(item);
      }
    }
  }
}

