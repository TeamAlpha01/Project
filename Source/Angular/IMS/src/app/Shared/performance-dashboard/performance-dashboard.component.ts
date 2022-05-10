import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-performance-dashboard',
  templateUrl: './performance-dashboard.component.html',
  styleUrls: ['./performance-dashboard.component.css']
})
export class PerformanceDashboardComponent implements OnInit {
  title='Performance Dashboard';
  constructor() { }

  ngOnInit(): void {
  }

}
