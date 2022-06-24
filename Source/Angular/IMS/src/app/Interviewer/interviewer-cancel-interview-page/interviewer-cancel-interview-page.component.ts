import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-interviewer-cancel-interview-page',
  templateUrl: './interviewer-cancel-interview-page.component.html',
  styleUrls: ['./interviewer-cancel-interview-page.component.css']
})
export class InterviewerCancelInterviewPageComponent implements OnInit {

  title='Cancel Interview'

  @Input() name!: any[];
  page:number=1
  totalLength:any
  state:any[]=[]
  
  constructor() { }

  ngOnInit(): void {
    console.log(this.state);
  }

}
