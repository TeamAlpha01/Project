import { Component, OnInit } from '@angular/core';
import { ConnectionService } from 'src/app/Services/connection.service';

@Component({
  selector: 'app-interviewer-not-utilized-drives',
  templateUrl: './interviewer-not-utilized-drives.component.html',
  styleUrls: ['./interviewer-not-utilized-drives.component.css']
})
export class InterviewerNotUtilizedDrivesComponent implements OnInit {
  title='Not Utilized Interviews';
  NotUtilized: any;
  totalLength: any;
  page: number = 1;

  constructor(private connection :ConnectionService) { }

  ngOnInit(): void {
    this.connection.GetNotUtilizedInterviews().subscribe((data: any) => {
      this.NotUtilized = data;
      console.warn(this.NotUtilized)
    }) 
  }

}
