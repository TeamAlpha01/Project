import { Component, OnInit } from '@angular/core';
import { ConnectionService } from 'src/app/Services/connection.service';


@Component({
  selector: 'app-poolmembersperformance',
  templateUrl: './poolmembersperformance.component.html',
  styleUrls: ['./poolmembersperformance.component.css']
})
export class PoolmembersperformanceComponent implements OnInit {
   title="View Defaulters";
   page: number=1;
   poolName: any;
  _pool = '';
  totalLength: any;
  item:any;

  constructor(private connection: ConnectionService) { }

  ngOnInit(): void {
    this.GetPools();
    
  }
  GetPools() {
    this.connection.GetPools().subscribe((data: any) => {
      this.poolName = data;
    })
  }

  

 
  }
