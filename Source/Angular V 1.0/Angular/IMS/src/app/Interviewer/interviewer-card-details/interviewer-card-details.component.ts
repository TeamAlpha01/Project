import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-interviewer-card-details',
  templateUrl: './interviewer-card-details.component.html',
  styleUrls: ['./interviewer-card-details.component.css']
})
export class InterviewerCardDetailsComponent implements OnInit {
  page: number = 1;
  totalLength: any;
  driveDetail: any[] = []
  item: any[] = []
  id: any[] = []
  @Input()
  data!: any[];

  @Input()
  Page!: string;

  constructor() { }

  ngOnInit(): void {
  }

}
