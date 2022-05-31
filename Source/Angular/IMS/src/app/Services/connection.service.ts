import { HttpClientModule, HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuthenticationService } from 'src/app/Services/authentication.service';


@Injectable({
  providedIn: 'root'
})
export class ConnectionService {

  drive: any;
  totalLength: any;
  department: any;
  role: any;
  profile: any;
  employeeDetails: any;
  employeeACENumber = ''
  employeeID = '1'
  baseURL = 'https://localhost:7072/'
  constructor(private http: HttpClient) { }

  private headers = new HttpHeaders({
    'Content-Type': 'application/json',
    'Authorization': `Bearer ${AuthenticationService.GetData("token")}`
  })

  private header = new HttpHeaders({
    'Content-Type': 'application/json',
  })

  GetEmployeeID(): any {
    this.GetEmployees().subscribe((data: any) => {
      this.employeeDetails = data;
      for (let item of this.employeeDetails) {
        if (this.employeeACENumber == item.employeeAceNumber) {
          this.employeeID = item.employeeId   
          console.warn(this.employeeID)         
        }
      }
    })
  }

  //GET methods
  GetDashboard(): any {
    return this.http.get<any>(this.baseURL + `Drive/ViewEmployeeDashboard?employeeId=${this.employeeID}`);
  }

  GetDepartments(): any {

    return this.http.get<any>(this.baseURL + 'Department/ViewDepartments', { headers: this.headers });
  }

  GetEmployees() {
    return this.http.get<any>(this.baseURL + 'Employee/ViewEmployees');
  }

  GetEmployeeProfile() {
    console.warn(this.employeeID);
    return this.http.get<any>(this.baseURL + `Employee/ViewProfile?employeeId=${this.employeeID}`);
  }

  GetLocations(): any {
    return this.http.get<any>(this.baseURL + 'Location/ViewLocations');
  }

  GetPools(): any {
    return this.http.get<any>(this.baseURL + 'Pool/ViewPools');
  }

  GetPoolMembers(pool: any): any {
    return this.http.get<any>(this.baseURL + `Pool/ViewPoolMembers?poolId=${pool}`);
  }

  GetProjects(): any {
    return this.http.get<any>(this.baseURL + 'Project/ViewProjects');
  }

  GetRoles(): any {
    return this.http.get<any>(this.baseURL + 'Role/ViewRoles');
  }

  GetScheduledDrives(): any {
    return this.http.get<any>(this.baseURL + 'Drive/ViewScheduledDrives');
  }

  GetTodayDrives(): any {
    return this.http.get<any>(this.baseURL + 'Drive/ViewTodayDrives');
  }

  GetUpcomingDrives(): any {
    return this.http.get<any>(this.baseURL + 'Drive/ViewUpcommingDrives');
  }

  Login(user: any) {
    this.employeeACENumber=user.ACENumber;
    this.GetEmployeeID();
    return this.http.post<any>(`https://localhost:7072/Token/AuthToken/Login?employeeAceNumber=${user.ACENumber}&password=${user.Password}`, user, { headers: this.header })
  }


  CreateEmployee(user: any) {
    console.warn(user);
    const headers = { 'content-type': 'application/json' }
    this.http.post<any>('https://localhost:7072/Employee/CreateNewEmployee', user, { headers: headers })

  }




}

