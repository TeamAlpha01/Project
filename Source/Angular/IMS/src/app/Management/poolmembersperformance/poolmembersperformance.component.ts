import { Component, OnInit } from '@angular/core';
import { ConnectionService } from 'src/app/Services/connection.service';


@Component({
  selector: 'app-poolmembersperformance',
  templateUrl: './poolmembersperformance.component.html',
  styleUrls: ['./poolmembersperformance.component.css']
})
export class PoolmembersperformanceComponent implements OnInit {
  title = "View Defaulters";
  page: number = 1;
  totalLength: any;
  item: any;
  employeesUnderPool: any;
  poolName:any[]=[];
  constructor(private connection: ConnectionService) { }

  ngOnInit(): void {
    this.GetPoolsById();

  }
  GetPoolsById() {
    this.connection.GetPoolsById(this.employeesUnderPool).subscribe((data: any) => {
      this.employeesUnderPool = data;
    })
  }




}
