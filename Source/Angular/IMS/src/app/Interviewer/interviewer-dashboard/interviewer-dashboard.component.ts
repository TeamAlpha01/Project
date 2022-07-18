import { Component, OnInit } from '@angular/core';
import { ConnectionService } from 'src/app/Services/connection.service';

@Component({
  selector: 'app-interviewer-dashboard',
  templateUrl: './interviewer-dashboard.component.html',
  styleUrls: ['./interviewer-dashboard.component.css']
})
export class InterviewerDashboardComponent implements OnInit {
  title='Dashboard';
  TotalDrives :number=0;
  AcceptedDrives : number=0;
  DeniedDrives : number=0;
  IgnoredDrives : number=0;
  SlotAvailabilityGiven : number=0;
  UtilizedInterviews : number=0;
  NotUtilizedInterviews : number=0;

  constructor( private connection :ConnectionService) { }

  ngOnInit(): void {
    //GET METHOD IS CALLED AT CONNECTION SERVICE
    this.connection.GetDashboard().subscribe((data: any) =>{
       this.TotalDrives = data.TotalDrives
       this.AcceptedDrives = data.AcceptedDrives
       this.DeniedDrives = data.DeniedDrives
       this.IgnoredDrives = data.IgnoredDrives
       this.SlotAvailabilityGiven = data.SlotAvailabiltyGiven
       this.UtilizedInterviews = data.UtilizedInterviews
       this.NotUtilizedInterviews = data.NotUtilizedInterviews
    })
  }


}
