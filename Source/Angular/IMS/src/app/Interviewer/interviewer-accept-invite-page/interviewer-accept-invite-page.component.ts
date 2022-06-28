import { Component, OnInit } from '@angular/core';
import { ConnectionService } from 'src/app/Services/connection.service';
import { ActivatedRoute, ParamMap } from '@angular/router';

@Component({
  selector: 'app-interviewer-accept-invite-page',
  templateUrl: './interviewer-accept-invite-page.component.html',
  styleUrls: ['./interviewer-accept-invite-page.component.css']
})
export class InterviewerAcceptInvitePageComponent implements OnInit {
  driveId:any;
  title='Drive Details'
  Invites: any;
  dept=''
  department:any[]=[]
  
  constructor(private connection :ConnectionService,private route: ActivatedRoute) { }

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

}
