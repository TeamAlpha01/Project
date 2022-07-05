import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-interviewer-total-drives',
  templateUrl: './interviewer-total-drives.component.html',
  styleUrls: ['./interviewer-total-drives.component.css']
})
export class InterviewerTotalDrivesComponent implements OnInit {

  title='Total No. Of Drives';
  drive:any[]=[];

  constructor() { }

  ngOnInit(): void {
  }

}
