import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';


@Component({
  selector: 'app-interviewer-scheduled-drive',
  templateUrl: './interviewer-scheduled-drive.component.html',
  styleUrls: ['./interviewer-scheduled-drive.component.css']
})
export class InterviewerScheduledDriveComponent implements OnInit {
  // drive: any;
  totalLength: any;
  page: number = 1;
 
  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    // this.http
    //   .get<any>('https://localhost:7072/Drive/ViewScheduledDrives')
    //   .subscribe((data) => {
    //     this.drive = data;
    //     this.totalLength = data.length;
    //   }); 
  }
  drive: any[] = [{
    name: 'freshers 2021',
    department: 'Java',
    poolName: 'Freshers',
    date: 0,
    mode: '',
    location: ''
  }, {
    name :'freshers 2022',
    department: 'LAMP',
    poolName: 'Euphoria',
    date: 0,
    mode: '',
    location: ''
  },{
    name: 'freshers 2021',
    department: 'Java',
    poolName: 'Freshers',
    date: 0,
    mode: '',
    location: ''
  }, {
    name :'freshers 2022',
    department: 'LAMP',
    poolName: 'Euphoria',
    date: 0,
    mode: '',
    location: ''
  }]
}
