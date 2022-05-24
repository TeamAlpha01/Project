import { Component, OnInit } from '@angular/core';
import { ConnectionService } from 'src/app/Services/connection.service';

@Component({
  selector: 'app-tac-edit-pool-member',
  templateUrl: './tac-edit-pool-member.component.html',
  styleUrls: ['./tac-edit-pool-member.component.css']
})
export class TacEditPoolMemberComponent implements OnInit {
  title = 'Current Drive'

  //To get the inputs from the user
  _dept = '';
  _pool = '';
  _role = '';

  //To get the details from the db
  roleDetails: any;
  poolDetails: any;
  poolMembers: any;
  departmentDetails: any;

  constructor(private connection: ConnectionService) { }

  ngOnInit(): void {
    this.connection.GetRoles().subscribe((data: any) => {
      this.roleDetails = data;
    })
    this.connection.GetPools().subscribe((data: any) => {
      this.poolDetails = data;
    })
    this.connection.GetDepartments().subscribe((data: any) => {
      this.departmentDetails = data;
    })
    this.connection.GetPoolMembers().subscribe((data: any) => {
      this.poolMembers = data;
    })
  }
  filterDropdown() {

  }

}
