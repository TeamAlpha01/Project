import { Role } from './../../Model/Role';
import { Department } from './../../Model/Department';
import { Component, Input, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/app/Services/authentication.service';

@Component({
  selector: 'app-admin-header',
  templateUrl: './admin-header.component.html',
  styleUrls: ['./admin-header.component.css'],
})
export class AdminHeaderComponent implements OnInit {
  @Input() CurrentNavigationPage: string = '';

  IsDepartmentPage: boolean = false;
  IsLocationPage: boolean = false;
  IsRolePage: boolean = false;
  IsProjectPage: boolean = false;
  IsRequestPage: boolean = false;

  constructor(private service: AuthenticationService) {}

  ngOnInit(): void {
    this.SetCurrentPage(this.CurrentNavigationPage);
  }
  SetCurrentPage(CurrentNavigationPage: string) {
    switch (CurrentNavigationPage) {
      case 'DepartmentPage': {
        this.IsDepartmentPage = true;
        break;
      }
      case 'LocationPage': {
        this.IsLocationPage = true;
        break;
      }
      case 'RolePage': {
        this.IsRolePage = true;
        break;
      }
      case 'ProjectPage': {
        this.IsProjectPage = true;
        break;
      }
      case 'RequestPage': {
        this.IsRequestPage = true;
        break;
      }
    }
  }
  logout(){
    this.service.ClearToken();
  }
}
