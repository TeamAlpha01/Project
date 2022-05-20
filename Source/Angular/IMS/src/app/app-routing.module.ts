import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminAdddepartmentComponent } from './Admin/admin-adddepartment/admin-adddepartment.component';
import { AdminAddlocationComponent } from './Admin/admin-addlocation/admin-addlocation.component';
import { AdminAddprojectComponent } from './Admin/admin-addproject/admin-addproject.component';
import { AdminDashboardComponent } from './Admin/admin-dashboard/admin-dashboard.component';
import { AdminRequestsComponent } from './Admin/admin-requests/admin-requests.component';
import { AdminRoleComponent } from './Admin/admin-role/admin-role.component';
// import { AdminviewDepartmentPageComponent } from './Admin/admin-view-department-page/admin-view-Department-page.component';
//import { AdminviewLocationPageComponent } from './Admin/admin-view-location-page/admin-viewLocation-page.component';
// import { AdminviewProjectPageComponent } from './Admin/admin-view-project-page/admin-view-Project-page.component';

import { InterviewerCurrentDriveComponent } from './Interviewer/interviewer-current-drive/interviewer-current-drive.component';
import { InterviewerDashboardComponent } from './Interviewer/interviewer-dashboard/interviewer-dashboard.component';
import { InterviewerDriveInvitesComponent } from './Interviewer/interviewer-drive-invites/interviewer-drive-invites.component';
import { InterviewerHomeComponent } from './Interviewer/interviewer-home/interviewer-home.component';
import { InterviewerScheduledDriveComponent } from './Interviewer/interviewer-scheduled-drive/interviewer-scheduled-drive.component';
import { InterviewerUpcomingDriveComponent } from './Interviewer/interviewer-upcoming-drive/interviewer-upcoming-drive.component';
import { ProfileComponent } from './Shared/profile/profile.component';
import { TacDashboardComponent } from './TAC/tac-dashboard/tac-dashboard.component';
import { TacHomeComponent } from './TAC/tac-home/tac-home.component';
import { DashboardComponent } from './Shared/dashboard/dashboard.component';

import { EditpoolComponent } from './TAC/editpool/editpool.component';

import { PoolmembersPerformanceComponent } from './TAC/poolmembers-performance/poolmembers-performance.component';
import { MyperformanceComponent } from './TAC/myperformance/myperformance.component';
import { ManagepoolmembersComponent } from './TAC/managepoolmembers/managepoolmembers.component';
import { AdminViewRolePageComponent } from './Admin/admin-view-role-page/admin-view-role-page.component';
import { TacProfileComponent } from './TAC/tac-profile/tac-profile.component';
import { LoginComponent } from './Shared/login/login.component';
import { ManagepoolComponent } from './TAC/managepool/managepool.component';
import { TacCurrentDriveComponent } from './TAC/tac-current-drive/tac-current-drive.component';
import { CreatepoolComponent } from './TAC/createpool/createpool.component';
import { TacScheduledDriveComponent } from './TAC/tac-scheduled-drive/tac-scheduled-drive.component';
import { CreateInviteComponent } from './TAC/create-invite/create-invite.component';
import { InterviewerAcceptInvitePageComponent } from './Interviewer/interviewer-accept-invite-page/interviewer-accept-invite-page.component';
import { InterviewerCancelInterviewPageComponent } from './Interviewer/interviewer-cancel-interview-page/interviewer-cancel-interview-page.component';
import { PerformanceDashboardComponent } from './Shared/performance-dashboard/performance-dashboard.component';
import { AdminviewLocationPageComponent } from './Admin/admin-view-Location-page/admin-viewLocation-page.component';
import { AdminHeaderComponent } from './Admin/admin-header/admin-header.component';
import { InterviewerHeaderComponent } from './Interviewer/interviewer-header/interviewer-header.component';
import { AdminviewDepartmentPageComponent } from './Admin/admin-view-department-page/admin-view-department-page.component';
import { AdminviewProjectPageComponent } from './Admin/admin-view-project-page/admin-view-Project-page.component';
import { AdminViewRequestsPageComponent } from './Admin/admin-view-requests-page/admin-view-requests-page.component';
import { TacUpcomingDriveComponent } from './TAC/tac-upcoming-drive/tac-upcoming-drive.component';
import { RegisterComponent } from './register/register.component';
import { RegisterPageComponent } from './Shared/register-page/register-page.component';
// import { AdminviewLocationPageComponent } from './Admin/admin-view-location-page/admin-viewLocation-page.component';





const routes: Routes = [
  //interviewer pages
  { path: '', component: InterviewerCurrentDriveComponent },     //Admin-view-location-page
  { path: 'interviewer-home', component: InterviewerHomeComponent },
  { path: 'profile', component: ProfileComponent },
  { path: 'interviewer-dashboard', component: InterviewerDashboardComponent },
  { path: 'interviewer-currentDrives', component: InterviewerCurrentDriveComponent },
  { path: 'interviewer-scheduledDrives', component: InterviewerScheduledDriveComponent },
  { path: 'interviewer-upcomingDrives', component: InterviewerUpcomingDriveComponent },
  { path: 'interviewer-driveInvites', component: InterviewerDriveInvitesComponent },
  { path: 'interviewer-accept-invite-page', component: InterviewerAcceptInvitePageComponent },
  { path: 'interviewer-cancelInterview', component: InterviewerCancelInterviewPageComponent },


  //admin pages
  // { path: '', component: PerformanceDashboardComponent },                        //Admin-addrole-page
  { path: 'Admin-adddepartment ', component: AdminAdddepartmentComponent },          //Admin-adddepartment 
  { path: 'Admin-addlocation ', component: AdminAddlocationComponent },               //Admin-addlocation
  { path: 'Admin-addproject', component: AdminAddprojectComponent },
  { path: 'Admin-role', component: AdminRoleComponent },                             //Admin-role
  { path: 'Admin-requests', component: AdminRequestsComponent },
  { path: 'admin-dashboard', component: AdminDashboardComponent },
  { path: 'admin-view-department', component: AdminviewDepartmentPageComponent },
  { path: 'admin-view-role', component: AdminViewRolePageComponent },
  { path: 'admin-view-project', component: AdminviewProjectPageComponent },
  { path: 'admin-view-location', component: AdminviewLocationPageComponent },
  { path: 'admin-view-requests', component: AdminViewRequestsPageComponent },
  


               

  //tac pages
  { path: 'TAC-dashboard', component: TacDashboardComponent },
  { path: 'TAC-performance', component: MyperformanceComponent },
  { path: 'Poolmembers-performance', component: PoolmembersPerformanceComponent },
  { path: 'managepoolmembers', component: ManagepoolmembersComponent },
  { path: 'tac-profile', component: TacProfileComponent },
  { path: 'tac-current-drive', component: TacCurrentDriveComponent },
  { path: 'tac-scheduled-drive', component: TacScheduledDriveComponent },
  { path: 'create-invite', component: CreateInviteComponent },
  { path: 'tac-upcomingDrives', component: TacUpcomingDriveComponent },

  { path: 'createpool', component: CreatepoolComponent },
  { path: 'editpool', component: EditpoolComponent },
  { path: 'managepoolmembers', component: ManagepoolmembersComponent },
  { path: 'managepool', component: ManagepoolComponent },
  { path: 'login', component: LoginComponent },
  { path: 'dashboaard', component: DashboardComponent },
  { path: 'tac-home', component: TacHomeComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
