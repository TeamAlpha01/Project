import { Component, OnInit } from '@angular/core';
import { ConnectionService } from 'src/app/Services/connection.service';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { Form, FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-interviewer-cancel-invite-page',
  templateUrl: './interviewer-cancel-invite-page.component.html',
  styleUrls: ['./interviewer-cancel-invite-page.component.css']
})
export class InterviewerCancelInvitePageComponent implements OnInit {
  driveId:any;
  employeeAvailabilityId:number=0;
  title='Cancel Invite';
  Invites: any;
  response: string='';
  error: string='';
  constructor(private service :ConnectionService,private route: ActivatedRoute,private Fb: FormBuilder) { }
  CancelInterviewForm:FormGroup=this.Fb.group({
    CancelInterviewReason:['',Validators.required],
    Comments:['',Validators.required]
  });

  getCancellationReason(){
    return this.CancelInterviewForm.get('CancelInterviewReason')?.value;
  }
  getComments(){
    return this.CancelInterviewForm.get('Comments')?.value;
  }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.employeeAvailabilityId = params['employeeAvailabilityId'];
    })
    // this.GetDriveById(this.driveId);
  }

  GetDriveById(driveId:any)
  {
    this.service.GetDriveById(driveId).subscribe((data: any) => {
      this.Invites = data;
      console.warn(this.Invites);
    })
  }

  CancellInterview(){
    if(this.CancelInterviewForm.valid)
    {
      console.log('employeeAvailabilitd : '+this.employeeAvailabilityId);
      console.log('radio '+this.getCancellationReason())
      console.log('radio '+this.getComments())
      this.service.CancelInterview(this.employeeAvailabilityId,this.getCancellationReason(),this.getComments()).subscribe({
        next :(data)=>this.response=data,
        error: (error)=>this.error=error.error.message
      });
    }
  }
}
