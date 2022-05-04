import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-interviewer-current-drive',
  templateUrl: './interviewer-current-drive.component.html',
  styleUrls: ['./interviewer-current-drive.component.css']
})
export class InterviewerCurrentDriveComponent implements OnInit {

  data: any;
  totalLength: any;
  page: number = 1;
  constructor() { }

  ngOnInit(): void {
  }
  drive: any[] = [{
    driveName: 'freshers',
    department: '',
    poolName: '',
    date: 0,
    mode: '',
    location: ''
  }, {
    driveName: 'freshers',
    department: '',
    poolName: '',
    date: 0,
    mode: '',
    location: ''
  }]
}
