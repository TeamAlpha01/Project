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
    let httpHeaders = new HttpHeaders();
    httpHeaders.append('Content-Type','application/json');
    return this.http.post('https://localhost:7072/Role/CreateNewRole',data,{headers:httpHeaders})
  }
}

