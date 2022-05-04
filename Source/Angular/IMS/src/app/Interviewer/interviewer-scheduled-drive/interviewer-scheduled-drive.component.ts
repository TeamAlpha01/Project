import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-interviewer-scheduled-drive',
  templateUrl: './interviewer-scheduled-drive.component.html',
  styleUrls: ['./interviewer-scheduled-drive.component.css']
})
export class InterviewerScheduledDriveComponent implements OnInit {
  data: any;
  totalLength: any;
  page: number = 1;
 
  constructor() { }

  ngOnInit(): void {
  }
  drive: any[] = [{
    driveName: 'freshers 2021',
    department: 'Java',
    poolName: 'Freshers',
    date: 0,
    mode: '',
    location: ''
  }, {
    driveName :'freshers 2022',
    department: 'LAMP',
    poolName: 'Euphoria',
    date: 0,
    mode: '',
    location: ''
  }]
}
