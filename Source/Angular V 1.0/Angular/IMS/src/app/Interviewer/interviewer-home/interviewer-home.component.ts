import { ConnectionService } from 'src/app/Services/connection.service';
import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/app/Services/authentication.service';

@Component({
  selector: 'app-interviewer-home',
  templateUrl: './interviewer-home.component.html',
  styleUrls: ['./interviewer-home.component.css']
})
export class InterviewerHomeComponent implements OnInit {
  title='Home'
  constructor() { }

  ngOnInit(): void {
  }

}
