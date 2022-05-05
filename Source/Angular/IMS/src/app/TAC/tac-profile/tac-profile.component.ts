import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-tac-profile',
  templateUrl: './tac-profile.component.html',
  styleUrls: ['./tac-profile.component.css']
})
export class TacProfileComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }
  Name:string='Prithvi';
  email:string='Prithvi@aspiresys.com';
  Contact:number=9876543210;
  Id:string='ACE123';
  Department:string='.net';
  Role:string='SSE';
}
