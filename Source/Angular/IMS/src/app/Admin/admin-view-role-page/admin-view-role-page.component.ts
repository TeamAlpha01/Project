import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-admin-view-role-page',
  templateUrl: './admin-view-role-page.component.html',
  styleUrls: ['./admin-view-role-page.component.css']
})
export class AdminViewRolePageComponent implements OnInit {
  data: any;
  totalLength: any;
  page: number = 1;
  title:string='View Role';
 
  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.http
      .get<any>('https://localhost:7072/Role/ViewRoles')
      .subscribe((data) => {
        this.data = data;
        this.totalLength = data.length;
      });
  }

}
