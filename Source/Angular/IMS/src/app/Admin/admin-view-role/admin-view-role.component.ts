import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-admin-view-role',
  templateUrl: './admin-view-role.component.html',
  styleUrls: ['./admin-view-role.component.css']
})
export class AdminViewRoleComponent implements OnInit {
  data: any;
  totalLength: any;
  page: number = 1;
 
  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.http
      .get<any>('https://localhost:7072/Role/ViewRoles')
      .subscribe((data) => {
        this.data = data;
        this.totalLength = data.length;
        console.log(this.totalLength);
      });
  }

}
