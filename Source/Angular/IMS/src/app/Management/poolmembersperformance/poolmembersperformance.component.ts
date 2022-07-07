import { Component, OnInit } from '@angular/core';
import { ConnectionService } from 'src/app/Services/connection.service';


@Component({
  selector: 'app-poolmembersperformance',
  templateUrl: './poolmembersperformance.component.html',
  styleUrls: ['./poolmembersperformance.component.css']
})
export class PoolmembersperformanceComponent implements OnInit {
  title = "View Pools";
  page: number = 1;
  poolDetails: any;
  _pool = '';
  totalLength: any;

  constructor(private connection: ConnectionService) { }

  ngOnInit(): void {
    this.GetPools();

  }
  GetPools() {
    this.connection.GetPoolsbyId().subscribe((data: any) => {
      this.poolDetails = data;
      console.warn(this.poolDetails);
    })
  }




}
