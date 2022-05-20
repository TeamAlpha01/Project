import { Component, OnInit } from '@angular/core';
import { ConnectionService } from 'src/app/Services/connection.service';

@Component({
  selector: 'app-admin-dashboard',
  templateUrl: './admin-dashboard.component.html',
  styleUrls: ['./admin-dashboard.component.css']
})
export class AdminDashboardComponent implements OnInit {

  data: any;
  totalLength: any;
  page: number = 1;
  // title ="Dashboard";
  
  constructor(private connection: ConnectionService) { }

  ngOnInit(): void {
    this.connection.GetEmployeeProfile().subscribe((data: any) => {
      this.data = data;
      console.log(this.data)
    })
  }

}
