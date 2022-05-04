import { Component, OnInit } from '@angular/core';
import { Role } from '../role.model';
import { RoleService } from '../role.service';

@Component({
  selector: 'app-admin-role',
  templateUrl: './admin-role.component.html',
  styleUrls: ['./admin-role.component.css']
})
export class AdminRoleComponent implements OnInit {

  constructor(public service:RoleService) { }

  ngOnInit(): void {
  }
pageTitle = "Role"
      
}

