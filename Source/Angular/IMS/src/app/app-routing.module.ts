import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminRoleComponent } from './Admin/admin-role/admin-role.component';
import { InterviewerCurrentDriveComponent } from './Interviewer/interviewer-current-drive/interviewer-current-drive.component';
import { InterviewerHomeComponent } from './Interviewer/interviewer-home/interviewer-home.component';
import { ProfileComponent } from './Shared/profile/profile.component';

const routes: Routes = [
  { path: 'home', component:InterviewerHomeComponent },
  { path: 'home', component:InterviewerHomeComponent },
  { path: 'profile', component:ProfileComponent },
  {path:'', component:InterviewerCurrentDriveComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
