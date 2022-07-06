import { Component, OnInit } from '@angular/core';
import { ConnectionService } from 'src/app/Services/connection.service';

@Component({
  selector: 'app-interviewer-total-drives',
  templateUrl: './interviewer-total-drives.component.html',
  styleUrls: ['./interviewer-total-drives.component.css']
})
export class InterviewerTotalDrivesComponent implements OnInit {

  title='Total No. Of Drives';
  // drive:any[]=[];
  Drives: any;
  totalLength: any;
  page: number = 1;

  constructor(private connection :ConnectionService) { }

  ngOnInit(): void {
    this.connection.GetTotalDrives().subscribe((data: any) => {
      this.Drives = data;
      console.warn(this.Drives)
    }) 

  }

}
