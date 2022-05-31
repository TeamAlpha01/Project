import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';



@Component({
  selector: 'app-interviewer-header',
  templateUrl: './interviewer-header.component.html',
  styleUrls: ['./interviewer-header.component.css']
})
export class InterviewerHeaderComponent implements OnInit {

  constructor(private router: Router) {}

  ngOnInit(): void {
  }
  userName='';
  
 
 
  
}
