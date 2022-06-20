import { Component, OnInit,Input } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/Services/authentication.service';

@Component({
  selector: 'app-interviewer-header',
  templateUrl: './interviewer-header.component.html',
  styleUrls: ['./interviewer-header.component.css']
})
export class InterviewerHeaderComponent implements OnInit {
  @Input() CurrentNavigationPage: string = '';

  IsHomePage: boolean = false;
  IsProfilePage: boolean = false;
  IsDashboardPage: boolean = false;
  IsDriveInvitesPage: boolean = false;

  constructor(private service : AuthenticationService) {}

  ngOnInit(): void {
    this.SetCurrentPage(this.CurrentNavigationPage);

  }
  SetCurrentPage(CurrentNavigationPage: string) {
    switch (CurrentNavigationPage) {
      case 'HomePage': {
        this.IsHomePage = true;
        break;
      }
      case 'ProfilePage': {
        this.IsProfilePage = true;
        break;
      }
      case 'DashboardPage': {
        this.IsDashboardPage = true;
        break;
      }
      case 'DriveInvitesPage': {
        this.IsDriveInvitesPage = true;
        break;
      }
      
    }
  }
  logout(){
    this.service.ClearToken();
  }
}