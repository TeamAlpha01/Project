
import { Component, Input, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/app/Services/authentication.service';
import { ConnectionService } from 'src/app/Services/connection.service';

@Component({
  selector: 'app-admin-header',
  templateUrl: './admin-header.component.html',
  styleUrls: ['./admin-header.component.css'],
})
export class AdminHeaderComponent implements OnInit {
  //TO GET DATA FROM DATABASE
  userName: string | null = '';
  Name: string = '';

  constructor(private service: AuthenticationService) { }

  ngOnInit(): void {
    this.GetUser();
  }

  GetUser() {
    this.userName = AuthenticationService.GetUserName();
    if (this.userName == null) {
      this.Name = "User"
    }
    else {
      this.Name = this.userName.replace(/"/g, '')
    }
  }

  //THIS METHOD IS CALLED ON CLICK OF LOGOUT BUTTON
  logout() {
    this.service.ClearToken();
  }
}
