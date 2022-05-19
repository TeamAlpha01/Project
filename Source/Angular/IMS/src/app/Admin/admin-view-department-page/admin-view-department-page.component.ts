import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { ConnectionService } from 'src/app/Services/connection.service';

@Component({
  selector: 'app-admin-viewDepartment-page',
  templateUrl: './admin-view-Department-page.component.html',
  styleUrls: ['./admin-view-department-page.component.css']
})
export class AdminviewDepartmentPageComponent implements OnInit {
  data: any;
  totalLength: any;
  page: number = 1;
  title ="View Department";
 
 
  constructor(private http: HttpClient, private connection:ConnectionService) { }

  ngOnInit(): void {
    this.connection.GetDepartments().subscribe((data: any) => {
      this.data = data;
      console.log(this.data)
    })
  }

}