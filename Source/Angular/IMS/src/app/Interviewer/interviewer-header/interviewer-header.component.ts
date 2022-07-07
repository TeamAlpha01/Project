import { Component, OnInit,Input } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/Services/authentication.service';
import { ConnectionService } from 'src/app/Services/connection.service';

@Component({
  selector: 'app-interviewer-header',
  templateUrl: './interviewer-header.component.html',
  styleUrls: ['./interviewer-header.component.css']
})
export class InterviewerHeaderComponent implements OnInit {
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
  logout(){
    this.service.ClearToken();
  }
}