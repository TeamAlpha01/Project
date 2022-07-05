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
  driveId:number=0;
  title='Drive Details'
  Invites: any;
  dept=''
  department:any[]=[]

  AcceptInvitePage=this.fb.group({
    InterviewDate:['',[Validators.required]],
    SlotTime:['',[Validators.required]]
  });

  getInterviewDate()
  {
    return this.AcceptInvitePage.get('InterviewDate')?.value;
  }
  getSlotTime()
  {
    return this.AcceptInvitePage.get('SlotTime')?.value;
  }
  constructor(private connection :ConnectionService,private route: ActivatedRoute,private fb:FormBuilder) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.driveId = params['driveId'];
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

  AddResponse()
  {
    console.warn('test')
    if(this.AcceptInvitePage.valid)
    {
      console.warn(this.getInterviewDate()+"   "+this.getSlotTime())
      var to=new Date()
      to.setHours(this.getSlotTime().substr(0,2))
      to.setMinutes(this.getSlotTime().substr(3))
      console.log(to)
      var too =new Date();
      too.setTime(to.getTime()+ (this.Invites.slotTiming * 60000))
      console.log(too)
      // this.connection.AddResponse(this.driveId).subscribe((data: any) => {
      //   this.Invites = data;
      //   console.warn(this.Invites);
      // })
    }
  }
}
