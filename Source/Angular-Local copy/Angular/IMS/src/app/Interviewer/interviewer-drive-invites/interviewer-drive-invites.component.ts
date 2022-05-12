import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-interviewer-drive-invites',
  templateUrl: './interviewer-drive-invites.component.html',
  styleUrls: ['./interviewer-drive-invites.component.css']
})
export class InterviewerDriveInvitesComponent implements OnInit {
  title ='Drive Invites'
  data: any;
  totalLength: any;
  page: number = 1;
  constructor() { }

  ngOnInit(): void {
  }
  driveInvites: any[] = [{
    driveName: 'freshers 2021',
    department: 'asd',
    poolName: '',
    date: 0,
    mode: '',
    location: ''
  }, {
    driveName: 'freshers 2022',
    department: 'fgh',
    poolName: '',
    date: 0,
    mode: '',
    location: ''
  }]
}
