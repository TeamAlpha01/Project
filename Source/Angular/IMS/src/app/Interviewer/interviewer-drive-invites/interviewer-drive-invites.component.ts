import { Component, OnInit } from '@angular/core';
import { ConnectionService } from 'src/app/Services/connection.service';

@Component({
  selector: 'app-interviewer-drive-invites',
  templateUrl: './interviewer-drive-invites.component.html',
  styleUrls: ['./interviewer-drive-invites.component.css']
})
export class InterviewerDriveInvitesComponent implements OnInit {
  title = 'Drive Invites'
  data: any;
  totalLength: any;
  page: number = 1;
  Invites: any;
  driveId: any;
  error: string = '';
  response: string = '';
  constructor(private connection: ConnectionService) { }

  ngOnInit(): void {
    this.GetDriveInvitesById();
  }
  GetDriveInvitesById() {
    this.connection.GetDriveInvitesById().subscribe((data: any) => {
      this.Invites = data;
    })
  }
  AddResponse(DriveId: number) {
    const response = {
      responseId: 0,
      driveId: DriveId,
      employeeId: 0,
      responseType: 2,
    }
    this.connection.AddResponse(response).subscribe({
      next: (data: any) => { this.response = data.message, this.GetDriveInvitesById() },
      error: (error) => { this.error = error.error, this.snackBar() },
      complete: () => this.snackBar(),
    });
  }

  snackBar() {
    setTimeout(() => {
      this.error = '';
      this.response = '';
    }, 2000);
  }

}

