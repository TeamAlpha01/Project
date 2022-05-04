import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-drive-detail-card',
  templateUrl: './drive-detail-card.component.html',
  styleUrls: ['./drive-detail-card.component.css']
})
export class DriveDetailCardComponent implements OnInit {
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
  }]

  


}
