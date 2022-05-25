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

  //GET methods
  GetDepartments(): any {
    return this.http.get<any>(this.baseURL+'Department/ViewDepartments');
  }  
  
  GetTodayDrives(): any {
    return this.http.get<any>(this.baseURL+'Drive/ViewTodayDrives');
  }

  GetEmployees(){
    return this.http.get<any>(this.baseURL+'Employee/ViewEmployees');
  }

  GetEmployeeProfile(){
    return this.http.get<any>(this.baseURL+'Employee/ViewProfile?employeeId=1');
   }

  GetLocations(): any {
    return this.http.get<any>(this.baseURL+'Location/ViewLocations');
  }

  GetPools(): any {
    return this.http.get<any>(this.baseURL+'Pool/ViewPools');
  }

  GetPoolMembers(pool: any): any {
    return this.http.get<any>(this.baseURL+`Pool/ViewPoolMembers?poolId=${pool}`);
  }

  GetProfile(): any {
    return this.http.get<any>(this.baseURL+'Employee/ViewProfile?employeeId=4');
  }

  GetProjects(): any {
    return this.http.get<any>(this.baseURL+'Project/ViewProjects');
  }

  GetRoles(): any {
    return this.http.get<any>(this.baseURL+'Role/ViewRoles');
  }

  GetScheduledDrives(): any {
    return this.http.get<any>(this.baseURL+'Drive/ViewScheduledDrives');
  }

  GetUpcomingDrives(): any {
    return this.http.get<any>(this.baseURL+'Drive/ViewUpcommingDrives');
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

