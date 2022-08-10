import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ConnectionService } from 'src/app/Services/connection.service';

@Component({
  selector: 'app-interviewer-availability-given',
  templateUrl: './interviewer-availability-given.component.html',
  styleUrls: ['./interviewer-availability-given.component.css']
})
export class InterviewerAvailabilityGivenComponent implements OnInit {
  title = 'Slot Availability Given';

  //To get data from database
  Availability: any;

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

  date = {
    From: '',
    To: ''
  }

  constructor(private connection: ConnectionService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.date.From = params['fromDate']   //This methods gets the data from the query string
      this.date.To = params['toDate']
    })
    this.GetSlotAvailability();
    this.GetPoolsbyId();
  }

  GetSlotAvailability() {
    //Get method called at connection service
    this.connection.GetSlotAvailability(this.date).subscribe((data: any) => {
      this.Availability = data;
      this.drive = data;
    })
  }

  GetPoolsbyId() {
    //Get method called at connection service
    this.connection.GetPoolsbyId().subscribe((data: any) => {
      this.poolDetails = data;
    })
  }

  //This method is called on change in dropdown filter
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
