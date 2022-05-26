import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';

@Component({
  selector: 'app-tac-cancel-drive',
  templateUrl: './tac-cancel-drive.component.html',
  styleUrls: ['./tac-cancel-drive.component.css']
})
export class TacCancelDriveComponent implements OnInit {
  title = 'Cancel Drive';
  driveId: number = 0;

  constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.driveId = params['driveId']
      console.warn(this.driveId)
    })
    
  }

}
