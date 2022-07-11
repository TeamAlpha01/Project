import { Component, OnInit } from '@angular/core';
import { ConnectionService } from 'src/app/Services/connection.service';

@Component({
  selector: 'app-myperformance',
  templateUrl: './myperformance.component.html',
  styleUrls: ['./myperformance.component.css']
})

export class MyperformanceComponent implements OnInit {
  title = 'My Performance'
  ScheduledDrives: number = 0
  CancelledDrives: number = 0
  error: any;

  constructor(private connection: ConnectionService) { }

  ngOnInit(): void {
    this.GetDashboard();
  }

  GetDashboard() {
    this.connection.GetTACDashboard().subscribe({
      next: (data: any) => {
        this.ScheduledDrives = data.ScheduledDrives
        this.CancelledDrives = data.CancelledDrives
      },
      error: (error: any) => this.error = error.error.message,
    });
  }
}
