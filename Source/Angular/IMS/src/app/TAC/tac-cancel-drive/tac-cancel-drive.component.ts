
import { Location } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { ConnectionService } from 'src/app/Services/connection.service';

@Component({
  selector: 'app-tac-cancel-drive',
  templateUrl: './tac-cancel-drive.component.html',
  styleUrls: ['./tac-cancel-drive.component.css']
})

export class TacCancelDriveComponent implements OnInit {
  title = 'Cancel Drive';
  driveId: number = 0;
  Reason = '';
  data: any;
  error: string = '';
  submitted: boolean = false;
  response: string = '';

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

  constructor(private route: ActivatedRoute, private connection: ConnectionService, private fb: FormBuilder, private location: Location) { }

  CancelDriveForm = this.fb.group({
    cancelReason: ['', [Validators.required, Validators.minLength(5), Validators.maxLength(100)]],
  });

  getCancelReason() {
    return this.CancelDriveForm.get('cancelReason')
  }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.driveId = params['driveId']
    })
    this.GetDrive();
  }

  GetDrive() {
    this.connection.GetDrive(this.driveId).subscribe({
      next: (data: any) => this.drive = data,
      error: (error: any) => this.error = error.error.message
    });
  }

  CancelDrive() {
    this.submitted = true;
    this.error = '';
    if (this.CancelDriveForm.valid) {
      console.log(this.getCancelReason()?.value)
      this.connection.CancelDrive(this.driveId, this.getCancelReason()?.value).subscribe({
        next: (data) => this.response = data.message,
        error: (error) => this.error = error.error.message,
        complete: () => this.clearInputFields(),
      });
    }
  }

  clearInputFields() {
    this.submitted = false;
    setTimeout(() => {
      this.response = '';
      this.location.back();
    }, 2000);

  }
}
