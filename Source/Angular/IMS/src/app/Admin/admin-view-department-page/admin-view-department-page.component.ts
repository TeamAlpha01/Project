import { LoginComponent } from './../../Shared/login/login.component';
import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { ConnectionService } from 'src/app/Services/connection.service';

@Component({
  selector: 'app-admin-viewDepartment-page',
  templateUrl: './admin-view-Department-page.component.html',
  styleUrls: ['./admin-view-department-page.component.css'],
})
export class AdminviewDepartmentPageComponent implements OnInit {
  title = 'Departments';
  department: any;
  totalLength: any;
  page: number = 1;
  constructor(private service: ConnectionService) {}

  ngOnInit(): void {
    this.GetDepartments();
  }

  removeDepartment(departmentId: number) {
    this.service
      .RemoveDepartment(departmentId)
      .subscribe(() => this.GetDepartments());
  }

  GetDepartments() {
    this.service.GetDepartments().subscribe((data: any) => {
      this.department = data;
      this.totalLength= data.length;
    });
  }
}
