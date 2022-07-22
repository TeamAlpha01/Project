import { Component, OnInit } from '@angular/core';
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


  constructor(private connection: ConnectionService) { }

  ngOnInit(): void {
    this.GetDashboard(this.date);
  }

  //GET METHOD IS CALLED AT CONNECTION SERVICE
  GetDashboard(date: any) {
    this.connection.GetDashboard(date).subscribe((data: any) => {
      this.TotalDrives = data.TotalDrives
      this.AcceptedDrives = data.AcceptedDrives
      this.DeniedDrives = data.DeniedDrives
      this.IgnoredDrives = data.IgnoredDrives
      this.SlotAvailabilityGiven = data.SlotAvailabiltyGiven
      this.UtilizedInterviews = data.UtilizedInterviews
      this.NotUtilizedInterviews = data.NotUtilizedInterviews
      this.CancelledDrives = data.CancelledInterview
    })
  }

  Apply() {
    console.warn(this.date);
    this.GetDashboard(this.date);
  }


}
