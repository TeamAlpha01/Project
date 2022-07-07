import { Component, Input, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/app/Services/authentication.service';
import { ConnectionService } from 'src/app/Services/connection.service';

@Component({
  selector: 'app-tac-header',
  templateUrl: './tac-header.component.html',
  styleUrls: ['./tac-header.component.css']
})
export class TacHeaderComponent implements OnInit {
  userName: string | null = '';
  Name: string = '';

  constructor(private service: AuthenticationService, private connection: ConnectionService) { }

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



  logout() {
    this.service.ClearToken();
  }
}
