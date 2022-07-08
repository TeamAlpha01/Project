import { Component, OnInit } from '@angular/core';
import { ConnectionService } from 'src/app/Services/connection.service';

@Component({
  selector: 'app-interviewer-not-utilized-drives',
  templateUrl: './interviewer-not-utilized-drives.component.html',
  styleUrls: ['./interviewer-not-utilized-drives.component.css']
})
export class InterviewerNotUtilizedDrivesComponent implements OnInit {
  
  title='Not Utilized Interviews';
  NotUtilized: any;
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
    this.connection.GetNotUtilizedInterviews().subscribe((data: any) => {
      this.NotUtilized = data;
      for (let item of data){
        this.drive.push(item);
      }
    }) 

    this.connection.GetPoolsbyId().subscribe((data: any) => {
      this.poolDetails = data;
    })
  }

  filterDropdown() {
  
    this.drive = [];
    for (let item of this.NotUtilized) {
      if ( this._pool == '' && item.interviewDate == this._date ) {
        this.drive.push(item);
      }
      else if (item.drivePool == this._pool && item.interviewDate == this._date) {
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
