import { Component, Input, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/app/Services/authentication.service';
import { ConnectionService } from 'src/app/Services/connection.service';

@Component({
  selector: 'app-tac-header',
  templateUrl: './tac-header.component.html',
  styleUrls: ['./tac-header.component.css']
})
export class TacHeaderComponent implements OnInit {

  constructor(private service: AuthenticationService, private connection: ConnectionService) { }

  profile = {
    employeeACEId: '',
    employeeDepartment: '',
    employeeEmailID: '',
    employeeName: '',
    employeeProject: '',
    employeeRole: ''
  };
  ngOnInit(): void {
    this.GetUser();
  }

  GetUser() {
    this.connection.GetEmployeeProfile().subscribe((data: any) => {
      this.profile = data;
    })
  }

  logout() {
    this.service.ClearToken();
  }
}
