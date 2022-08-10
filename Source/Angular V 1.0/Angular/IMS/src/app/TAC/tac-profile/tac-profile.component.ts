import { Component, Input, OnInit } from '@angular/core';

import { Profile } from 'src/app/Model/Profile';
import { ConnectionService } from 'src/app/Services/connection.service';

@Component({
  selector: 'app-tac-profile',
  templateUrl: './tac-profile.component.html',
  styleUrls: ['./tac-profile.component.css']
})

export class TacProfileComponent implements OnInit {
  title = 'Profile';

  public profile: Profile = {
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
