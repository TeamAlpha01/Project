import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-admin-viewDepartment-page',
  templateUrl: './admin-view-Department-page.component.html',
  styleUrls: ['./admin-view-Department-page.component.css']
})
export class AdminviewDepartmentPageComponent implements OnInit {
  data: any;
  totalLength: any;
  page: number = 1;
 
  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.http
      .get<any>('https://localhost:7072/Role/view-department')
      .subscribe((data) => {
        this.data = data;
        this.totalLength = data.length;
      });
  }

}
