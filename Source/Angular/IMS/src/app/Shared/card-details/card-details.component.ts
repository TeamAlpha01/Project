import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-card-details',
  templateUrl: './card-details.component.html',
  styleUrls: ['./card-details.component.css']
})
export class CardDetailsComponent implements OnInit {
  page: number = 1;
  totalLength:any;

  @Input()  data!: any[];
  @Input()  response:boolean=false
  

  


  
  constructor() { }

  ngOnInit(): void {
    
  }


}
