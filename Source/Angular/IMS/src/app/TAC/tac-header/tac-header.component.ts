import { Component, Input, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/app/Services/authentication.service';

@Component({
  selector: 'app-tac-header',
  templateUrl: './tac-header.component.html',
  styleUrls: ['./tac-header.component.css']
})
export class TacHeaderComponent implements OnInit {
  @Input() CurrentNavigationPage: string = '';


  IsHomePage: boolean = false;
  IsProfilePage: boolean = false;
  IsDashboardPage: boolean = false;
  IsManagePoolPage: boolean = false;
  IsCreateInvitePage: boolean = false;

  constructor(private service:AuthenticationService) { }

  ngOnInit(): void {
    this.SetCurrentPage(this.CurrentNavigationPage);
  }

  SetCurrentPage(CurrentNavigationPage: string) {
    console.warn(CurrentNavigationPage);
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
      case 'ManagePoolPage': {
        this.IsManagePoolPage = true;
        break;
      }
      case 'CreateInvitePage': {
        this.IsCreateInvitePage = true;
        break;
      }
    }
  }

  logout(){
    this.service.ClearToken();
  }
}
