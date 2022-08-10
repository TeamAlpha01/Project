import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ConnectionService } from 'src/app/Services/connection.service';

@Component({
  selector: 'app-interviewer-accepted-drives',
  templateUrl: './interviewer-accepted-drives.component.html',
  styleUrls: ['./interviewer-accepted-drives.component.css']
})
export class InterviewerAcceptedDrivesComponent implements OnInit {

  title = 'Accepted Drives';

  //To get data from database
  AcceptedDrives: any;

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
    this.GetAcceptedDrives();
    this.GetPoolsbyId();
  }

  GetAcceptedDrives() {
    this.connection.GetAcceptedDrives(this.date).subscribe((data: any) => {
      this.AcceptedDrives = data;
      this.drive = data;
    })
  }

  GetPoolsbyId() {
    this.connection.GetPoolsbyId().subscribe((data: any) => {
      this.poolDetails = data;
    })
  }

  //T his method is called on change in dropdown filter 
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

