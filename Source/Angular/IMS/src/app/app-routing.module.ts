import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminRoleComponent } from './admin-role/admin-role.component';
import { InterviewerHomeComponent } from './interviewer-home/interviewer-home.component';
import { ProfileComponent } from './profile/profile.component';

const routes: Routes = [
  { path: '', component:InterviewerHomeComponent },
  { path: 'home', component:InterviewerHomeComponent },
  { path: 'profile', component:ProfileComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
