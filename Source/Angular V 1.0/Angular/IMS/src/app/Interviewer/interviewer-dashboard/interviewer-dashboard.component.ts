import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { ConnectionService } from 'src/app/Services/connection.service';

@Component({
  selector: 'app-interviewer-dashboard',
  templateUrl: './interviewer-dashboard.component.html',
  styleUrls: ['./interviewer-dashboard.component.css']
})
export class InterviewerDashboardComponent implements OnInit {
  title = 'Dashboard';
  TotalDrives: number = 0;
  AcceptedDrives: number = 0;
  DeniedDrives: number = 0;
  IgnoredDrives: number = 0;
  SlotAvailabilityGiven: number = 0;
  UtilizedInterviews: number = 0;
  NotUtilizedInterviews: number = 0;
  CancelledDrives: number = 0;
  date = {
    From: '',
    To: ''
  }
  MaxDate: Date = new Date()
  error: any;


  constructor(private connection: ConnectionService, private spinner: NgxSpinnerService) { }

  ngOnInit(): void {
    this.GetDashboard(this.date);
  }

  //GET METHOD IS CALLED AT CONNECTION SERVICE
  GetDashboard(date: any) {
    this.spinner.show();
    this.connection.GetDashboard(date).subscribe({
      next: (data: any) => {
        this.TotalDrives = data.TotalDrives
        this.AcceptedDrives = data.AcceptedDrives
        this.DeniedDrives = data.DeniedDrives
        this.IgnoredDrives = data.IgnoredDrives
        this.SlotAvailabilityGiven = data.SlotAvailabiltyGiven
        this.UtilizedInterviews = data.UtilizedInterviews
        this.NotUtilizedInterviews = data.NotUtilizedInterviews
        this.CancelledDrives = data.CancelledInterview
      },
      error: (error: any) => {
        this.spinner.hide();
        if (error.status == 0)
          this.error = "Oops! Server down please try again later";
        else if (error.status == 500)
          this.error = "Sorry some internal error occured please try again later";
        else
          this.error = error.error;
      },
      complete: () => this.spinner.hide()
    })
  }


  Apply() {
    console.warn(this.date);
    this.GetDashboard(this.date);
  }


}
