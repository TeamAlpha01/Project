import { Component, OnInit } from '@angular/core';
import { ConnectionService } from 'src/app/Services/connection.service';

@Component({
  selector: 'app-myperformance',
  templateUrl: './myperformance.component.html',
  styleUrls: ['./myperformance.component.css']
})
export class MyperformanceComponent implements OnInit {
  title='My Performance'
  dashBoard: any;

  constructor(private connection : ConnectionService) { }

  ngOnInit(): void {

    this.connection.GetTACDashboard().subscribe((data: any) => {
      this.dashBoard = data;
    })
    
  }

}
