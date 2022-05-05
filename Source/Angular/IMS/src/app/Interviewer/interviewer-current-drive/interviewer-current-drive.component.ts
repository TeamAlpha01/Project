import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-interviewer-current-drive',
  templateUrl: './interviewer-current-drive.component.html',
  styleUrls: ['./interviewer-current-drive.component.css']
})
export class InterviewerCurrentDriveComponent implements OnInit {

  drive: any;
  totalLength: any;
  page: number = 1;
  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.http
      .get<any>('https://localhost:7072/Drive/ViewTodayDrives')
      .subscribe((data) => {
        this.drive = data;
        this.totalLength = data.length;
      });
  }

  // drive: any[] = [{
  //   driveName: 'freshers 2021',
  //   department: 'asd',
  //   poolName: '',
  //   date: 0,
  //   mode: '',
  //   location: ''
  // }, {
  //   driveName: 'freshers 2022',
  //   department: 'fgh',
  //   poolName: '',
  //   date: 0,
  //   mode: '',
  //   location: ''
  // }]
}
