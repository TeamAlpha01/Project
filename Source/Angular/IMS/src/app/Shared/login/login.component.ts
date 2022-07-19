import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/app/Services/authentication.service';
import { ConnectionService } from 'src/app/Services/connection.service';
import { Router, Event, NavigationStart, NavigationEnd } from '@angular/router';
import { FormBuilder, Validators } from '@angular/forms';

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
    EmailID: ['', [Validators.required, Validators.pattern("([a-zA-Z0-9-_\.]{4,22})@(aspiresys.com)")]],
    Password: ['', [Validators.required,Validators.pattern("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^\\da-zA-Z]).{8,15}$")]]
  });


  constructor(private route: Router, private connection: ConnectionService, private FB: FormBuilder) { }





  ngOnInit(): void {

  }

  submit() {

    this.submitted = true;
    if (this.loginForm.valid) {
      this.loading = true
      const user = {
        emailId: this.loginForm.value['EmailID'],
        password: this.loginForm.value['Password'],
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
          if (!(error.error.toString())) {
            this.isCommanError = true;
          }
          if (error.status == 0)
            this.error = "Oops! Server down please try again later";
          else if (error.status == 500)
            this.error = "Sorry some internal error occured please try again later";
          else
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


