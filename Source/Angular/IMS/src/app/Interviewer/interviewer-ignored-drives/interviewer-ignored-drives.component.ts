import { Component, OnInit } from '@angular/core';
import { ConnectionService } from 'src/app/Services/connection.service';

@Component({
  selector: 'app-interviewer-ignored-drives',
  templateUrl: './interviewer-ignored-drives.component.html',
  styleUrls: ['./interviewer-ignored-drives.component.css']
})
export class InterviewerIgnoredDrivesComponent implements OnInit {


  title='Ignored Drives';
  Ignored: any;
  totalLength: any;
  page: number = 1;

  constructor(private connection :ConnectionService) { }

  ngOnInit(): void {
    this.connection.GetDeniedDrives().subscribe((data: any) => {
      this.Ignored = data;
      console.warn(this.Ignored)
    }) 
  }

}
