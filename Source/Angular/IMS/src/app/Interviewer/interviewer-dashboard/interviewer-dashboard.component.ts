import { Component, OnInit } from '@angular/core';
import { ConnectionService } from 'src/app/Services/connection.service';

@Component({
  selector: 'app-interviewer-dashboard',
  templateUrl: './interviewer-dashboard.component.html',
  styleUrls: ['./interviewer-dashboard.component.css']
})
export class InterviewerDashboardComponent implements OnInit {
  title='Dashboard';
  Alldrives :number=0;
  AvailabilityGiven : number=0;
  Utilized : number=0;
  NotUtilized : number=0;
  InterviewsIgnored : number=0;
  InterviewsDenied : number=0;
  InterviewsAccepted : number=0;

  constructor( private connection :ConnectionService) { }

  ngOnInit(): void {
    //GET METHOD IS CALLED AT CONNECTION SERVICE
    this.connection.GetDashboard().subscribe((data: any) =>{
       this.Alldrives = data.TotalDrives
       this.AvailabilityGiven = data.AcceptedDrives
       this.Utilized = data.UtilizedInterviews
       this.NotUtilized = data.NotUtilizedInterviews
       this.InterviewsIgnored = data.IgnoredDrives
       this.InterviewsDenied = data.DeniedDrives
       this.InterviewsAccepted = data.AcceptedDrives
    })
  }


}
