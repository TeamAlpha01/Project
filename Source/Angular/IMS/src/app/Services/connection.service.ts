import { HttpClientModule, HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ConnectionService {
 
  drive: any;
  totalLength: any;

  constructor(private http:HttpClient) { }

  GetDepartment()
  {
    this.http
      .get<any>('https://localhost:7072/Department/ViewDepartments')
      .subscribe((data) => {
        this.drive = data;
        this.totalLength = data.length;
      });
  }

  GetRole()
  {
    this.http
      .get<any>('https://localhost:7072/Role/ViewRoles')
      .subscribe((data) => {
        this.drive = data;
        this.totalLength = data.length;
      });
  }
  CreateRole(data:any){
    console.log(data)
    let httpHeaders = new Headers();
    httpHeaders.append('Content-Type','application/json');
    const body=JSON.stringify(data);
    console.warn(body);
    return this.http.post('https://localhost:7072/Role/CreateNewRole',body)
  }
}

