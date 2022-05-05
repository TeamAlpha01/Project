import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-card-details',
  templateUrl: './card-details.component.html',
  styleUrls: ['./card-details.component.css']
})
export class CardDetailsComponent implements OnInit {
  page: number = 1;
  totalLength:any;
  
  @Input()
  data!: any[];
  constructor() { }

  ngOnInit(): void {
  }
  drive!: any[]
  // drive: any[] = [{
  //   driveName: 'freshers 2021',
  //   department: 'asd',
  //   poolName: '',
  //   date: 0,
  //   mode: '',
  //   location: ''
  // }, {
  //   driveName: 'freshers 2022',
  //   department: 'fgh',
  //   poolName: '',
  //   date: 0,
  //   mode: '',
  //   location: ''
  // }]
}
