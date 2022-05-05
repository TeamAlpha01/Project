import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {FormsModule} from '@angular/forms';
import { NgxPaginationModule } from 'ngx-pagination';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { InterviewerHeaderComponent } from './Interviewer/interviewer-header/interviewer-header.component';
import { FooterComponent } from './Shared/footer/footer.component';
import { AdminRoleComponent } from './Admin/admin-role/admin-role.component';
import { BackButtonComponent } from './Shared/back-button/back-button.component';
import { InterviewerHomeComponent } from './Interviewer/interviewer-home/interviewer-home.component';
import { ProfileComponent } from './Shared/profile/profile.component';
import { AdminHeaderComponent } from './Admin/admin-header/admin-header.component';
import { TacHeaderComponent } from './TAC/tac-header/tac-header.component';
import { DriveDetailCardComponent } from './Shared/drive-detail-card/drive-detail-card.component';
import { InterviewerCurrentDriveComponent } from './Interviewer/interviewer-current-drive/interviewer-current-drive.component';
import { InterviewerDashboardComponent } from './Interviewer/interviewer-dashboard/interviewer-dashboard.component';
import { InterviewerDriveInvitesComponent } from './Interviewer/interviewer-drive-invites/interviewer-drive-invites.component';
import { InterviewerScheduledDriveComponent } from './Interviewer/interviewer-scheduled-drive/interviewer-scheduled-drive.component';
import { InterviewerUpcomingDriveComponent } from './Interviewer/interviewer-upcoming-drive/interviewer-upcoming-drive.component';
import { TacHomeComponent } from './TAC/tac-home/tac-home.component';
import { TacDashboardComponent } from './TAC/tac-dashboard/tac-dashboard.component';
import { AdminAddlocationComponent } from './Admin/admin-addlocation/admin-addlocation.component';
import { AdminAddprojectComponent } from './Admin/admin-addproject/admin-addproject.component';
import { AdminAdddepartmentComponent } from './Admin/admin-adddepartment/admin-adddepartment.component';
import { AdminRequestsComponent } from './Admin/admin-requests/admin-requests.component';
import { CreatepoolComponent } from './TAC/createpool/createpool.component';
import { AdminDashboardComponent } from './Admin/admin-dashboard/admin-dashboard.component';

import { PoolmembersPerformanceComponent } from './TAC/poolmembers-performance/poolmembers-performance.component';
import { MyperformanceComponent } from './TAC/myperformance/myperformance.component';
import { DashboardComponent } from './Shared/dashboard/dashboard.component';
import { EditpoolComponent } from './TAC/editpool/editpool.component';
import { ManagepoolmembersComponent } from './TAC/managepoolmembers/managepoolmembers.component';
import { AdminViewRoleComponent } from './Admin/admin-view-role/admin-view-role.component';
import { CurrentDrivesFilterComponent } from './TAC/current-drives-filter/current-drives-filter.component';







@NgModule({
  declarations: [
    AppComponent,
    InterviewerHeaderComponent,
    FooterComponent,
    AdminRoleComponent,
    BackButtonComponent,
    InterviewerHomeComponent,
    ProfileComponent,
    AdminHeaderComponent,
    TacHeaderComponent,
    DriveDetailCardComponent,
    InterviewerCurrentDriveComponent,
    InterviewerDashboardComponent,
    InterviewerDriveInvitesComponent,
    InterviewerScheduledDriveComponent,
    InterviewerUpcomingDriveComponent,
    TacHomeComponent,
    AdminAddlocationComponent,
    AdminAddprojectComponent,
    TacDashboardComponent,
    AdminAdddepartmentComponent,
    AdminRequestsComponent,
    CreatepoolComponent,
    PoolmembersPerformanceComponent,
    MyperformanceComponent,
    AdminDashboardComponent,
    DashboardComponent,
    EditpoolComponent,
    ManagepoolmembersComponent,
    AdminViewRoleComponent,
    CurrentDrivesFilterComponent

  ],
  
  imports: [
    BrowserModule,
    FormsModule,
    NgxPaginationModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
