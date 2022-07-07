import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ConnectionService } from 'src/app/Services/connection.service';

@Component({
  selector: 'app-view-defaulters',
  templateUrl: './view-defaulters.component.html',
  styleUrls: ['./view-defaulters.component.css']
})
export class ViewDefaultersComponent implements OnInit {
  title = "View Defaulters";
  poolDetails: any;
  _pool = '';
  page: number = 1;
  totalLength: any;
  poolId: any;

  constructor(private connection: ConnectionService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.poolId = params['poolId']
    });
    this.GetPools();

  }
  GetPools() {
    this.connection.GetDefaulters(this.poolId).subscribe((data: any) => {
      this.poolDetails = data;
      console.warn(this.poolDetails);
    })
  }
}
