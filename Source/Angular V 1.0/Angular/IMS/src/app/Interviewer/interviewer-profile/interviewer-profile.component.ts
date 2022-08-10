import { Component, OnInit } from '@angular/core';
import { ConnectionService } from 'src/app/Services/connection.service';

@Component({
  selector: 'app-interviewer-profile',
  templateUrl: './interviewer-profile.component.html',
  styleUrls: ['./interviewer-profile.component.css']
})

export class InterviewerProfileComponent implements OnInit {
  title = 'My Profile'
  data: any;
  profile = {
    employeeACEId: '',
    employeeDepartment: '',
    employeeEmailID: '',
    employeeName: '',
    employeeProject: '',
    employeeRole: ''
  };
  constructor(private connection: ConnectionService) { }

  ngOnInit(): void {
    this.connection.GetEmployeeProfile().subscribe((data: any) => {
      this.profile = data;
    })
  }

}