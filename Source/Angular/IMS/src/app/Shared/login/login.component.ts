import { HttpClient } from '@angular/common/http';
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


  loginForm = this.FB.group({
    ACENumber: ['', [Validators.required, Validators.pattern("ACE+[0-9]{4}")]],
    Password: ['', [Validators.required]]
  });


  constructor(private http: HttpClient, private route: Router, private connection: ConnectionService, private FB: FormBuilder) { }
  user: any = {
    ACENumber: this.loginForm.value['ACENumber'],
    Password: this.loginForm.value['Password'],
  }




  ngOnInit(): void {

  }

  submit() {

    if (this.loginForm.valid) {
      console.log(this.user)
      this.connection.Login(this.user).subscribe((data: any) => {

        this.IsAdmin = data.isAdmin
        this.IsTAC = data.isTAC

        AuthenticationService.SetDateWithExpiry("token", data.token, data.expiryInMinutes)
        AuthenticationService.SetDateWithExpiry("Admin", data.isAdmin, data.expiryInMinutes)
        AuthenticationService.SetDateWithExpiry("TAC", data.isReviewer, data.expiryInMinutes)

        console.log(AuthenticationService.GetData("token"))
        console.log(AuthenticationService.GetData("Admin"))
        console.log(AuthenticationService.GetData("TAC"))

        if (this.IsAdmin) {
          this.route.navigateByUrl("/Admin-role");  //navigation
        }
        else if (this.IsTAC) {
          this.route.navigateByUrl("/tac/home");
        }
        else {
          this.route.navigateByUrl("/interviewer-home");
        }
        console.log(data)

      },
        //  (error:any)=>{
        //   console.warn("1");
        //   console.warn(error);
        //   if(error.status==404){
        //     this.route.navigateByUrl("errorPage");        
        //   }
        // }
      )
    }


  }
}
