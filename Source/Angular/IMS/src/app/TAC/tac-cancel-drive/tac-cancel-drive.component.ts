import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { Observable } from 'rxjs';
import { ConnectionService } from 'src/app/Services/connection.service';

@Component({
  selector: 'app-tac-cancel-drive',
  templateUrl: './tac-cancel-drive.component.html',
  styleUrls: ['./tac-cancel-drive.component.css']
})
export class TacCancelDriveComponent implements OnInit {
  title = 'Cancel Drive';
  driveId: number = 0;
  driveDetails: any;
  Reason = '';
  errorMessage: any;

  constructor(private route: ActivatedRoute, private connection: ConnectionService) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.driveId = params['driveId']
    })
    this.connection.GetDrive(this.driveId).subscribe((data: any) => {
      this.driveDetails = data;
      console.log(this.driveDetails);
    })

  }

  CancelDrive(reason: string) {
    this.connection.CancelDrive(this.driveId, reason)

    // this.connection.CancelDrive(this.driveId, reason).Observable<any>
  }
}
