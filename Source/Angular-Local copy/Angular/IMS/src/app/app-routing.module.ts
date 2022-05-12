import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminAdddepartmentComponent } from './Admin/admin-adddepartment/admin-adddepartment.component';
import { AdminAddlocationComponent } from './Admin/admin-addlocation/admin-addlocation.component';
import { AdminAddprojectComponent } from './Admin/admin-addproject/admin-addproject.component';
import { AdminDashboardComponent } from './Admin/admin-dashboard/admin-dashboard.component';
import { AdminRequestsComponent } from './Admin/admin-requests/admin-requests.component';
import { AdminRoleComponent } from './Admin/admin-role/admin-role.component';
import { AdminviewLocationPageComponent } from './Admin/admin-view-location-page/admin-viewLocation-page.component';
import { AdminviewProjectPageComponent } from './Admin/admin-view-project-page/admin-view-Project-page.component';

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
import { AdminManageLocationComponent } from './Admin/admin-manage-location/admin-manage-location.component';
import { AdminManageDepartmentComponent } from './Admin/admin-manage-department/admin-manage-department.component';
import { AdminviewDepartmentPageComponent } from './Admin/admin-view-department-page/admin-view-department-page.component';





const routes: Routes = [
  //interviewer pages
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
  { path: 'Admin-addrole-page', component: AdminRoleComponent },                                 //Admin-addrole-page
  { path: 'Admin-adddepartment', component: AdminAdddepartmentComponent },                       //Admin-adddepartment
  { path: 'Admin-addlocation', component: AdminAddlocationComponent },                           //Admin-addlocation
  { path: 'Admin-addproject', component: AdminAddprojectComponent },
  { path: 'Admin-role', component: AdminRoleComponent },
  { path: 'Admin-add-role', component: AdminRoleComponent },
  { path: 'Admin-requests', component: AdminRequestsComponent },
  { path: 'Admin-dashboard', component: AdminDashboardComponent },
  { path: 'Admin-viewdepartment-page',component:AdminviewDepartmentPageComponent},                                         //Admin-viewdepartment-page
  { path: 'Admin-viewlocation-page',component:AdminviewLocationPageComponent},                    //Admin-viewlocation-page
  { path: 'Admin-veiwproject-page', component: AdminviewProjectPageComponent },                   //Admin-veiwproject-page
  { path: 'Admin-manage-location', component: AdminManageLocationComponent },                     //Admin-manage-location
  { path: '', component: AdminManageDepartmentComponent },                 //Admin-manage-department


  //tac pages
  { path: 'TAC-dashboard', component: TacDashboardComponent },
  { path: 'TAC-performance', component: MyperformanceComponent },
  { path: 'Poolmembers-performance', component: PoolmembersPerformanceComponent },
  { path: 'managepoolmembers', component: ManagepoolmembersComponent },
  { path: 'tac-profile', component: TacProfileComponent },
  { path: 'tac-current-drive', component: TacCurrentDriveComponent },                            //tac-current-drive
  { path: 'tac-scheduled-drive', component: TacScheduledDriveComponent },
  { path: 'create-invite', component: CreateInviteComponent },
  { path: 'createpool', component: CreatepoolComponent },
  { path: 'editpool', component: EditpoolComponent },
  { path: 'managepoolmembers', component: ManagepoolmembersComponent },
  { path: 'managepool', component: ManagepoolComponent },
  { path: 'login', component: LoginComponent },
  { path: 'dashboaard', component: DashboardComponent },
  { path: 'tac-home', component: TacHomeComponent },                                             //tac-home
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }