import { Component, OnInit } from '@angular/core';
import { ConnectionService } from 'src/app/Services/connection.service';

@Component({
  selector: 'app-interviewer-availability-given',
  templateUrl: './interviewer-availability-given.component.html',
  styleUrls: ['./interviewer-availability-given.component.css']
})
export class InterviewerAvailabilityGivenComponent implements OnInit {
  title='Availability Given';
  Availability: any;
  totalLength: any;
  page: number = 1;

  constructor(private connection :ConnectionService) { }

  ngOnInit(): void {
    this.connection.GetAcceptedDrives().subscribe((data: any) => {
      this.Availability = data;
      console.warn(this.Availability)
    }) 

  }

}
