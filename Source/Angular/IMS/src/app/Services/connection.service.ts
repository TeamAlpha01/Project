import { HttpClientModule, HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuthenticationService } from 'src/app/Services/authentication.service';


@Injectable({
  providedIn: 'root'
})
export class ConnectionService {
 
  baseURL = 'https://localhost:7072/'
  constructor(private http: HttpClient) { }

  private headers = new HttpHeaders({
    'Content-Type': 'application/json',
    'Authorization': `Bearer ${AuthenticationService.GetData("token")}`
  })



  //GET methods

  GetCancelledDrives(): any {
    return this.http.get<any>(this.baseURL + 'Drive/ViewAllCancelledDrives', { headers: this.headers });
  }

  GetDashboard(): any {
    return this.http.get<any>(this.baseURL + `Drive/ViewEmployeeDashboard`, { headers: this.headers });
  }

  GetDepartments(): any {
    return this.http.get<any>(this.baseURL + 'Department/ViewDepartments', { headers: this.headers });
  }

  GetDrive(driveId:number): any {
    return this.http.get<any>(this.baseURL + `Drive/ViewDrive?driveId=${driveId}`, { headers: this.headers });
  }  

  GetEmployees() {
    return this.http.get<any>(this.baseURL + 'Employee/ViewEmployees', { headers: this.headers });
  }

  GetEmployeeProfile() {
    return this.http.get<any>(this.baseURL + `Employee/ViewProfile?employeeId=11`, { headers: this.headers });
  }

  GetLocations(): any {
    return this.http.get<any>(this.baseURL + 'Location/ViewLocations', { headers: this.headers });
  }

  GetNonCancelledDrives(): any {
    return this.http.get<any>(this.baseURL + 'Drive/ViewNonCancelledDrives', { headers: this.headers });
  }

  GetPools(): any {
    return this.http.get<any>(this.baseURL + 'Pool/ViewPools', { headers: this.headers });
  }

  GetPoolMembers(pool: any): any {
    return this.http.get<any>(this.baseURL + `Pool/ViewPoolMembers?poolId=${pool}`, { headers: this.headers });
  }

  GetProjects(): any {
    return this.http.get<any>(this.baseURL + 'Project/ViewProjects', { headers: this.headers });
  }

  GetRoles(): any {
    return this.http.get<any>(this.baseURL + 'Role/ViewRoles', { headers: this.headers });
  }

  GetScheduledDrives(): any {
    return this.http.get<any>(this.baseURL + 'Drive/ViewScheduledDrives', { headers: this.headers });
  }

  GetTACDashboard(): any {
    return this.http.get<any>(this.baseURL + `Drive/ViewDashboard?tacId=11`, { headers: this.headers });
  }

  GetTodayDrives(): any {
    return this.http.get<any>(this.baseURL + 'Drive/ViewTodayDrives', { headers: this.headers });
  }

  GetUpcomingDrives(): any {
    return this.http.get<any>(this.baseURL + 'Drive/ViewUpcommingDrives', { headers: this.headers });
  }

  GetEmployeeRequests(): any{
    return this.http.get<any>('https://localhost:7072/Employee/ViewEmployeeRequest')

  }


  //POST methods
  Login(user: any) {
    return this.http.post<any>(`https://localhost:7072/Token/AuthToken/Login?employeeAceNumber=${user.ACENumber}&password=${user.Password}`, user, { headers: this.headers })
  }

  CreateNewProject(user: any) {
    this.http.post<any>('https://localhost:7072/Project/CreateNewProject', user, { headers: this.headers })

  }

  CreateEmployee(user: any) {
    this.http.post<any>('https://localhost:7072/Employee/CreateNewEmployee', user, { headers: this.headers })

  }

  CancelDrive(driveId:number, reason:string){
    return this.http.patch<any>(this.baseURL+`Drive/CancelDrive?driveId=${driveId}&tacId=11&reason=${reason}`, driveId, { headers: this.headers });
    
  }
  //Admin
  AddLocation(locationName:string)
  {
    return this.http.post<any>(`https://localhost:7072/Location/CreateNewLocation?locationName=${locationName}`,  null, { headers: this.headers })
  }

  //Patch Methods
  //Admin
  RespondEmployeeRequest(employeeId:number,response:boolean)
  {
    return this.http.patch<any>(`https://localhost:7072/Employee/RespondEmployeeRequest?employeeId=${employeeId}&response=${response}`,null,{ headers: this.headers })
  }
  
  RemoveLocation(employeeId:number)
  {
    return this.http.patch<any>(`https://localhost:7072/Location/RemoveLocation?locationId=${employeeId}`,null,{ headers: this.headers })
  }
}

