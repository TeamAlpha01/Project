import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-drive-detail-card',
  templateUrl: './drive-detail-card.component.html',
  styleUrls: ['./drive-detail-card.component.css']
})
export class DriveDetailCardComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }
  driveName:string='as';
  department:string='';
  poolName:string='';
  date:number=0;
  mode:string='';
  location:string='';

  


}
