import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-admin-view-adddepartment-page',
  templateUrl: './admin-view-adddepartment-page.component.html',
  styleUrls: ['./admin-view-adddepartment-page.component.css']
})
export class AdminViewAdddepartmentPageComponent implements OnInit {
  data: any;
  totalLength: any;
  page: number = 1;
 
  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.http
      .get<any>('https://localhost:7072/Role/ViewAdddepartment')
      .subscribe((data) => {
        this.data = data;
        this.totalLength = data.length;
      });
  }

}
