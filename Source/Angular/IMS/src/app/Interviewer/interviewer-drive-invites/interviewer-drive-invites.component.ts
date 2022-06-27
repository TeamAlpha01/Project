import { Component, OnInit } from '@angular/core';
import { ConnectionService } from 'src/app/Services/connection.service';

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
  Invites: any;

  constructor(private connection :ConnectionService) { }

  ngOnInit(): void {
    this.connection.GetDriveInvitesById().subscribe((data: any) => {
      this.Invites = data;
      console.warn(this.Invites)
    }) 
  }
}

  // driveInvites: any[] = [{
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

