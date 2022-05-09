import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-interviewer-accept-invite-page',
  templateUrl: './interviewer-accept-invite-page.component.html',
  styleUrls: ['./interviewer-accept-invite-page.component.css']
})
export class InterviewerAcceptInvitePageComponent implements OnInit {

  title='Drive Details'
  dept=''
  department:any[]=[]
  constructor() { }

  ngOnInit(): void {
  }

}
