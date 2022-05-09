import { Component, OnInit } from '@angular/core';
import { Role } from 'src/app/Model/Role';
import { HttpClient, HttpClientModule } from '@angular/common/http';

// import { url } from 'inspector';


@Component({
  selector: 'app-admin-role',
  templateUrl: './admin-role.component.html',
  styleUrls: ['./admin-role.component.css']
})
export class AdminRoleComponent implements OnInit {
  role: Role = {
    roleName: '',
  }
  constructor(private http: HttpClient) { }
  addRole() {
    console.log(this.role)
    
    this.http
      .post<any>('https://localhost:7072/Role/CreateNewRole',this.role.roleName)
      .subscribe((data) => {
        // this.role = data;
        data =this.role;
        
      });
  }
  ngOnInit(): void {
  }
  pageTitle = "Role"

}

