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
  isManagement:boolean=false

  constructor(private service: AuthenticationService) { }

  ngOnInit(): void {
    this.GetUser();
  }



  GetUser() {
    this.userName = AuthenticationService.GetUserName();
    this.isManagement = AuthenticationService.GetData("Management")?true:false;
    if (this.userName == null) {
      this.Name = "User"
    }
    else {
      this.Name = this.userName.replace(/"/g, '')
    }
  }

  //THIS METHOD IS CALLED ON CLICK OF LOGOUT BUTTTON
  logout(){
    this.service.ClearToken();
  }
}