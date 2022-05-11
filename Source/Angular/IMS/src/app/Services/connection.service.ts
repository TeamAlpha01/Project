import { HttpClientModule, HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ConnectionService {

  drive: any;
  totalLength: any;
  department: any;
  role: any;
  baseURL = 'https://localhost:7072/'
  constructor(private http: HttpClient) { }

  GetDepartment() {
    this.http
      .get<any>(this.baseURL +'Department/ViewDepartments')
      .subscribe((data) => {
        this.department = data;
      });
  }

  GetRole() {
    this.http
      .get<any>(this.baseURL + 'Role/ViewRoles')
      .subscribe((data) => {
        this.role = data;
        return this.role
      });
  }

  CreateRole(data: any) {
    console.log(data)
    let httpHeaders = new Headers();
    httpHeaders.append('Content-Type', 'application/json');
    // const body=JSON.stringify(data);
    // console.warn(body);
    return this.http.post('https://localhost:7072/Role/CreateNewRole', data)
  }
}

