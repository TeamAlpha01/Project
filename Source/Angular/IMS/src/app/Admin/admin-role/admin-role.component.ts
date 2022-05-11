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
 
  constructor(private http: HttpClient) { }
  
_roleName=''
  ngOnInit(): void {
  }
  pageTitle = "Role"
addRole(){
  this.http.post<any>(`https://localhost:7072/Role/CreateNewRole?roleName= ${this._roleName}`,this._roleName)
  .subscribe((data)=>{
    console.log(data)
  });

}
}

