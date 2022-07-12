import { Component, OnInit } from '@angular/core';
import { ConnectionService } from 'src/app/Services/connection.service';

@Component({
  selector: 'app-department-performance',
  templateUrl: './department-performance.component.html',
  styleUrls: ['./department-performance.component.css']
})
export class DepartmentPerformanceComponent implements OnInit {
  poolDetails: any;
  title = "Performance";

  _name = ''
  _drive = ''
  _pool = ''
  _fromDate = ''
  _toDate = ''

  constructor(private connection: ConnectionService) { }

  ngOnInit(): void {
    this.GetPools();
  }

  GetPools() {
    this.connection.GetPools().subscribe({
      next: (data: any) => this.poolDetails = data,
    })
  }

  drive() {

    this._fromDate = '',
      this._toDate = ''
  }
  date() {
    this._pool = '',
      this._drive = ''
  }

  user = [
    {
      id: 1,
      name: "Vinoth",
      AceNumber: "ACE0001",
      role: "Software Engineer",
      totalNumberOfDrives: 10,
      availability: 8,
      denied: 1,
      ignored: 1,
      utilized: 6,
      notUtilized: 2,
      cancel: 2,
      pool: "Fresher .NET"
    }, {
      id: 2,
      name: "Aravind",
      AceNumber: "ACE0002",
      role: "Software Engineer",
      totalNumberOfDrives: 15,
      availability: 11,
      denied: 3,
      ignored: 1,
      utilized: 9,
      notUtilized: 4,
      cancel: 2
    }]

}
