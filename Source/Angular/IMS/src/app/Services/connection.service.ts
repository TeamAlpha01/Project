
import { HttpClientModule, HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuthenticationService } from 'src/app/Services/authentication.service';
import { catchError, throwError } from 'rxjs';
// import { threadId } from 'worker_threads';


@Injectable({
  providedIn: 'root'
})
export class ConnectionService {

  baseURL = 'https://localhost:7072/'
  constructor(private http: HttpClient) { }

  public headers = new HttpHeaders({
    'Content-Type': 'application/json',
    'Authorization': `Bearer ${AuthenticationService.GetData('token')}`
  })

  initializeTokenHeader(token:string|null){
    this.headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    })
  }

  logout(){
    this.headers=new HttpHeaders();
  }

  //GET methods

  GetAcceptedDrives():any{
    return this.http.get<any>(this.baseURL + 'Drive/ViewAcceptedDrives', { headers: this.headers });
  }

  GetCancelledDrives(): any {
    return this.http.get<any>(this.baseURL + 'Drive/ViewAllCancelledDrives', { headers: this.headers });
  }

  GetDashboard(): any {
    return this.http.get<any>(this.baseURL + `Drive/ViewEmployeeDashboard`, { headers: this.headers });
  }

  GetDefaulters(poolId:number): any {
    return this.http.get<any>(this.baseURL + `Drive/ViewDefaulters?poolId=${poolId}`, { headers: this.headers });
  }

  GetDepartments(): any {
    return this.http.get<any>(this.baseURL + 'Department/ViewDepartments', { headers: this.headers });
  }

  GetDrive(driveId: number): any {
    return this.http.get<any>(this.baseURL + `Drive/ViewDrive?driveId=${driveId}`, { headers: this.headers });
  }

  GetDriveResponse(driveId:number){
    return this.http.get<any>(this.baseURL + `Drive/ViewAvailableMembersForDrive?driveId=${driveId}`, { headers: this.headers });
  }

  GetEmployees() {
    return this.http.get<any>(this.baseURL + 'Employee/ViewEmployees', { headers: this.headers });
  }

  GetEmployeesDashboard(employeeId: number) {
    return this.http.get<any>(this.baseURL + `Drive/ViewEmployeeDashboard?employeeId=${employeeId}`, { headers: this.headers });
  }

  GetEmployeeProfile() {
    return this.http.get<any>(this.baseURL + `Employee/ViewEmployeeProfile`, { headers: this.headers });
  }

  GetEmployeeRequests(): any{
    return this.http.get<any>(this.baseURL + 'Employee/ViewEmployeeRequest', { headers: this.headers });
  }

  GetDeniedDrives(): any{
    return this.http.get<any>(this.baseURL + 'Drive/ViewDeniedDrives', { headers: this.headers });
  }

  GetIgnoredDrives(): any{
    return this.http.get<any>(this.baseURL + 'Drive/ViewIgnoredDrives', { headers: this.headers });
  }

  GetLocations(): any {
    return this.http.get<any>(this.baseURL + 'Location/ViewLocations', { headers: this.headers });
  }

  GetNonCancelledDrives(): any {
    return this.http.get<any>(this.baseURL + 'Drive/ViewNonCancelledDrives', { headers: this.headers });
  }

  GetNotUtilizedInterviews(): any {
    return this.http.get<any>(this.baseURL + 'Drive/ViewNotUtilizedInterviews', { headers: this.headers });
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

  GetScheduledDrives(): any {
    return this.http.get<any>(this.baseURL + 'Drive/ViewScheduledDrives', { headers: this.headers });
  }

  GetTACDashboard(): any {
    return this.http.get<any>(this.baseURL + `Drive/ViewDashboard`, { headers: this.headers });
  }

  GetTodayDrives(): any {
    return this.http.get<any>(this.baseURL + 'Drive/ViewTodayDrives', { headers: this.headers });
  }

  GetTotalDrives(): any {
    return this.http.get<any>(this.baseURL + 'Drive/ViewTotalDrives', { headers: this.headers });
  }
  
  GetTodaysInterviews(): any {
    return this.http.get<any>(this.baseURL + 'Drive/ViewTodaysInterview', { headers: this.headers });
  }

  GetScheduledInterviews(): any {
    return this.http.get<any>(this.baseURL + 'Drive/ViewScheduledInterview', { headers: this.headers });
  }
  
  GetUpcomingDrives(): any {
    return this.http.get<any>(this.baseURL + 'Drive/ViewUpcommingDrives', { headers: this.headers });
  }

  GetUpcomingInterviews(): any {
    return this.http.get<any>(this.baseURL + 'Drive/ViewUpcomingInterview', { headers: this.headers });
  }

  GetUtilizedInterviews(): any {
    return this.http.get<any>(this.baseURL + 'Drive/ViewUtilizedInterviews', { headers: this.headers });
  }

  GetDriveById(driveId:any)
  {
    return this.http.get<any>(this.baseURL+ `Drive/ViewDrive?driveId=${driveId}`,{headers:this.headers});
  }

  GetDriveInvites(employeeId:any){
    return this.http.get<any>(this.baseURL + `Drive/ViewInvites?employeeId=${employeeId}`, { headers: this.headers});
  }

  GetDriveInvitesById(){
    return this.http.get<any>(this.baseURL + `Drive/ViewInvitesByID`, { headers: this.headers });
  }

  AddResponse(driveId:any)
  {
    return this.http.post<any>(this.baseURL + `Drive/AddResponse`, driveId ,{ headers: this.headers });
  }

  AddTimeSlot(timeSlot:any)
  {
    return this.http.post<any>(this.baseURL + `Drive/SetTimeSlot`, timeSlot ,{ headers: this.headers });
  }

  //POST methods
  Login(user: any) {
    return this.http.post<any>(this.baseURL + `Token/AuthToken/Login?employeeAceNumber=${user.ACENumber}&password=${user.Password}`, user, { headers: this.headers })
  }

  CreateNewProject(user: any) {
    this.http.post<any>(this.baseURL + '/Project/CreateNewProject', user, { headers: this.headers })
  }

  CreateEmployee(user: any) {
    return this.http.post<any>( this.baseURL + 'Employee/CreateNewEmployee', user, { headers: this.headers })
  }

  CancelDrive(driveId: number, reason: string) {
    return this.http.patch<any>(this.baseURL + `Drive/CancelDrive?driveId=${driveId}&tacId=11&reason=${reason}`, driveId, { headers: this.headers });
  }
  CancelInterview(employeeAvailabilityId: number, cancellationReason: string,comments:string) {
    console.log('service called')
    return this.http.patch<any>(this.baseURL + `Drive/CancelInterview?employeeAvailabilityId=${employeeAvailabilityId}&cancellationReason=${cancellationReason}&comments=${comments}`, null, { headers: this.headers });
  }

  CreateDrive(drive:any){
    return this.http.post<any>(this.baseURL + `Drive/CreateDrive`, drive, { headers: this.headers });
  }

  AddPool(poolName: string, departmentId: number) {
    return this.http.post<any>(this.baseURL + `Pool/CreateNewPool?departmentId=${departmentId}&poolName=${poolName}`, null, { headers: this.headers })
  }

  AddPoolMember(employeeId: number, poolId: number) {
    return this.http.post<any>(this.baseURL + `Pool/AddPoolMember?employeeId=${employeeId}&poolId=${poolId}`, null, { headers: this.headers })
  }

  EditPool(poolId: number, poolName: string) {
    return this.http.put<any>(this.baseURL + `Pool/EditPool?poolId=${poolId}&poolName=${poolName}`, null, { headers: this.headers })
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
  AddLocation(locationName: string) {
    return this.http.post<any>(this.baseURL + `Location/CreateNewLocation?locationName=${locationName}`, null, { headers: this.headers });
  }
  AddProject(projectName: string, departmentId: number) {
    return this.http.post<any>(this.baseURL + `Project/CreateNewProject?departmentId=${departmentId}&projectName=${projectName}`, null, { headers: this.headers })
  }
  AddRole(roleName: string) {
    return this.http.post<any>(this.baseURL + `Role/CreateNewRole?roleName=${roleName}`, null, { headers: this.headers })
  }
  AddDepartment(departmentName: string) {
    return this.http.post<any>(this.baseURL + `Department/CreateNewDepartment?departmentName=${departmentName}`, null, { headers: this.headers })
  }


  //Patch Methods
  //Admin
  RespondEmployeeRequest(employeeId: number, response: boolean) {
    return this.http.patch<any>(this.baseURL + `Employee/RespondEmployeeRequest?employeeId=${employeeId}&response=${response}`, null, { headers: this.headers })
  }

  RemoveLocation(locationId: number) {
    return this.http.patch<any>(this.baseURL + `Location/RemoveLocation?locationId=${locationId}`, null, { headers: this.headers })
  }

  RemoveProject(projectId: number) {
    return this.http.patch<any>(this.baseURL + `Project/RemoveProject?projectId=${projectId}`, null, { headers: this.headers })
  }
  RemoveRole(projectId: number) {
    return this.http.patch<any>(this.baseURL + `Role/RemoveRole?roleId=${projectId}`, null, { headers: this.headers })
  }
  RemoveDepartment(departmentId: number) {
    return this.http.patch<any>(this.baseURL + `Department/RemoveDepartment?departmentId=${departmentId}`, null, { headers: this.headers })
  }

}

