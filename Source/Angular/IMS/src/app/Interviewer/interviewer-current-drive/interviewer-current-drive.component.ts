import { Component, Input, OnInit } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { ConnectionService } from 'src/app/Services/connection.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-interviewer-current-drive',
  templateUrl: './interviewer-current-drive.component.html',
  styleUrls: ['./interviewer-current-drive.component.css']
})
export class InterviewerCurrentDriveComponent implements OnInit {

  title = 'Today\'s Interviews'
  totalLength: any;
  page: number = 1;

  _dept = '';
  _pool = '';

  pool: any[] = [];
  drive: any[] = [];

  interviewDetails: any;
  poolDetails: any;
  interviewerpoolDetails :any;
  showErrorMessage: boolean = false;
  error: any;

  constructor(private connection :ConnectionService,private route: Router) { }

  ngOnInit(): void {
  //   this.connection.GetPools().subscribe((data: any) => {
  //     this.poolDetails = data;
  //     for (let item of this.interviewerpoolDetails) {
  //       this.drive.push(item);
  //     }
  // })

  this.connection.GetPools().subscribe((data: any) => {
    this.poolDetails = data;
    for (let item of this.interviewerpoolDetails) {
         this.drive.push(item);
         }
  })

  this.connection.GetTodaysInterviews().subscribe({
      next: (data: any) => {
        this.interviewDetails = data;
        for (let item of this.interviewDetails) {
          this.drive.push(item);
        }
      }
  })

}

  filterDropdown() {

    //To filter cards based on the department and pool selection

    this.drive = [];

    for (let item of this.interviewDetails) {
      if (this._pool == '') {
        this.drive.push(item);
      }
      else if(item.pool == this._pool)
      {
        this.drive.push(item);
      }
    }

  }

}





//   department: any[] = [{
//     departmentId: '1',
//     departmentName: 'dotnet'
//   }]

//   poolDetails: any[] = [{
//     departmentId: '1',
//     poolName: 'Fresher'
//   },
//   {
//     departmentId: '1',
//     poolName: 'Fresher 1'
//   },
//   {
//     departmentId: '1',
//     poolName: 'Fresher 2'
//   },
//   {
//     departmentId: '1',
//     poolName: 'Fresher 3'
//   },]





//   driveDetails: any[] = [{
//     name: 'freshers 2021',
//     department: 'dotnet',
//     poolName: 'Fresher 1',
//     date: '2022-04-12',
//     fromTime: '4.00',
//     toTime: '5.00',
//     mode: 'offline',
//     location: 'chennai'
//   }, {
//     name: 'freshers 2022',
//     department: 'dotnet',
//     poolName: 'Fresher 2',
//     fromTime: '4.00',
//     toTime: '5.00',
//     date: '2022-04-12',
//     mode: 'online',
//     location: ''
//   }, {
//     name: 'freshers 2022',
//     department: 'dotnet',
//     poolName: 'Fresher 3',
//     fromTime: '4.00',
//     toTime: '5.00',
//     date: '2022-04-12',
//     mode: 'online',
//     location: ''
//   }, {
//     name: 'freshers 2021',
//     department: 'dotnet',
//     poolName: 'Fresher 2',
//     fromTime: '4.00',
//     toTime: '5.00',
//     date: '2022-04-12',
//     mode: 'offline',
//     location: 'chennai'
//   }, {
//     name: 'freshers 2022',
//     department: 'dotnet',
//     poolName: 'Fresher 1',
//     fromTime: '4.00',
//     toTime: '5.00',
//     date: '2022-04-12',
//     mode: 'online',
//     location: ''
//   }, {
//     name: 'freshers 2022',
//     department: 'dotnet',
//     poolName: 'Fresher',
//     fromTime: '4.00',
//     toTime: '5.00',
//     date: '2022-04-12',
//     mode: 'online',
//     location: ''
//   }]
// }
