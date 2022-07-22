import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ConnectionService } from 'src/app/Services/connection.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-interviewer-upcoming-drive',
  templateUrl: './interviewer-upcoming-drive.component.html',
  styleUrls: ['./interviewer-upcoming-drive.component.css']
})
export class InterviewerUpcomingDriveComponent implements OnInit {

  title = 'Upcoming Interviews';

  totalLength: any;
  page: number = 1;

  _pool = '';
  _date = '';

  pool: any[] = [];
  drive: any[] = [];

  driveDetails: any;
  poolDetails: any;
  showErrorMessage: boolean = false;

  constructor(private connection: ConnectionService, private route: Router) { }

  ngOnInit(): void {
    this.connection.GetPoolsbyId().subscribe((data: any) => {
      this.poolDetails = data;
    })

    this.connection.GetUpcomingInterviews().subscribe({
      next: (data: any) => {
        this.driveDetails = data;
        for (let item of this.driveDetails) {
          this.drive.push(item);
        }
      },
      error: (error: any) => {

      }
    })
  }


  filterDropdown() {

    //To filter cards based on the date and pool selection
    this.drive = [];
    for (let item of this.driveDetails) {
      if (this._pool == '' && this._date == '') {
        this.drive.push(item);
      }
      else if (this._pool == item.poolName && this._date == item.interviewDate) {
        this.drive.push(item);
      }
      else if (this._pool == item.poolName && this._date == '') {
        this.drive.push(item);
      }
      else if (this._pool == '' && this._date == item.interviewDate) {
        this.drive.push(item);
      }
    }
  }
}

