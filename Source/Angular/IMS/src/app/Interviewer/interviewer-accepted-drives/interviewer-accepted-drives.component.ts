import { Component, OnInit } from '@angular/core';
import { ConnectionService } from 'src/app/Services/connection.service';

@Component({
  selector: 'app-interviewer-accepted-drives',
  templateUrl: './interviewer-accepted-drives.component.html',
  styleUrls: ['./interviewer-accepted-drives.component.css']
})
export class InterviewerAcceptedDrivesComponent implements OnInit {

  title = 'Accepted Drives';

  //TO GET DATA FROM DATABASE
  AcceptedDrives: any;

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
    this.connection.GetAcceptedDrives().subscribe((data: any) => {
      this.AcceptedDrives = data;
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

    for (let item of this.AcceptedDrives) {
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

