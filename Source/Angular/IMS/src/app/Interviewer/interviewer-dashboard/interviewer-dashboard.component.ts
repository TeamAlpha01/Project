import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-interviewer-dashboard',
  templateUrl: './interviewer-dashboard.component.html',
  styleUrls: ['./interviewer-dashboard.component.css']
})
export class InterviewerDashboardComponent implements OnInit {
  title='Dashboard';
  constructor() { }

  ngOnInit(): void {
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
