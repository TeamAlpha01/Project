import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-history-card',
  templateUrl: './history-card.component.html',
  styleUrls: ['./history-card.component.css']
})
export class HistoryCardComponent implements OnInit {

  page: number = 1;
  totalLength: any;

  @Input() data!: any[];
  @Input() title: string = '';

  constructor() { }

  ngOnInit(): void {
  }

}
