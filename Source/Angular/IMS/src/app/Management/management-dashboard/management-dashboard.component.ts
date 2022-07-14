import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-management-dashboard',
  templateUrl: './management-dashboard.component.html',
  styleUrls: ['./management-dashboard.component.css']
})
export class ManagementDashboardComponent implements OnInit {
  
  title="My Dashboard"
  constructor() { }

  ngOnInit(): void {
  }

}
