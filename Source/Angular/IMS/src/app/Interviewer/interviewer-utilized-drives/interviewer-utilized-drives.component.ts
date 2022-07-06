import { Component, OnInit } from '@angular/core';
import { ConnectionService } from 'src/app/Services/connection.service';

@Component({
  selector: 'app-interviewer-utilized-drives',
  templateUrl: './interviewer-utilized-drives.component.html',
  styleUrls: ['./interviewer-utilized-drives.component.css']
})
export class InterviewerUtilizedDrivesComponent implements OnInit {

  title='Utilized Interviews';
  Utilized: any;
  totalLength: any;
  page: number = 1;

  constructor(private connection :ConnectionService) { }

  ngOnInit(): void {
    this.connection.GetUtilizedInterviews().subscribe((data: any) => {
      this.Utilized = data;
      console.warn(this.Utilized)
    }) 

  }

}
