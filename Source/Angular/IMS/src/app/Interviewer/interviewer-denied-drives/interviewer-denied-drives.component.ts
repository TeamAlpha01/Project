import { Component, OnInit } from '@angular/core';
import { ConnectionService } from 'src/app/Services/connection.service';

@Component({
  selector: 'app-interviewer-denied-drives',
  templateUrl: './interviewer-denied-drives.component.html',
  styleUrls: ['./interviewer-denied-drives.component.css']
})
export class InterviewerDeniedDrivesComponent implements OnInit {

  title='Denied Drives';

  //To get data from database
  Denied: any;
  
  //Pagination
  totalLength: any;
  page: number = 1;

  //To get user input
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
    this.connection.GetDeniedDrives().subscribe((data: any) => {
      this.Denied = data;
      this.drive = data;
    })

     //GET METHOD CALLED AT CONNECTION SERVICE
    this.connection.GetPoolsbyId().subscribe((data: any) => {
      this.poolDetails = data;
    })
  }

  filterDropdown() {
    //To filter cards based on the date and pool selection
    this.drive = [];

    for (let item of this.Denied) {
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
