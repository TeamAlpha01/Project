import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminRoleComponent } from './Admin/admin-role/admin-role.component';
import { InterviewerCurrentDriveComponent } from './Interviewer/interviewer-current-drive/interviewer-current-drive.component';
import { InterviewerDashboardComponent } from './Interviewer/interviewer-dashboard/interviewer-dashboard.component';
import { InterviewerDriveInvitesComponent } from './Interviewer/interviewer-drive-invites/interviewer-drive-invites.component';
import { InterviewerHomeComponent } from './Interviewer/interviewer-home/interviewer-home.component';
import { ProfileComponent } from './Shared/profile/profile.component';

const routes: Routes = [
  { path: 'interviewer-home', component:InterviewerHomeComponent },
  { path: 'profile', component:ProfileComponent },
  { path: 'interviewer-dashboard', component:InterviewerDashboardComponent },
  { path: 'interviewer-currentDrives', component:InterviewerCurrentDriveComponent },
  { path: 'interviewer-driveInvites', component:InterviewerDriveInvitesComponent },
  {path:'', component:InterviewerHomeComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
