import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Department } from 'src/app/Model/Department';

@Component({
  selector: 'app-admin-adddepartment',
  templateUrl: './admin-adddepartment.component.html',
  styleUrls: ['./admin-adddepartment.component.css']
})
export class AdminAdddepartmentComponent implements OnInit {
  title='Add Department'

constructor(private http: HttpClient) { }

_department=''

addDepartment(){
  this.http.post<any>(`https://localhost:7072/Deparment/CreateNewDeparment?departmentName=${this._department}`,this._department)

  .subscribe((data) => {
    console.log(data)
  }
  )
}

ngOnInit(): void {
}


}

