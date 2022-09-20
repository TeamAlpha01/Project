import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/app/Services/authentication.service';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {

  userName: string | null = '';
  Name: string = '';
  Role:string='';


  constructor(private service: AuthenticationService) { }

  ngOnInit(): void {
    this.GetUser();
  }

  GetUser() {
    this.userName = AuthenticationService.GetUserName();
    this.Role = AuthenticationService.GetUser();
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
