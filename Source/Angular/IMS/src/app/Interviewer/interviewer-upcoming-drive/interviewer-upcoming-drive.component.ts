import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-interviewer-upcoming-drive',
  templateUrl: './interviewer-upcoming-drive.component.html',
  styleUrls: ['./interviewer-upcoming-drive.component.css']
})
export class InterviewerUpcomingDriveComponent implements OnInit {
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
    driveName: 'freshers 2022',
    department: 'LAMP',
    poolName: 'Euphoria',
    date: 0,
    mode: '',
    location: ''
  },{
    driveName: 'freshers 2021',
    department: 'Java',
    poolName: 'Freshers',
    date: 0,
    mode: '',
    location: ''
  }, {
    driveName: 'freshers 2022',
    department: 'LAMP',
    poolName: 'Euphoria',
    date: 0,
    mode: '',
    location: ''
  },{
    driveName: 'freshers 2021',
    department: 'Java',
    poolName: 'Freshers',
    date: 0,
    mode: '',
    location: ''
  }, {
    driveName: 'freshers 2022',
    department: 'LAMP',
    poolName: 'Euphoria',
    date: 0,
    mode: '',
    location: ''
  },
  {
    driveName: 'freshers 2021',
    department: 'Java',
    poolName: 'Freshers',
    date: 0,
    mode: '',
    location: ''
  }, {
    driveName: 'freshers 2022',
    department: 'LAMP',
    poolName: 'Euphoria',
    date: 0,
    mode: '',
    location: ''
  },{
    driveName: 'freshers 2021',
    department: 'Java',
    poolName: 'Freshers',
    date: 0,
    mode: '',
    location: ''
  }, {
    driveName: 'freshers 2022',
    department: 'LAMP',
    poolName: 'Euphoria',
    date: 0,
    mode: '',
    location: ''
  },
  {
    driveName: 'freshers 2021',
    department: 'Java',
    poolName: 'Freshers',
    date: 0,
    mode: '',
    location: ''
  }, {
    driveName: 'freshers 2022',
    department: 'LAMP',
    poolName: 'Euphoria',
    date: 0,
    mode: '',
    location: ''
  },{
    driveName: 'freshers 2021',
    department: 'Java',
    poolName: 'Freshers',
    date: 0,
    mode: '',
    location: ''
  }, {
    driveName: 'freshers 2022',
    department: 'LAMP',
    poolName: 'Euphoria',
    date: 0,
    mode: '',
    location: ''
  },]
}