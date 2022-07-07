import { Component, OnInit } from '@angular/core';
import { ConnectionService } from 'src/app/Services/connection.service';

@Component({
  selector: 'app-interviewer-total-drives',
  templateUrl: './interviewer-total-drives.component.html',
  styleUrls: ['./interviewer-total-drives.component.css']
})
export class InterviewerTotalDrivesComponent implements OnInit {

  title='Total No. of Drives';
  Drives: any;
  totalLength: any;
  page: number = 1;

  _pool = '';
  _date = '';

  //To store the filtered data in the array
  pool: any[] = [];
  drive: any[] = [];

  //To get the details from the db
  driveDetails: any;
  poolDetails: any;

  constructor(private connection :ConnectionService) { }

  ngOnInit(): void {
    this.connection.GetTotalDrives().subscribe((data: any) => {
      this.Drives = data;
      this.drive=data;
    }) 

    this.connection.GetPoolsbyId().subscribe((data: any) => {
      this.poolDetails = data;
      console.warn(this.poolDetails)
    })
  }

filterDropdown() {
  
  this.drive = [];

  for (let item of this.Drives) {
    if ( this._pool == '' && item.fromDate <= this._date && this._date <= item.toDate) {
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

