import { Component, OnInit } from '@angular/core';
import { ConnectionService } from 'src/app/Services/connection.service';

@Component({
  selector: 'app-interviewer-dashboard',
  templateUrl: './interviewer-dashboard.component.html',
  styleUrls: ['./interviewer-dashboard.component.css']
})
export class InterviewerDashboardComponent implements OnInit {
  title='Dashboard';
  EmployeeDashboardDetails :any;
  constructor( private connection :ConnectionService) { }

  ngOnInit(): void {
    this.connection.GetDashboard().subscribe((data: any) => {
      this.EmployeeDashboardDetails = data;
  });
  }
  card: any[] = [{
    count:10,
    name:'No.Of.Interviews'
  },
  {
    count:10,
    name:'Availbility Given'
  },
  {
    count:10,
    name:'Utilized'
  },
  {
    count:10,
    name:'Not Utilized'
  },
  {
    count:10,
    name:'Interviews Ignorned'
  },
  {
    count:10,
    name:'Interviews Denied'
  }]
}
