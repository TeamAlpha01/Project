import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-admin-adddepartment-page',
  templateUrl: './admin-adddepartment-page.component.html',
  styleUrls: ['./admin-adddepartment-page.component.css']
})
export class AdminAdddepartmentPageComponent implements OnInit {
  data: any;
  totalLength: any;
  page: number = 1;
 
  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.http
      .get<any>('https://localhost:7072/Role/Adddepartment')
      .subscribe((data) => {
        this.data = data;
        this.totalLength = data.length;
      });
  }

}
