import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {FormsModule} from '@angular/forms';
import { NgxPaginationModule } from 'ngx-pagination';
import { HttpClient, HttpClientModule } from '@angular/common/http';

import { AdminAddlocationComponent } from './Admin/admin-addlocation/admin-addlocation.component';
import { AdminAddprojectComponent } from './Admin/admin-addproject/admin-addproject.component';
import { AdminAdddepartmentComponent } from './Admin/admin-adddepartment/admin-adddepartment.component';
import { AdminRequestsComponent } from './Admin/admin-requests/admin-requests.component';
import { AdminDashboardComponent } from './Admin/admin-dashboard/admin-dashboard.component';
import { AdminRoleComponent } from './Admin/admin-role/admin-role.component';
import { AdminViewRolePageComponent } from './Admin/admin-view-role-page/admin-view-role-page.component';
import { AdminViewRequestsPageComponent } from './Admin/admin-view-requests-page/admin-view-requests-page.component';
import { AdminviewProjectPageComponent } from './Admin/admin-view-project-page/admin-view-Project-page.component';
import { AdminviewDepartmentPageComponent } from './Admin/admin-view-department-page/admin-view-department-page.component';
import { AdminviewLocationPageComponent } from './Admin/admin-view-location-page/admin-viewLocation-page.component';

import { CreatepoolComponent } from './TAC/createpool/createpool.component';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { InterviewerHeaderComponent } from './Interviewer/interviewer-header/interviewer-header.component';
import { FooterComponent } from './Shared/footer/footer.component';
import { BackButtonComponent } from './Shared/back-button/back-button.component';
import { InterviewerHomeComponent } from './Interviewer/interviewer-home/interviewer-home.component';
import { ProfileComponent } from './Shared/profile/profile.component';
import { TacHeaderComponent } from './TAC/tac-header/tac-header.component';
import { InterviewerCurrentDriveComponent } from './Interviewer/interviewer-current-drive/interviewer-current-drive.component';
import { InterviewerDashboardComponent } from './Interviewer/interviewer-dashboard/interviewer-dashboard.component';
import { InterviewerDriveInvitesComponent } from './Interviewer/interviewer-drive-invites/interviewer-drive-invites.component';
import { InterviewerScheduledDriveComponent } from './Interviewer/interviewer-scheduled-drive/interviewer-scheduled-drive.component';
import { TacHomeComponent } from './TAC/tac-home/tac-home.component';
import { TacDashboardComponent } from './TAC/tac-dashboard/tac-dashboard.component';

import { PoolmembersPerformanceComponent } from './TAC/poolmembers-performance/poolmembers-performance.component';
import { MyperformanceComponent } from './TAC/myperformance/myperformance.component';
import { DashboardComponent } from './Shared/dashboard/dashboard.component';
import { EditpoolComponent } from './TAC/editpool/editpool.component';
import { ManagepoolmembersComponent } from './TAC/managepoolmembers/managepoolmembers.component';
import { TacProfileComponent } from './TAC/tac-profile/tac-profile.component';
import { CardDetailsComponent } from './Shared/card-details/card-details.component';
import { InterviewerUpcomingDriveComponent } from './Interviewer/interviewer-upcoming-drive/interviewer-upcoming-drive.component';
import { NavbarComponent } from './Shared/navbar/navbar.component';
import { LoginComponent } from './Shared/login/login.component';

import { ManagepoolComponent } from './TAC/managepool/managepool.component';
import { TacCurrentDriveComponent } from './TAC/tac-current-drive/tac-current-drive.component';
import { TacScheduledDriveComponent } from './TAC/tac-scheduled-drive/tac-scheduled-drive.component';
import { CreateInviteComponent } from './TAC/create-invite/create-invite.component';
import { AdminHeaderComponent } from './Admin/admin-header/admin-header.component';





@NgModule({
  declarations: [
    AppComponent,
    AdminHeaderComponent,
    AdminRoleComponent, 
    AdminAdddepartmentComponent,
    AdminAddlocationComponent,
    AdminviewLocationPageComponent,
    AdminAddprojectComponent,
    AdminDashboardComponent,
    AdminRequestsComponent,
    AdminViewRolePageComponent,
    AdminViewRequestsPageComponent,

    InterviewerHeaderComponent,
    FooterComponent,
    BackButtonComponent,
    InterviewerHomeComponent,
    ProfileComponent,
    TacHeaderComponent,
    InterviewerCurrentDriveComponent,
    InterviewerDashboardComponent,
    InterviewerDriveInvitesComponent,
    InterviewerScheduledDriveComponent,
    TacHomeComponent,
    TacDashboardComponent,
    CreatepoolComponent,
    PoolmembersPerformanceComponent,
    MyperformanceComponent,
    DashboardComponent,
    EditpoolComponent,
    ManagepoolmembersComponent,
    TacProfileComponent,
    CardDetailsComponent,
    InterviewerUpcomingDriveComponent,
    NavbarComponent,
    LoginComponent,
    TacCurrentDriveComponent,
    ManagepoolComponent,
    TacProfileComponent,
    TacCurrentDriveComponent,
    TacScheduledDriveComponent,
    CreateInviteComponent,
    AdminViewRequestsPageComponent,   

  ],
  
  imports: [
    BrowserModule,
    FormsModule,
    NgxPaginationModule,
    AppRoutingModule,
    HttpClientModule,
    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }