import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ConnectionService } from 'src/app/Services/connection.service';

@Component({
  selector: 'app-interviewer-cancelled-drives',
  templateUrl: './interviewer-cancelled-drives.component.html',
  styleUrls: ['./interviewer-cancelled-drives.component.css']
})
export class InterviewerCancelledDrivesComponent implements OnInit {

  title = 'Cancelled Interviews';

  //To get data from database
  CancelledDrives: any;

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
    this.GetCancelledinterviews();
    this.GetPoolsbyId();
  }

  GetCancelledinterviews() {
    //Get method called at connection service
    this.connection.GetCancelledinterviews(this.date).subscribe((data: any) => {
      this.CancelledDrives = data;
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

