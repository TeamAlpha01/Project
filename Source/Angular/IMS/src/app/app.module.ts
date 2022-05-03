import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { InterviewerHeaderComponent } from './interviewer-header/interviewer-header.component';
import { FooterComponent } from './footer/footer.component';
import { AdminRoleComponent } from './admin-role/admin-role.component';
import { BackButtonComponent } from './back-button/back-button.component';


@NgModule({
  declarations: [
    AppComponent,
    InterviewerHeaderComponent,
    FooterComponent,
    AdminRoleComponent,
    BackButtonComponent

  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
