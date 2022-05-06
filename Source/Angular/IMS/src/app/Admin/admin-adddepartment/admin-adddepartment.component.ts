import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-admin-adddepartment',
  templateUrl: './admin-adddepartment.component.html',
  styleUrls: ['./admin-adddepartment.component.css']
})
export class AdminAdddepartmentComponent implements OnInit {
  department: Department ={
      departmentName:'';
  }
  }
  constructor(private http:HttpClient) { }
  addDepartment(){
    console.log(this.department)
  }

  ngOnInit(): void {
  }
  pageTitle = "Department"

}
