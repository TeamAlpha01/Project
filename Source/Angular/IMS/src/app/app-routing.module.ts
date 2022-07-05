import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './Shared/login/login.component';
import { TacHomeComponent } from './TAC/tac-home/tac-home.component';
import { AuthorizationService } from './Services/authorization.service';
import { ManagepoolComponent } from './TAC/managepool/managepool.component';
import { AdminRoleComponent } from './Admin/admin-role/admin-role.component';
import { TacProfileComponent } from './TAC/tac-profile/tac-profile.component';
import { ErrorPageComponent } from './Shared/error-page/error-page.component';
import { TacEditPoolComponent } from './TAC/tac-edit-pool/tac-edit-pool.component';
import { CreateInviteComponent } from './TAC/create-invite/create-invite.component';
import { TacDashboardComponent } from './TAC/tac-dashboard/tac-dashboard.component';
import { MyperformanceComponent } from './TAC/myperformance/myperformance.component';
import { RegisterPageComponent } from './Shared/register-page/register-page.component';
import { TacCreatePoolComponent } from './TAC/tac-create-pool/tac-create-pool.component';
import { AdminDashboardComponent } from './Admin/admin-dashboard/admin-dashboard.component';
import { TacCancelDriveComponent } from './TAC/tac-cancel-drive/tac-cancel-drive.component';
import { AdminAddprojectComponent } from './Admin/admin-addproject/admin-addproject.component';
import { TacCurrentDriveComponent } from './TAC/tac-current-drive/tac-current-drive.component';
import { TacUpcomingDriveComponent } from './TAC/tac-upcoming-drive/tac-upcoming-drive.component';
import { AdminAddlocationComponent } from './Admin/admin-addlocation/admin-addlocation.component';
import { InterviewerHomeComponent } from './Interviewer/interviewer-home/interviewer-home.component';
import { TacScheduledDriveComponent } from './TAC/tac-scheduled-drive/tac-scheduled-drive.component';
import { TacEditPoolMemberComponent } from './TAC/tac-edit-pool-member/tac-edit-pool-member.component';
import { AdminAdddepartmentComponent } from './Admin/admin-adddepartment/admin-adddepartment.component';
import { AdminViewRolePageComponent } from './Admin/admin-view-role-page/admin-view-role-page.component';
import { InterviewerProfileComponent } from './Interviewer/interviewer-profile/interviewer-profile.component';
import { TacEmployeeDashboardComponent } from './TAC/tac-employee-dashboard/tac-employee-dashboard.component';
import { PoolmembersPerformanceComponent } from './TAC/poolmembers-performance/poolmembers-performance.component';
import { AdminviewProjectPageComponent } from './Admin/admin-view-project-page/admin-view-Project-page.component';
import { AdminviewLocationPageComponent } from './Admin/admin-view-Location-page/admin-viewLocation-page.component';
import { InterviewerDashboardComponent } from './Interviewer/interviewer-dashboard/interviewer-dashboard.component';
import { AdminViewRequestsPageComponent } from './Admin/admin-view-requests-page/admin-view-requests-page.component';
import { AdminviewDepartmentPageComponent } from './Admin/admin-view-department-page/admin-view-department-page.component';
import { TacCancelledDriveHistoryComponent } from './TAC/tac-cancelled-drive-history/tac-cancelled-drive-history.component';
import { TacScheduledDriveHistoryComponent } from './TAC/tac-scheduled-drive-history/tac-scheduled-drive-history.component';
import { InterviewerDriveInvitesComponent } from './Interviewer/interviewer-drive-invites/interviewer-drive-invites.component';
import { InterviewerCurrentDriveComponent } from './Interviewer/interviewer-current-drive/interviewer-current-drive.component';
import { InterviewerUpcomingDriveComponent } from './Interviewer/interviewer-upcoming-drive/interviewer-upcoming-drive.component';
import { InterviewerScheduledDriveComponent } from './Interviewer/interviewer-scheduled-drive/interviewer-scheduled-drive.component';
import { InterviewerAcceptInvitePageComponent } from './Interviewer/interviewer-accept-invite-page/interviewer-accept-invite-page.component';
import { InterviewerCancelInvitePageComponent } from './Interviewer/interviewer-cancel-invite-page/interviewer-cancel-invite-page.component';
import { TacViewResponseComponent } from './TAC/tac-view-response/tac-view-response.component';

