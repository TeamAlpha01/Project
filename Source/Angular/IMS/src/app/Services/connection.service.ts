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
  profile: any;
  baseURL = 'https://localhost:7072/'
  constructor(private http: HttpClient) { }

  GetDepartment() {
    return this.http.get<any>(this.baseURL+'Deparment/ViewDepartments');
  }

  GetRole(): any {
    return this.http.get<any>(this.baseURL+'Role/ViewRoles');
  }

  CreateRole(data: any) {
    console.log(data)
    let httpHeaders = new Headers();
    httpHeaders.append('Content-Type', 'application/json');
    // const body=JSON.stringify(data);
    // console.warn(body);
    return this.http.post('https://localhost:7072/Role/CreateNewRole', data)
  }

  GetEmployeeProfile(){
   return this.http.get<any>('https://localhost:7072/Employee/ViewProfile?employeeId=1')
    
  }
}

