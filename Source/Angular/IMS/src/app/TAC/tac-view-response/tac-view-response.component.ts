import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
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
  driveId: number = 0;
  errorMessage: any;
  driveResponses: any[] = [];
  response: string = '';
  error: any;

  drive = {
    driveDepartment: "",
    driveId: 0,
    driveLocation: "",
    driveMode: "",
    driveName: "",
    drivePool: "",
    fromDate: "",
    slotTiming: 0,
    toDate: ""
  }

  constructor(private connection: ConnectionService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.driveId = params['driveId']
    })
    this.GetDriveResponse();
    this.GetDrive();
  }

  GetDriveResponse() {
    this.connection.GetDriveResponse(this.driveId).subscribe({
      next: (data: any) => {
        this.driveResponses = data;
      },
      error: (errorMessage: any) => this.errorMessage = errorMessage.message
    });
  }

  GetDrive() {
    this.connection.GetDrive(this.driveId).subscribe({
      next: (data: any) => this.drive = data,
      error: (errorMessage: any) => this.errorMessage = errorMessage.message
    });
  }

  schedule(employeeResponseId: number) {
    this.connection.ScheduleInterview(employeeResponseId).subscribe({
      next: (data) => { this.response = data.message, this.GetDriveResponse() },
      error: (error) => this.error = error.error.message,
      complete: () => this.snackBar()
    });
  }

  snackBar() {
    setTimeout(() => {
      this.response = '';
    }, 2000);

  }
}
