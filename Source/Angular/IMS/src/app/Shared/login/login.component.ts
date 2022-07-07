import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/app/Services/authentication.service';
import { ConnectionService } from 'src/app/Services/connection.service';
import { Router, Event, NavigationStart, NavigationEnd } from '@angular/router';
import { FormBuilder, Validators } from '@angular/forms';
import { MatProgressSpinner } from '@angular/material/progress-spinner';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  IsAdmin: boolean = false;
  IsTAC: boolean = false;
  employeeDetails: any;
  employeeID = '';
  employeeACENumber: any;
  error: string = '';
  isCommanError: boolean = false;
  loading: boolean = false;
  submitted: boolean = false;


  loginForm = this.FB.group({
    ACENumber: ['', [Validators.required, Validators.pattern("ACE+[0-9]{4}")]],
    Password: ['', [Validators.required]]
  });


  constructor(private http: HttpClient, private route: Router, private connection: ConnectionService, private FB: FormBuilder) { }





  ngOnInit(): void {

  }

  submit() {

    this.submitted = true;
    if (this.loginForm.valid) {
      this.loading = true
      const user = {
        ACENumber: this.loginForm.value['ACENumber'],
        Password: this.loginForm.value['Password'],
      }

      this.connection.Login(user).subscribe({
        next: (data: any) => {

          this.IsAdmin = data.isAdmin
          this.IsTAC = data.isTAC

          AuthenticationService.SetDateWithExpiry("token", data.token, data.expiryInMinutes)
          AuthenticationService.SetDateWithExpiry("Admin", data.isAdmin, data.expiryInMinutes)
          AuthenticationService.SetDateWithExpiry("TAC", data.isTAC, data.expiryInMinutes)
          AuthenticationService.SetDateWithExpiry("Management", data.isManagement, data.expiryInMinutes)
          AuthenticationService.SetUserName("UserName", data.userName)

          this.connection.initializeTokenHeader(AuthenticationService.GetData("token"))

          if (this.IsAdmin) {
            this.route.navigateByUrl("/admin/requests");  //navigation
          }
          else if (this.IsTAC) {
            this.route.navigateByUrl("/tac/home");
          }
          else {
            this.route.navigateByUrl("/interviewer/home");
          }



        },
        error: (error: any) => {

          if (error.status == 404) {
            this.route.navigateByUrl("errorPage");
          }
          if (!(error.error.toString().includes('ACE') || error.error.toString().includes('Password'))) {
            this.isCommanError = true;
          }
          this.error = error.error;
          this.loading = false;
        },
        complete: () => {

          return this.loading = false;
        }
      })
    }
  }
}


