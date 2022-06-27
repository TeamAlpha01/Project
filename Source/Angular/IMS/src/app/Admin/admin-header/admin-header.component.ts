
import { Component, Input, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/app/Services/authentication.service';

@Component({
  selector: 'app-admin-header',
  templateUrl: './admin-header.component.html',
  styleUrls: ['./admin-header.component.css'],
})
export class AdminHeaderComponent implements OnInit {


  constructor(private service: AuthenticationService) {}

  ngOnInit(): void {
  
  }
  logout(){
    this.service.ClearToken();
  }
}
