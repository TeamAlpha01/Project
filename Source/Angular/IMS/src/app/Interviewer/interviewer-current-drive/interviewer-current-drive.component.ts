import { Component, Input, OnInit } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { ConnectionService } from 'src/app/Services/connection.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-interviewer-current-drive',
  templateUrl: './interviewer-current-drive.component.html',
  styleUrls: ['./interviewer-current-drive.component.css']
})
export class InterviewerCurrentDriveComponent implements OnInit {

  title = 'Today\'s Interviews'
  totalLength: any;
  page: number = 1;

  Current='Current'

  _dept = '';
  _pool = '';

  pool: any[] = [];
  drive: any[] = [];

  interviewDetails: any;
  poolDetails: any;
  interviewerpoolDetails: any;
  showErrorMessage: boolean = false;
  error: any;

  constructor(private connection: ConnectionService, private route: Router) { }

  ngOnInit(): void {

    //GET METHOD IS CALLED AT CONNECTION SERVICE
    this.connection.GetPoolsbyId().subscribe((data: any) => {
      this.poolDetails = data;
    })

    //GET METHOD IS CALLED AT CONNECTION SERVICE
    this.connection.GetTodaysInterviews().subscribe({
      next: (data: any) => {
        this.interviewDetails = data;
        for (let item of this.interviewDetails) {
          this.drive.push(item);
        }
      }
    })

  }

  filterDropdown() {

    //To filter cards based on the department and pool selection

    this.drive = [];

    for (let item of this.interviewDetails) {
      if (this._pool == '') {
        this.drive.push(item);
      }
      else if (item.pool == this._pool) {
        this.drive.push(item);
      }
    }
  }
}
