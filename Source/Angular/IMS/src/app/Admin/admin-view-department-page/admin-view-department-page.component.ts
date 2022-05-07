import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
@Component({
  selector: 'app-admin-view-department-page',
  templateUrl: './admin-view-department-page.component.html',
  styleUrls: ['./admin-view-department-page.component.css']
})


export class AdminViewDepartmentPageComponent implements OnInit {
  data: any;
  totalLength: any;
  page: number = 1;
  title ="View Department";
 
  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    // this.http
    //   .get<any>('https://localhost:7072/Role/Adddepartment')
    //   .subscribe((data) => {
    //     this.data = data;
    //     this.totalLength = data.length;
    //   });
  }

}