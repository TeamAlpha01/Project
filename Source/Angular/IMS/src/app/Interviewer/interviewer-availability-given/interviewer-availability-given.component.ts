import { Component, OnInit } from '@angular/core';
import { ConnectionService } from 'src/app/Services/connection.service';

@Component({
  selector: 'app-interviewer-availability-given',
  templateUrl: './interviewer-availability-given.component.html',
  styleUrls: ['./interviewer-availability-given.component.css']
})
export class InterviewerAvailabilityGivenComponent implements OnInit {
  title='Availability Given';
  Availability: any;
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
    this.connection.GetAcceptedDrives().subscribe((data: any) => {
      this.Availability = data;
      console.warn(this.Availability)
    }) 

    this.connection.GetPoolsbyId().subscribe((data: any) => {
      this.poolDetails = data;
      console.warn(this.poolDetails)
    })
  }

  filterDropdown(){
  //To filter cards based on pool selection
  this.drive = [];

  for (let item of this.driveDetails) {

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
    else if (item.drivePool != this._pool) {
    }
  }
}
}