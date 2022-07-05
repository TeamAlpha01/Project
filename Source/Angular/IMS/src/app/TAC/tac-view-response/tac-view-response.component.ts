import { Component, OnInit } from '@angular/core';
import { ConnectionService } from 'src/app/Services/connection.service';

@Component({
  selector: 'app-tac-view-response',
  templateUrl: './tac-view-response.component.html',
  styleUrls: ['./tac-view-response.component.css']
})
export class TacViewResponseComponent implements OnInit {
  totalLength: any;
  page: number = 1;
  title = 'View Drive Response';
  driveId: number = 3;
  driveDetails: any;
  drive: any;
  errorMessage: any;
  driveResponses: any[] = [];
  response: any;
  error: any;


  constructor(private connection: ConnectionService) { }

  ngOnInit(): void {
    this.GetDriveResponse();
    this.GetDrive();
  }

  GetDriveResponse() {
    this.connection.GetDriveResponse(this.driveId).subscribe({
      next: (data: any) => {
        this.driveResponses = data, console.warn(this.driveResponses);
      },
      error: (errorMessage: any) => this.errorMessage = errorMessage.message
    });
  }
  GetDrive() {
    this.connection.GetDrive(this.driveId).subscribe({
      next: (data: any) => this.driveDetails = data,
      error: (errorMessage: any) => this.errorMessage = errorMessage.message
    });
  }

  schedule(employeeResponseId: number) {
    console.warn(employeeResponseId);
    this.connection.ScheduleInterview(employeeResponseId).subscribe({
      next: (data) => {this.response = data.message,this.GetDriveResponse()},
      error: (error) => this.error = error.error.message
    });
  }

}
