import { SnackBarComponent } from './Shared/SnackBar/snack-bar/snack-bar.component';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { NgxPaginationModule } from 'ngx-pagination';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgxSpinnerModule } from 'ngx-spinner';


import { AdminAddlocationComponent } from './Admin/admin-addlocation/admin-addlocation.component';
import { AdminAddprojectComponent } from './Admin/admin-addproject/admin-addproject.component';
import { AdminAdddepartmentComponent } from './Admin/admin-adddepartment/admin-adddepartment.component';
import { AdminDashboardComponent } from './Admin/admin-dashboard/admin-dashboard.component';
import { AdminRoleComponent } from './Admin/admin-role/admin-role.component';
import { AdminViewRolePageComponent } from './Admin/admin-view-role-page/admin-view-role-page.component';
import { AdminViewRequestsPageComponent } from './Admin/admin-view-requests-page/admin-view-requests-page.component';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { InterviewerHeaderComponent } from './Interviewer/interviewer-header/interviewer-header.component';
import { FooterComponent } from './Shared/footer/footer.component';
import { BackButtonComponent } from './Shared/back-button/back-button.component';
import { InterviewerHomeComponent } from './Interviewer/interviewer-home/interviewer-home.component';
import { TacHeaderComponent } from './TAC/tac-header/tac-header.component';
import { InterviewerCurrentDriveComponent } from './Interviewer/interviewer-current-drive/interviewer-current-drive.component';
import { InterviewerDashboardComponent } from './Interviewer/interviewer-dashboard/interviewer-dashboard.component';
import { InterviewerDriveInvitesComponent } from './Interviewer/interviewer-drive-invites/interviewer-drive-invites.component';
import { InterviewerScheduledDriveComponent } from './Interviewer/interviewer-scheduled-drive/interviewer-scheduled-drive.component';
import { TacHomeComponent } from './TAC/tac-home/tac-home.component';
import { TacDashboardComponent } from './TAC/tac-dashboard/tac-dashboard.component';

import { PoolmembersPerformanceComponent } from './TAC/poolmembers-performance/poolmembers-performance.component';
import { MyperformanceComponent } from './TAC/myperformance/myperformance.component';
import { TacProfileComponent } from './TAC/tac-profile/tac-profile.component';
import { CardDetailsComponent } from './Shared/card-details/card-details.component';
import { InterviewerUpcomingDriveComponent } from './Interviewer/interviewer-upcoming-drive/interviewer-upcoming-drive.component';
import { NavbarComponent } from './Shared/navbar/navbar.component';
import { LoginComponent } from './Shared/login/login.component';

import { ManagepoolComponent } from './TAC/managepool/managepool.component';
import { TacCurrentDriveComponent } from './TAC/tac-current-drive/tac-current-drive.component';
import { TacScheduledDriveComponent } from './TAC/tac-scheduled-drive/tac-scheduled-drive.component';
import { CreateInviteComponent } from './TAC/create-invite/create-invite.component';
import { InterviewerAcceptInvitePageComponent } from './Interviewer/interviewer-accept-invite-page/interviewer-accept-invite-page.component';
import { AdminHeaderComponent } from './Admin/admin-header/admin-header.component';
import { TacUpcomingDriveComponent } from './TAC/tac-upcoming-drive/tac-upcoming-drive.component';
import { InterviewerCardDetailsComponent } from './Interviewer/interviewer-card-details/interviewer-card-details.component';

import { ManageCardsComponent } from './Shared/manage-cards/manage-cards.component';
import { AdminviewProjectPageComponent } from './Admin/admin-view-project-page/admin-view-Project-page.component';
import { PerformanceDashboardComponent } from './Shared/performance-dashboard/performance-dashboard.component';

import { AdminviewLocationPageComponent } from './Admin/admin-view-Location-page/admin-viewLocation-page.component';
import { AdminviewDepartmentPageComponent } from './Admin/admin-view-department-page/admin-view-department-page.component';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { ViewResponseCardComponent } from './TAC/view-response-card/view-response-card.component';
import { TacCreatePoolComponent } from './TAC/tac-create-pool/tac-create-pool.component';
import { TacEditPoolComponent } from './TAC/tac-edit-pool/tac-edit-pool.component';
import { TacEditPoolMemberComponent } from './TAC/tac-edit-pool-member/tac-edit-pool-member.component';
import { TacCancelDriveComponent } from './TAC/tac-cancel-drive/tac-cancel-drive.component';
import { InterviwerProfileComponent } from './Interviewer/interviwer-profile/interviwer-profile.component';
import { RegisterPageComponent } from './Shared/register-page/register-page.component';
import { ErrorPageComponent } from './Shared/error-page/error-page.component';
import { TacScheduledDriveHistoryComponent } from './TAC/tac-scheduled-drive-history/tac-scheduled-drive-history.component';
import { TacCancelledDriveHistoryComponent } from './TAC/tac-cancelled-drive-history/tac-cancelled-drive-history.component';
import { HistoryCardComponent } from './Shared/history-card/history-card.component';
import { TacEmployeeDashboardComponent } from './TAC/tac-employee-dashboard/tac-employee-dashboard.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatButtonModule } from '@angular/material/button';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { DialogBoxComponent } from './Shared/DialogBox/dialog-box/dialog-box.component';
import { MatDialogModule } from '@angular/material/dialog';







@NgModule({
  declarations: [
    AppComponent,
    AdminHeaderComponent,
    AdminRoleComponent,
    AdminAdddepartmentComponent,
    AdminAddlocationComponent,
    AdminAddprojectComponent,
    AdminDashboardComponent,
    AdminviewProjectPageComponent,
    AdminViewRolePageComponent,
    AdminviewDepartmentPageComponent,
    AdminviewLocationPageComponent,
    InterviewerHeaderComponent,
    FooterComponent,
    BackButtonComponent,
    InterviewerHomeComponent,
    TacHeaderComponent,
    InterviewerCurrentDriveComponent,
    InterviewerDashboardComponent,
    InterviewerDriveInvitesComponent,
    InterviewerScheduledDriveComponent,
    TacHomeComponent,
    TacDashboardComponent,
    TacCreatePoolComponent,
    PoolmembersPerformanceComponent,
    MyperformanceComponent,
    TacEditPoolComponent,
    TacEditPoolMemberComponent,
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
    InterviewerAcceptInvitePageComponent,
    TacUpcomingDriveComponent,
    InterviewerCardDetailsComponent,
    ManageCardsComponent,
    PerformanceDashboardComponent,
    ViewResponseCardComponent,
    TacCreatePoolComponent,
    TacEditPoolComponent,
    TacEditPoolMemberComponent,
    TacCancelDriveComponent,
    InterviwerProfileComponent,
    RegisterPageComponent,
    ErrorPageComponent,
    TacScheduledDriveHistoryComponent,
    TacCancelledDriveHistoryComponent,
    HistoryCardComponent,
    TacEmployeeDashboardComponent,
    SnackBarComponent,
    DialogBoxComponent

  ],

  imports: [
    BrowserModule,
    NgxPaginationModule,
    AppRoutingModule,
    HttpClientModule,
    Ng2SearchPipeModule,
    ReactiveFormsModule,
    FormsModule,
    NgxSpinnerModule,
    BrowserAnimationsModule,
    MatProgressSpinnerModule,
    MatButtonModule,
    MatSnackBarModule,
    MatDialogModule


  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }