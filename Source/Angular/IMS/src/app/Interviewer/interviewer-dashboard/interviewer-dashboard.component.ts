import { Component, OnInit } from '@angular/core';
import { ConnectionService } from 'src/app/Services/connection.service';

@Component({
  selector: 'app-interviewer-dashboard',
  templateUrl: './interviewer-dashboard.component.html',
  styleUrls: ['./interviewer-dashboard.component.css']
})
export class InterviewerDashboardComponent implements OnInit {
  title='Dashboard';
  allinterviews : any;
  totalLength: any;
  EmployeeDashboardDetails :any;

  constructor( private service :ConnectionService) { }

  ngOnInit(): void {
    this.service.GetDashboard().subscribe((data: any) => {
      this.EmployeeDashboardDetails = data;
      console.warn(this.EmployeeDashboardDetails);
  });
  }

  GetAllInterviews() {
    this.service.GetAllInterviews().subscribe((data: any) => {
      this.allinterviews = data;
      this.totalLength = data.length;
    });
  }

}
