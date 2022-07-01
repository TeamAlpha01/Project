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
  title='Cancel Invite';
  Invites: any;
  constructor(private connection :ConnectionService,private route: ActivatedRoute,private Fb: FormBuilder) { }
  CancelInterviewForm:FormGroup=this.Fb.group({
    CancelInterviewReason:['',Validators.required],
    Comments:['',Validators.required]
  });

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.driveId = params['driveId'];
      console.log('drive id : '+this.driveId);
    })
    this.GetDriveById(this.driveId);
  }

  GetDriveById(driveId:any)
  {
    this.connection.GetDriveById(driveId).subscribe((data: any) => {
      this.Invites = data;
      console.warn(this.Invites);
    })
  }

  CancellInterview(){
    if(this.CancelInterviewForm.valid)
    {
      console.log('test')
      console.log('radio '+this.CancelInterviewForm.get('CancelInterviewReason')?.value)
      console.log('radio '+this.CancelInterviewForm.get('Comments')?.value)
    }
  }
}
