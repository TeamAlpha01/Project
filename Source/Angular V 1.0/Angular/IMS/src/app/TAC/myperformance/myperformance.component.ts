import { Component, OnInit } from '@angular/core';
import { ConnectionService } from 'src/app/Services/connection.service';

@Component({
  selector: 'app-myperformance',
  templateUrl: './myperformance.component.html',
  styleUrls: ['./myperformance.component.css']
})

export class MyperformanceComponent implements OnInit {
  title = 'My Performance' // This gives the title of the page

  ScheduledDrives: number = 0
  CancelledDrives: number = 0

  error: any;

  date = {
    From: '',
    To: ''
  }

  MaxDate:Date=new Date()

  constructor(private connection: ConnectionService) { }

  ngOnInit(): void {
    this.GetDashboard(this.date);
  }

  //This function sends the data to server
  GetDashboard(date: any) {
    this.connection.GetTACDashboard(date).subscribe({
      next: (data: any) => {
        this.ScheduledDrives = data.ScheduledDrives
        this.CancelledDrives = data.CancelledDrives
      },
      error: (error: any) => this.error = error.error,
    });
  }

  //Filteration method
  Apply() {
    this.GetDashboard(this.date);
  }
}
