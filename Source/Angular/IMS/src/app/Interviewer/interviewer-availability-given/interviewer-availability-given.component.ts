import { Component, OnInit } from '@angular/core';
import { ConnectionService } from 'src/app/Services/connection.service';

@Component({
  selector: 'app-interviewer-availability-given',
  templateUrl: './interviewer-availability-given.component.html',
  styleUrls: ['./interviewer-availability-given.component.css']
})
export class InterviewerAvailabilityGivenComponent implements OnInit {
  title = 'Slot Availability Given';

  //TO GET DATA FROM DATABASE
  Availability: any;

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
    this.connection.GetSlotAvailability().subscribe((data: any) => {
      this.Availability = data;
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


    for (let item of this.Availability) {
      if (this._pool == '' && item.interviewDate == this._date) {
        this.drive.push(item);
      }
      else if (item.poolName == this._pool && item.interviewDate == this._date) {
        this.drive.push(item);
      }
      else if (this._pool == '' && this._date == '') {
        this.drive.push(item);
      }
      else if (item.poolName == this._pool && this._date == '') {
        this.drive.push(item);
      }
    }
  }
}
