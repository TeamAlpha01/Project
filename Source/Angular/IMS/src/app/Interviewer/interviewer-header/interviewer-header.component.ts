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
  logout(){
    this.service.ClearToken();
  }
}