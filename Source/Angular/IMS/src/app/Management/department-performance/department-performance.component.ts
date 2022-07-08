import { Component, OnInit } from '@angular/core';
import { ConnectionService } from 'src/app/Services/connection.service';

@Component({
  selector: 'app-department-performance',
  templateUrl: './department-performance.component.html',
  styleUrls: ['./department-performance.component.css']
})
export class DepartmentPerformanceComponent implements OnInit {
  poolDetails: any;
  title="Performance";

  constructor(private connection:ConnectionService) { }

  ngOnInit(): void {
    this.GetPools();
  }

  GetPools() {
    this.connection.GetPools().subscribe({
      next:(data: any) => this.poolDetails = data,
    })
  }

}
