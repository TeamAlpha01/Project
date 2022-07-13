import { Component, OnInit } from '@angular/core';
import { ConnectionService } from 'src/app/Services/connection.service';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-interviewer-accept-invite-page',
  templateUrl: './interviewer-accept-invite-page.component.html',
  styleUrls: ['./interviewer-accept-invite-page.component.css']
})
export class InterviewerAcceptInvitePageComponent implements OnInit {
  driveId: number = 0;
  title = 'Drive Details'
  dept = ''
  department: any[] = []
  toTime: any;
  response: string = '';
  error: string = '';
 _date='';

  AcceptInvitePage = this.fb.group({
    InterviewDate: ['', [Validators.required]],
    SlotTime: ['', [Validators.required]]
  });


  Invites = {
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

  getInterviewDate() {
    return this.AcceptInvitePage.get('InterviewDate')?.value;
  }
  getSlotTime() {
    return this.AcceptInvitePage.get('SlotTime')?.value;
  }

  constructor(private connection: ConnectionService, private route: ActivatedRoute, private fb: FormBuilder) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.driveId = params['driveId'];
    })
    this.GetDriveById(this.driveId);
  }

  GetDriveById(driveId: any) {
    this.connection.GetDriveById(driveId).subscribe((data: any) => {
      this.Invites = data;
    })
  }

  //
  AddResponse() {
    if (this.AcceptInvitePage.valid) {
      console.warn(this.getInterviewDate() + "   " + this.getSlotTime())
      var to = new Date()
      to.setHours(this.getSlotTime().substr(0, 2))
      to.setMinutes(this.getSlotTime().substr(3))
      var too = new Date();
      too.setTime(to.getTime() + (this.Invites.slotTiming * 60000))
      this.toTime = Math.floor(too.getHours()) + ":" + too.getMinutes() % 60;
      console.warn(this.toTime);

      const timeSlot = {
        employeeAvailabilityId: 0,
        driveId: this.driveId,
        employeeId: 1,
        interviewDate: this.getInterviewDate(),
        fromTime: this.getSlotTime(),
        toTime: this.toTime
      }

      console.log(timeSlot);
      this.connection.AddTimeSlot(timeSlot).subscribe({
        next: (data) => { this.response = data.message, this.AcceptResponse() },
        error: (error) => { this.error = error.error, this.snackBar() },
        complete: () => this.snackBar(),
      });
    }
  }
  snackBar() {
    setTimeout(() => {
      this.error = '';
      this.response = '';
      this.AcceptInvitePage.reset();
    }, 2000);
  }
  AcceptResponse() {
    const response = {
      responseId: 0,
      driveId: this.driveId,
      employeeId: 0,
      responseType: 2,
    }

    //POST METHOD IS CALLED AT CONNECTION SERVICE
    this.connection.AddResponse(response).subscribe({
      next: (data: any) => { this.Invites = data, console.warn(this.Invites) },
      error: (error: any) => { this.error = error.error.message, this.snackBar() },
      complete: () => this.snackBar(),
    });
  }
}
