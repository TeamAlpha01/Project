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
  driveId: any;
  constructor(private connection :ConnectionService) { }

  ngOnInit(): void {
    this.connection.GetDriveInvitesById().subscribe((data: any) => {
      this.Invites = data;
      console.warn(this.Invites)
    }) 
  }

  AddResponse(driveId: number, response: boolean)
  {
    this.connection.AddResponse(this.driveId).subscribe((data: any) => {
      this.Invites = data;
      console.warn(this.Invites);
    }) 
  }

}

