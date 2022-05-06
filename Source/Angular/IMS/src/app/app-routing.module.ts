import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminAdddepartmentComponent } from './Admin/admin-adddepartment/admin-adddepartment.component';
import { AdminAddlocationComponent } from './Admin/admin-addlocation/admin-addlocation.component';
import { AdminAddprojectComponent } from './Admin/admin-addproject/admin-addproject.component';
import { AdminDashboardComponent } from './Admin/admin-dashboard/admin-dashboard.component';
import { AdminRequestsComponent } from './Admin/admin-requests/admin-requests.component';
import { AdminRoleComponent } from './Admin/admin-role/admin-role.component';

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





const routes: Routes = [
  { path: 'admin-addrole-page', component: AdminViewRolePageComponent},
  // { path: '', component: InterviewerScheduledDriveComponent},
  { path: '', component: AdminViewRolePageComponent},
  { path: 'interviewer-home', component:InterviewerHomeComponent },
  { path: 'profile', component:ProfileComponent },
  { path: 'interviewer-dashboard', component:InterviewerDashboardComponent },
  { path: 'interviewer-currentDrives', component:InterviewerCurrentDriveComponent },
  { path: 'interviewer-driveInvites', component:InterviewerDriveInvitesComponent },

  {path: 'Admin-adddepartment ',component:AdminAdddepartmentComponent},
  {path: 'Admin-addlocation ',component:AdminAddlocationComponent},
  {path: 'Admin-addproject',component:AdminAddprojectComponent},
  {path: 'Admin-role',component:AdminRoleComponent},
  {path: 'Admin-requests',component:AdminRequestsComponent},
  {path: 'Admin-dashboard',component:AdminDashboardComponent},


  // {path:'',component:EditpoolComponent},

  {path: 'TAC-dashboard',component:TacDashboardComponent},
  {path: 'TAC-performance',component:MyperformanceComponent},
  {path: 'Poolmembers-performance',component:PoolmembersPerformanceComponent},
  {path: 'managepoolmembers',component:ManagepoolmembersComponent},
  {path: 'tac-profile', component:TacProfileComponent },
  {path: 'tac-current-drive', component:TacCurrentDriveComponent },
  {path: 'tac-scheduled-drive', component:TacScheduledDriveComponent },
  // {path:'',component:AdminDashboardComponent},

  {path:'createpool',component:CreatepoolComponent},
  {path:'editpool',component:EditpoolComponent},
  {path:'managepoolmembers',component:ManagepoolmembersComponent},

  { path: 'interviewer-scheduledDrives', component:InterviewerScheduledDriveComponent },
  { path: 'interviewer-upcomingDrives', component:InterviewerUpcomingDriveComponent },
  { path: 'tac-home',component:TacHomeComponent},

  // {path:'', component: ManagepoolmembersComponent},

  // {path:'', component:InterviewerHomeComponent}
  {path:'', component: ManagepoolComponent}
  // {path:'', component: ManagepoolmembersComponent},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
