import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/app/Services/authentication.service';
import { ConnectionService } from 'src/app/Services/connection.service';
import { Router } from '@angular/router';
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
  currentUser: string = '';


  loginForm = this.FB.group({
    EmailID: ['', [Validators.required, Validators.pattern("([a-zA-Z0-9-_\.]{4,22})@(aspiresys.com)")]],
    Password: ['', [Validators.required]]
  });



  constructor(private route: Router, private connection: ConnectionService, private FB: FormBuilder) { }





  ngOnInit(): void {

  }

  submit() {

    this.submitted = true;
    if (this.loginForm.valid) {
      this.isCommanError = false;
      this.loading = true
      const user = {
        emailId: this.loginForm.value['EmailID'],
        password: this.loginForm.value['Password'],
      }

      this.connection.Login(user).subscribe({
        next: (data: any) => {

          AuthenticationService.SetDateWithExpiry("token", data.token, data.expiryInMinutes)
          AuthenticationService.SetDateWithExpiry("user", data.userHash, data.expiryInMinutes)
          AuthenticationService.SetUserName("UserName", data.userName)

          this.connection.initializeTokenHeader(AuthenticationService.GetData("token"))
          this.currentUser = AuthenticationService.GetUser();
          if (this.currentUser == "Admin") {
            this.route.navigateByUrl("/admin/requests");  //navigation
          }
          else if (this.currentUser == "TAC") {
            this.route.navigateByUrl("/tac/home");
          }
          else {
            this.route.navigateByUrl("/interviewer/home");
          }



        },
        error: (error: any) => {
          if (!error.error.toString().includes('email'))
            this.isCommanError = true
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


