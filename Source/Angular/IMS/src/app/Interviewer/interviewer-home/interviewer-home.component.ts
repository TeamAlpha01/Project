import { ConnectionService } from 'src/app/Services/connection.service';
import { Component, OnInit } from '@angular/core';

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