const routes: Routes = [
  //interviewer pages
  { path: 'interviewer/home', component: InterviewerHomeComponent,canActivate:[AuthorizationService], data:{User:"Interviewer"}},
  { path: 'interviewer/profile', component: InterviewerProfileComponent,canActivate:[AuthorizationService], data:{User:"Interviewer"} },
  { path: 'interviewer/dashboard', component: InterviewerDashboardComponent,canActivate:[AuthorizationService], data:{User:"Interviewer"} },
  { path: 'interviewer/currentDrives', component: InterviewerCurrentDriveComponent,canActivate:[AuthorizationService], data:{User:"Interviewer"} },
  { path: 'interviewer/scheduledDrives', component: InterviewerScheduledDriveComponent,canActivate:[AuthorizationService], data:{User:"Interviewer"} },
  { path: 'interviewer/upcomingDrives', component: InterviewerUpcomingDriveComponent,canActivate:[AuthorizationService], data:{User:"Interviewer"} },
  { path: 'interviewer/driveInvites', component: InterviewerDriveInvitesComponent,canActivate:[AuthorizationService], data:{User:"Interviewer"} },
  { path: 'interviewer/driveInvites/accept-invite/:driveId', component: InterviewerAcceptInvitePageComponent,canActivate:[AuthorizationService], data:{User:"Interviewer"} },
  //{ path: 'interviewer/driveInvites/reject-invite/:driveId', component: InterviewerCancelInvitePageComponent,canActivate:[AuthorizationService], data:{User:"Interviewer"} },
  { path: 'interviewer/cancel-interview/:employeeAvailabilityId', component: InterviewerCancelInvitePageComponent,canActivate:[AuthorizationService], data:{User:"Interviewer"} },


  //admin pages
  { path: '', component: LoginComponent},
  // { path: '**', component: ErrorPageComponent},
  { path: 'register', component: RegisterPageComponent},
  { path: 'admin/requests', component: AdminViewRequestsPageComponent,canActivate:[AuthorizationService], data:{User:"Admin"} },
  { path: 'admin/role', component: AdminViewRolePageComponent,canActivate:[AuthorizationService], data:{User:"Admin"} },
  { path: 'admin/role/add', component: AdminRoleComponent,canActivate:[AuthorizationService], data:{User:"Admin"}},
  { path: 'admin/location', component: AdminviewLocationPageComponent,canActivate:[AuthorizationService], data:{User:"Admin"} },
  { path: 'admin/location/add', component: AdminAddlocationComponent,canActivate:[AuthorizationService], data:{User:"Admin"} },
  { path: 'admin/department', component: AdminviewDepartmentPageComponent,canActivate:[AuthorizationService], data:{User:"Admin"} },
  { path: 'admin/department/add', component: AdminAdddepartmentComponent,canActivate:[AuthorizationService], data:{User:"Admin"} },
  { path: 'admin/project', component: AdminviewProjectPageComponent,canActivate:[AuthorizationService], data:{User:"Admin"} },
  { path: 'admin/project/add', component: AdminAddprojectComponent,canActivate:[AuthorizationService], data:{User:"Admin"} },



  //tac pages
  //{ path: 'tac/dashboard', component: TacDashboardComponent,canActivate:[AuthorizationService], data:{User:"TAC"}},
  { path: 'tac/dashboard', component: MyperformanceComponent,canActivate:[AuthorizationService], data:{User:"TAC"} },
  { path: 'tac/dashboard/scheduled-drive-history', component: TacScheduledDriveHistoryComponent,canActivate:[AuthorizationService], data:{User:"TAC"} },
  { path: 'tac/dashboard/cancelled-drive-history', component: TacCancelledDriveHistoryComponent,canActivate:[AuthorizationService], data:{User:"TAC"} },
  { path: 'tac/dashboard/poolmembers-performance', component: PoolmembersPerformanceComponent,canActivate:[AuthorizationService], data:{User:"TAC"} },
  { path: 'tac/dashboard/employee-dashboard', component: TacEmployeeDashboardComponent,canActivate:[AuthorizationService], data:{User:"TAC"} },
  { path: 'tac/managepool/managepoolmembers/:poolId', component: TacEditPoolMemberComponent,canActivate:[AuthorizationService], data:{User:"TAC"} },
  { path: 'tac/myProfile', component: TacProfileComponent,canActivate:[AuthorizationService], data:{User:"TAC"} },
  { path: 'tac/current-drive', component: TacCurrentDriveComponent,canActivate:[AuthorizationService], data:{User:"TAC"} },
  { path: 'tac/cancel-drive/:driveId', component: TacCancelDriveComponent,canActivate:[AuthorizationService], data:{User:"TAC"} },
  { path: 'tac/scheduled-drive', component: TacScheduledDriveComponent,canActivate:[AuthorizationService], data:{User:"TAC"} },
  { path: 'tac/create-invite', component: CreateInviteComponent,canActivate:[AuthorizationService], data:{User:"TAC"} },
  { path: 'tac/upcomingDrives', component: TacUpcomingDriveComponent,canActivate:[AuthorizationService], data:{User:"TAC"} },
  { path: 'tac/upcomingDrives/viewResponse', component: TacViewResponseComponent,canActivate:[AuthorizationService], data:{User:"TAC"} },
  { path: 'tac/createPool', component: TacCreatePoolComponent,canActivate:[AuthorizationService], data:{User:"TAC"} },
  { path: 'tac/managepool/editpool/:poolId', component: TacEditPoolComponent,canActivate:[AuthorizationService], data:{User:"TAC"} },
  { path: 'tac/managepool', component: ManagepoolComponent,canActivate:[AuthorizationService], data:{User:"TAC"} },
  { path: 'tac/home', component: TacHomeComponent,canActivate:[AuthorizationService], data:{User:"TAC"}},
  { path: 'errorPage', component: ErrorPageComponent },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {


}



