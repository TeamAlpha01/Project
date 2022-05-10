import { Component, OnInit } from '@angular/core';
import { Role } from 'src/app/Model/Role';
import { ConnectionService } from 'src/app/Services/connection.service';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { data } from 'jquery';

// import { url } from 'inspector';


@Component({
  selector: 'app-admin-role',
  templateUrl: './admin-role.component.html',
  styleUrls: ['./admin-role.component.css']
})
export class AdminRoleComponent implements OnInit {
  role: Role = {
    roleId:0,
    roleName: '',
    isActive:true
  }
  constructor(private createRole: ConnectionService) { }
  addRole() {
    
    this.createRole.CreateRole(this.role).subscribe((data)=>{
      // console.log(data)
    })

  };

  ngOnInit(): void {
  }
  pageTitle = "Role"

}

