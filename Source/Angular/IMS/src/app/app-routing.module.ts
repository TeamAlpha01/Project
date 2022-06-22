import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router'; 
import { AdminAdddepartmentComponent } from './Admin/admin-adddepartment/admin-adddepartment.component';
import { AdminAddlocationComponent } from './Admin/admin-addlocation/admin-addlocation.component';
import { AdminAddprojectComponent } from './Admin/admin-addproject/admin-addproject.component';
import { AdminDashboardComponent } from './Admin/admin-dashboard/admin-dashboard.component';
import { AdminRoleComponent } from './Admin/admin-role/admin-role.component';


import { InterviewerCurrentDriveComponent } from './Interviewer/interviewer-current-drive/interviewer-current-drive.component';
import { InterviewerDashboardComponent } from './Interviewer/interviewer-dashboard/interviewer-dashboard.component';
import { InterviewerDriveInvitesComponent } from './Interviewer/interviewer-drive-invites/interviewer-drive-invites.component';
import { InterviewerHomeComponent } from './Interviewer/interviewer-home/interviewer-home.component';
import { InterviewerScheduledDriveComponent } from './Interviewer/interviewer-scheduled-drive/interviewer-scheduled-drive.component';
import { InterviewerUpcomingDriveComponent } from './Interviewer/interviewer-upcoming-drive/interviewer-upcoming-drive.component';
import { TacDashboardComponent } from './TAC/tac-dashboard/tac-dashboard.component';
import { TacHomeComponent } from './TAC/tac-home/tac-home.component';
import { PoolmembersPerformanceComponent } from './TAC/poolmembers-performance/poolmembers-performance.component';
import { MyperformanceComponent } from './TAC/myperformance/myperformance.component';
import { AdminViewRolePageComponent } from './Admin/admin-view-role-page/admin-view-role-page.component';
import { TacProfileComponent } from './TAC/tac-profile/tac-profile.component';
import { LoginComponent } from './Shared/login/login.component';
import { ManagepoolComponent } from './TAC/managepool/managepool.component';
import { TacCurrentDriveComponent } from './TAC/tac-current-drive/tac-current-drive.component';
import { TacScheduledDriveComponent } from './TAC/tac-scheduled-drive/tac-scheduled-drive.component';
import { CreateInviteComponent } from './TAC/create-invite/create-invite.component';
import { InterviewerAcceptInvitePageComponent } from './Interviewer/interviewer-accept-invite-page/interviewer-accept-invite-page.component';
import { InterviewerCancelInterviewPageComponent } from './Interviewer/interviewer-cancel-interview-page/interviewer-cancel-interview-page.component';
import { AdminviewLocationPageComponent } from './Admin/admin-view-Location-page/admin-viewLocation-page.component';
import { AdminviewDepartmentPageComponent } from './Admin/admin-view-department-page/admin-view-department-page.component';
import { AdminviewProjectPageComponent } from './Admin/admin-view-project-page/admin-view-Project-page.component';
import { AdminViewRequestsPageComponent } from './Admin/admin-view-requests-page/admin-view-requests-page.component';
import { TacUpcomingDriveComponent } from './TAC/tac-upcoming-drive/tac-upcoming-drive.component';
import { TacCreatePoolComponent } from './TAC/tac-create-pool/tac-create-pool.component';
import { TacEditPoolComponent } from './TAC/tac-edit-pool/tac-edit-pool.component';
import { TacEditPoolMemberComponent } from './TAC/tac-edit-pool-member/tac-edit-pool-member.component';
import { TacCancelDriveComponent } from './TAC/tac-cancel-drive/tac-cancel-drive.component';
import { InterviwerProfileComponent } from './Interviewer/interviwer-profile/interviwer-profile.component';
import { ErrorPageComponent } from './Shared/error-page/error-page.component';
import { TacScheduledDriveHistoryComponent } from './TAC/tac-scheduled-drive-history/tac-scheduled-drive-history.component';
import { TacCancelledDriveHistoryComponent } from './TAC/tac-cancelled-drive-history/tac-cancelled-drive-history.component';
// import { AdminviewLocationPageComponent } from './Admin/admin-view-location-page/admin-viewLocation-page.component';





const routes: Routes = [
  //interviewer pages
  { path: 'interviewer-current-drive', component: InterviewerCurrentDriveComponent },     
  { path: 'interviewer-home', component: InterviewerHomeComponent },
  { path: 'profile', component: InterviwerProfileComponent },
  { path: 'interviewer-dashboard', component: InterviewerDashboardComponent },
  { path: 'interviewer-currentDrives', component: InterviewerCurrentDriveComponent },
  { path: 'interviewer-scheduledDrives', component: InterviewerScheduledDriveComponent },
  { path: 'interviewer-upcomingDrives', component: InterviewerUpcomingDriveComponent },
  { path: 'interviewer-driveInvites', component: InterviewerDriveInvitesComponent },
  { path: 'interviewer-accept-invite-page', component: InterviewerAcceptInvitePageComponent },
  { path: 'interviewer-cancelInterview', component: InterviewerCancelInterviewPageComponent },


  //admin pages
  { path: '', component: LoginComponent},                               
  { path: 'admin/requests', component: AdminViewRequestsPageComponent },
  { path: 'admin/role', component: AdminViewRolePageComponent },
  { path: 'admin/role/add', component: AdminRoleComponent},        
  { path: 'admin/location', component: AdminviewLocationPageComponent },
  { path: 'admin/location/add', component: AdminAddlocationComponent },
  { path: 'admin/department', component: AdminviewDepartmentPageComponent },
  { path: 'admin/department/add', component: AdminAdddepartmentComponent },
  { path: 'admin/project', component: AdminviewProjectPageComponent },
  { path: 'admin/project/add', component: AdminAddprojectComponent },
  


               

  //tac pages
  { path: 'tac/dashboard', component: TacDashboardComponent },
  { path: 'tac/dashboard/performance', component: MyperformanceComponent },
  { path: 'tac/dashboard/performance/scheduled-drive-history', component: TacScheduledDriveHistoryComponent },
  { path: 'tac/dashboard/performance/cancelled-drive-history', component: TacCancelledDriveHistoryComponent },
  { path: 'tac/dashboard/Poolmembers-performance', component: PoolmembersPerformanceComponent },
  { path: 'tac/managepoolmembers', component: TacEditPoolMemberComponent },
  { path: 'tac/myProfile', component: TacProfileComponent },
  { path: 'tac/current-drive', component: TacCurrentDriveComponent },
  { path: 'tac/cancel-drive/:driveId', component: TacCancelDriveComponent },
  { path: 'tac/scheduled-drive', component: TacScheduledDriveComponent },
  { path: 'tac/create-invite', component: CreateInviteComponent },
  { path: 'tac/upcomingDrives', component: TacUpcomingDriveComponent },
  { path: 'tac/createPool', component: TacCreatePoolComponent },
  { path: 'tac/editpool', component: TacEditPoolComponent },
  { path: 'tac/managepool', component: ManagepoolComponent },
  { path: 'tac/home', component: TacHomeComponent },
  { path: 'errorPage', component: ErrorPageComponent },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
