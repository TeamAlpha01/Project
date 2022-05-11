import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { ConnectionService } from 'src/app/Services/connection.service';

@Component({
  selector: 'app-admin-view-role-page',
  templateUrl: './admin-view-role-page.component.html',
  styleUrls: ['./admin-view-role-page.component.css']
})
export class AdminViewRolePageComponent implements OnInit {
  data: any;
  totalLength: any;
  page: number = 1;
  title: string = 'View Role';
  role!: any[]


  constructor(private http: HttpClient) { }

//  this.data=this.connection.GetRole()

     
  ngOnInit() {

    //  this.data=this.connection.GetRole()
    this.http
      .get<any>('https://localhost:7072/Role/ViewRoles')
      .subscribe((data) => {
        this.role = data;
        console.log(this.role)
        return this.role
      });
  }

}
