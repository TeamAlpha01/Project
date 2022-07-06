import { Component, OnInit } from '@angular/core';
import { ConnectionService } from 'src/app/Services/connection.service';

@Component({
  selector: 'app-interviewer-denied-drives',
  templateUrl: './interviewer-denied-drives.component.html',
  styleUrls: ['./interviewer-denied-drives.component.css']
})
export class InterviewerDeniedDrivesComponent implements OnInit {

  title='Denied Drives';
  Denied: any;
  totalLength: any;
  page: number = 1;

  constructor(private connection :ConnectionService) { }

  ngOnInit(): void {
    this.connection.GetDeniedDrives().subscribe((data: any) => {
      this.Denied = data;
      console.warn(this.Denied)
    }) 
  }

}
