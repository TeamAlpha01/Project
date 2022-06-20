import { Component, Input, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/app/Services/authentication.service';

@Component({
  selector: 'app-tac-header',
  templateUrl: './tac-header.component.html',
  styleUrls: ['./tac-header.component.css']
})
export class TacHeaderComponent implements OnInit {

  constructor(private service:AuthenticationService) { }

  ngOnInit(): void {
  }

  

  logout(){
    this.service.ClearToken();
  }
}
