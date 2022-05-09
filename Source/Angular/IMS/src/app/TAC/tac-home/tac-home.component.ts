import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-tac-home',
  templateUrl: './tac-home.component.html',
  styleUrls: ['./tac-home.component.css']
})
export class TacHomeComponent implements OnInit {
   
  title ='Home'
  constructor() { }

  ngOnInit(): void {
  }

}
