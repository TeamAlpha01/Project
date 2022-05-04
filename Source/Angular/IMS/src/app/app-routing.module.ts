import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminAdddepartmentComponent } from './Admin/admin-adddepartment/admin-adddepartment.component';
import { AdminAddlocationComponent } from './Admin/admin-addlocation/admin-addlocation.component';
import { AdminAddprojectComponent } from './Admin/admin-addproject/admin-addproject.component';
import { AdminRequestsComponent } from './Admin/admin-requests/admin-requests.component';
import { AdminRoleComponent } from './Admin/admin-role/admin-role.component';
// import { AdminRoleComponent } from './Admin/admin-addrole/admin-role.component';
import { InterviewerCurrentDriveComponent } from './Interviewer/interviewer-current-drive/interviewer-current-drive.component';
import { InterviewerDashboardComponent } from './Interviewer/interviewer-dashboard/interviewer-dashboard.component';
import { InterviewerDriveInvitesComponent } from './Interviewer/interviewer-drive-invites/interviewer-drive-invites.component';
import { InterviewerHomeComponent } from './Interviewer/interviewer-home/interviewer-home.component';
import { ProfileComponent } from './Shared/profile/profile.component';
import { TacHomeComponent } from './TAC/tac-home/tac-home.component';

const routes: Routes = [
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

  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
