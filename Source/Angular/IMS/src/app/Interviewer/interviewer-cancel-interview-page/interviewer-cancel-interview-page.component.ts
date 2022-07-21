import { Location } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ConnectionService } from 'src/app/Services/connection.service';

@Component({
  selector: 'app-interviewer-cancel-interview-page',
  templateUrl: './interviewer-cancel-interview-page.component.html',
  styleUrls: ['./interviewer-cancel-interview-page.component.css']
})
export class InterviewerCancelInterviewPageComponent implements OnInit {
  driveId: any;
  employeeAvailabilityId: number = 0;
  title = 'Cancel Interview';
  Drives: any;
  response: string = '';
  error: string = '';
  submitted: boolean = false;

  constructor(private service: ConnectionService, private route: ActivatedRoute, private Fb: FormBuilder, private location: Location) { }

  CancelInterviewForm: FormGroup = this.Fb.group({
    CancelInterviewReason: ['', Validators.required],
    Comments: ['', Validators.required, Validators.maxLength(250), Validators.minLength(10)],
  });

  public Invites = {
    driveDepartment: ".",
    driveId: 0,
    driveLocation: "",
    driveMode: "",
    driveName: "",
    drivePool: "",
    fromDate: "",
    slotTiming: 0,
    toDate: "",
  }

  getCancellationReason() {
    return this.CancelInterviewForm.get('CancelInterviewReason')?.value;
  }
  getComments() {
    return this.CancelInterviewForm.get('Comments')?.value;
  }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.employeeAvailabilityId = params['employeeAvailabilityId'];
      this.driveId = params['driveId'];
    })
    this.GetDriveById();
  }

  //GET METHOD IN CONNECTION SERVICE TO GET DRIVES
  GetDriveById() {
    this.service.GetDriveById(this.driveId).subscribe((data: any) => {
      this.Invites = data;
    })
  }

  CancellInterview() {
    this.submitted = true;
    if (this.CancelInterviewForm.valid) {
      this.service.CancelInterview(this.employeeAvailabilityId, this.getCancellationReason(), this.getComments()).subscribe({
        next: (data) => this.response = data.message,
        error: (error) => this.error = error.error.message,
        complete: () => this.clearInputFields(),
      });
    }
  }

  clearInputFields() {
    setTimeout(() => {
      this.response = '';
      this.submitted = false;
      this.CancelInterviewForm.reset();
      this.location.back();
    }, 1000);

  }
}
