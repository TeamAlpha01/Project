
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuthenticationService } from 'src/app/Services/authentication.service';


@Injectable({
  providedIn: 'root'
})
export class ConnectionService {

  // baseURL = 'http://172.24.217.145/IMS-API/'
  baseURL = 'https://localhost:7072/'

  constructor(private http: HttpClient) { }

  public headers = new HttpHeaders({
    'Content-Type': 'application/json',
    'Authorization': `Bearer ${AuthenticationService.GetData('token')}`
  })

  initializeTokenHeader(token: string | null) {
    this.headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    })
  }

  logout() {
    this.headers = new HttpHeaders();
  }

  //GET methods

  GetAcceptedDrives(date: any): any {
    return this.http.post<any>(this.baseURL + 'Drive/ViewAcceptedDrives', date, { headers: this.headers });
  }

  GetAvailability(driveId: number): any {
    return this.http.get<any>(this.baseURL + `Drive/ViewAvailabilty?driveId=${driveId}`, { headers: this.headers });
  }

  GetCancelledinterviews(date: any): any {
    return this.http.post<any>(this.baseURL + 'Drive/ViewCancelledInterview', date, { headers: this.headers });
  }

  GetCancelledDrives(date: any): any {
    return this.http.post<any>(this.baseURL + 'Drive/ViewAllCancelledDrives', date, { headers: this.headers });
  }

  GetDashboard(date: any): any {
    return this.http.post<any>(this.baseURL + `Drive/ViewEmployeeDashboard`, date, { headers: this.headers });
  }

  GetDashboardDriveResponse(driveId: number): any {
    return this.http.get<any>(this.baseURL + `Drive/ViewDriveResponse?driveId=${driveId}`, { headers: this.headers });
  }

  GetDefaulters(poolId: number): any {
    return this.http.get<any>(this.baseURL + `Drive/ViewDefaulters?poolId=${poolId}`, { headers: this.headers });
  }

  GetDepartments(): any {
    return this.http.get<any>(this.baseURL + 'Department/ViewDepartments', { headers: this.headers });
  }

  GetDrive(driveId: number): any {
    return this.http.get<any>(this.baseURL + `Drive/ViewDrive?driveId=${driveId}`, { headers: this.headers });
  }

  GetDriveResponse(driveId: number) {
    return this.http.get<any>(this.baseURL + `Drive/ViewAvailableMembersForDrive?driveId=${driveId}`, { headers: this.headers });
  }

  GetDriveById(driveId: any) {
    return this.http.get<any>(this.baseURL + `Drive/ViewDrive?driveId=${driveId}`, { headers: this.headers });
  }

  GetDriveInvitesById() {
    return this.http.get<any>(this.baseURL + `Drive/ViewInvitesByID`, { headers: this.headers });
  }

  GetEmployees() {
    return this.http.get<any>(this.baseURL + 'Employee/ViewEmployees', { headers: this.headers });
  }

  GetEmployeeDashboard(employeeId: number) {
    return this.http.get<any>(this.baseURL + `Drive/ViewEmployeeDashboard?employeeId=${employeeId}`, { headers: this.headers });
  }

  GetEmployeePerformance(dateRange: any): any {
    return this.http.post<any>(this.baseURL + 'Drive/ViewEmployeePerformance', dateRange, { headers: this.headers });
  }

  GetEmployeeProfile() {
    return this.http.get<any>(this.baseURL + `Employee/ViewEmployeeProfile`, { headers: this.headers });
  }

  GetEmployeeRequests(): any {
    return this.http.get<any>(this.baseURL + 'Employee/ViewEmployeeRequest', { headers: this.headers });
  }

  GetDeniedDrives(date: any): any {
    return this.http.post<any>(this.baseURL + 'Drive/ViewDeniedDrives', date, { headers: this.headers });
  }

  GetDrivesForCurrentUser(): any {
    return this.http.get<any>(this.baseURL + 'Drive/GetDrivesForCurrentUser', { headers: this.headers });
  }

  GetDepartmentEmployeesForCurrentUser(): any {
    return this.http.get<any>(this.baseURL + 'Employee/ViewEmployeesByDepartmentForCurrentUser', { headers: this.headers });
  }

  GetIgnoredDrives(date: any): any {
    return this.http.post<any>(this.baseURL + 'Drive/ViewIgnoredDrives', date, { headers: this.headers });
  }

  GetLocations(): any {
    return this.http.get<any>(this.baseURL + 'Location/ViewLocations', { headers: this.headers });
  }

  GetNonCancelledDrives(date: any): any {
    return this.http.post<any>(this.baseURL + 'Drive/ViewNonCancelledDrives', date, { headers: this.headers });
  }

  GetNotUtilizedInterviews(date: any): any {
    return this.http.post<any>(this.baseURL + 'Drive/ViewNotUtilizedInterviews', date, { headers: this.headers });
  }

  GetPools(): any {
    return this.http.get<any>(this.baseURL + 'Pool/ViewPools', { headers: this.headers });
  }

  GetPoolsbyId(): any {
    return this.http.get<any>(this.baseURL + 'Pool/ViewPoolsByID', { headers: this.headers });
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

  GetSlotAvailability(date: any): any {
    return this.http.post<any>(this.baseURL + 'Drive/ViewTotalAvailability', date, { headers: this.headers });
  }

  GetScheduledDrives(): any {
    return this.http.get<any>(this.baseURL + 'Drive/ViewScheduledDrives', { headers: this.headers });
  }

  GetTACDashboard(date: any): any {
    return this.http.post<any>(this.baseURL + `Drive/ViewDashboard`, date, { headers: this.headers });
  }

  GetTodayDrives(): any {
    return this.http.get<any>(this.baseURL + 'Drive/ViewTodayDrives', { headers: this.headers });
  }

  GetTotalDrives(date: any): any {
    return this.http.post<any>(this.baseURL + 'Drive/ViewTotalDrives', date, { headers: this.headers });
  }

  GetTodaysInterviews(): any {
    return this.http.get<any>(this.baseURL + 'Drive/ViewTodaysInterview', { headers: this.headers });
  }

  GetScheduledInterviews(): any {
    return this.http.get<any>(this.baseURL + 'Drive/ViewScheduledInterview', { headers: this.headers });
  }

  GetUpcomingDrives(): any {
    return this.http.get<any>(this.baseURL + 'Drive/ViewUpcomingDrives', { headers: this.headers });
  }

  GetUpcomingInterviews(): any {
    return this.http.get<any>(this.baseURL + 'Drive/ViewUpcomingInterview', { headers: this.headers });
  }

  GetUtilizedInterviews(date: any): any {
    return this.http.post<any>(this.baseURL + 'Drive/ViewUtilizedInterviews', date, { headers: this.headers });
  }

  AddResponse(response: any) {
    return this.http.post<any>(this.baseURL + `Drive/AddResponse`, response, { headers: this.headers });
  }

  AddTimeSlot(timeSlot: any) {
    return this.http.post<any>(this.baseURL + `Drive/SetTimeSlot`, timeSlot, { headers: this.headers });
  }

  //POST methods

  Login(user: any) {
    return this.http.post<any>(this.baseURL + `Token/Login`, user, { headers: this.headers })
  }

  CreateNewProject(user: any) {
    this.http.post<any>(this.baseURL + 'Project/CreateNewProject', user, { headers: this.headers })
  }

  CreateEmployee(user: any) {
    return this.http.post<any>(this.baseURL + 'Employee/CreateNewEmployee', user, { headers: this.headers })
  }

  CancelDrive(driveId: number, reason: string) {
    return this.http.patch<any>(this.baseURL + `Drive/CancelDrive?driveId=${driveId}&reason=${reason}`, driveId, { headers: this.headers });
  }

  CancelInterview(employeeAvailabilityId: number, cancellationReason: string, comments: string) {
    return this.http.patch<any>(this.baseURL + `Drive/CancelInterview?employeeAvailabilityId=${employeeAvailabilityId}&cancellationReason=${cancellationReason}&comments=${comments}`, null, { headers: this.headers });
  }

  CreateDrive(drive: any) {
    return this.http.post<any>(this.baseURL + `Drive/CreateDrive`, drive, { headers: this.headers });
  }

  AddPool(poolName: string, departmentId: number) {
    return this.http.post<any>(this.baseURL + `Pool/CreateNewPool?departmentId=${departmentId}&poolName=${poolName}`, null, { headers: this.headers })
  }

  AddPoolMember(employeeId: number, poolId: number) {
    return this.http.post<any>(this.baseURL + `Pool/AddPoolMember?employeeId=${employeeId}&poolId=${poolId}`, null, { headers: this.headers })
  }

  EditPool(poolId: number, poolName: string) {
    return this.http.patch<any>(this.baseURL + `Pool/EditPool?poolId=${poolId}&poolName=${poolName}`, null, { headers: this.headers })
  }

  RemovePoolMember(poolMemberId: number) {
    return this.http.post<any>(this.baseURL + `Pool/RemovePoolMember?poolMemberId=${poolMemberId}`, null, { headers: this.headers })
  }

  RemovePool(poolId: number) {
    return this.http.post<any>(this.baseURL + `Pool/RemovePool?poolId=${poolId}`, null, { headers: this.headers })
  }

  ScheduleInterview(driveId: number) {
    return this.http.patch<any>(this.baseURL + `Drive/ScheduleInterview?employeeAvailabilityId=${driveId}`, null, { headers: this.headers })
  }

  //Admin

  AddLocation(location: any) {
    return this.http.post<any>(this.baseURL + `Location/CreateNewLocation`, location, { headers: this.headers });
  }
  AddProject(projectName: string, departmentId: number) {
    return this.http.post<any>(this.baseURL + `Project/CreateNewProject?departmentId=${departmentId}&projectName=${projectName}`, null, { headers: this.headers })
  }
  AddRole(role: any) {
    return this.http.post<any>(this.baseURL + `Role/CreateNewRole`, role, { headers: this.headers })
  }
  AddDepartment(department: any) {
    return this.http.post<any>(this.baseURL + `Department/CreateNewDepartment`, department, { headers: this.headers })
  }

  //Patch Methods
  //Admin

  RespondEmployeeRequest(employeeId: number, response: boolean) {
    return this.http.patch<any>(this.baseURL + `Employee/RespondEmployeeRequest?employeeId=${employeeId}&response=${response}`, null, { headers: this.headers })
  }

  RemoveLocation(location: any) {
    return this.http.patch<any>(this.baseURL + `Location/RemoveLocation`, location, { headers: this.headers })
  }

  RemoveProject(projectId: number) {
    return this.http.patch<any>(this.baseURL + `Project/RemoveProject?projectId=${projectId}`, null, { headers: this.headers })
  }
  RemoveRole(role: any) {
    return this.http.patch<any>(this.baseURL + `Role/RemoveRole`, role, { headers: this.headers })
  }
  RemoveDepartment(department: any) {
    return this.http.patch<any>(this.baseURL + `Department/RemoveDepartment`, department, { headers: this.headers })
  }

}

