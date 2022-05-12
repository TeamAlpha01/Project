import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-view-response-card',
  templateUrl: './view-response-card.component.html',
  styleUrls: ['./view-response-card.component.css']
})
export class ViewResponseCardComponent implements OnInit {
  page: number = 1;
  totalLength:any;
  driveDetail:any[]=[]
  item:any[]=[]
  id:any[]=[]
  @Input()
  data!: any[];


  constructor() { }

  ngOnInit(): void {
  }

}
