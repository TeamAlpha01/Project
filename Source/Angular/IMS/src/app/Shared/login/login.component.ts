import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/Services/authentication.service';


import { user } from 'src/app/Model/user';
import { ConnectionService } from 'src/app/Services/connection.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  IsAdmin: boolean = false;
  IsTAC: boolean = false;
  employeeDetails: any;
  employeeID='';
  employeeACENumber: any;
  constructor(private http: HttpClient, private route: Router, private connection:ConnectionService) { }
  user: any = {

    ACENumber: '',
    Password: '',

  }


  ngOnInit(): void {
  }

  onSubmit() {
    const headers = { 'content-type': 'application/json' }

    console.log(this.user)
      this.connection.Login(this.user).subscribe((data) => {

        this.IsAdmin = data.isAdmin
        this.IsTAC = data.isTAC
        AuthenticationService.SetDateWithExpiry("token", data.token, data.expiryInMinutes)
        AuthenticationService.SetDateWithExpiry("Admin", data.isAdmin, data.expiryInMinutes)
        AuthenticationService.SetDateWithExpiry("TAC", data.isReviewer, data.expiryInMinutes)

        console.log(AuthenticationService.GetData("token"))
        console.log(AuthenticationService.GetData("Admin"))
        console.log(AuthenticationService.GetData("TAC"))

        if (this.IsAdmin) {
          this.route.navigateByUrl("/Admin-requests");  //navigation
        }
        else if (this.IsTAC) {
          this.route.navigateByUrl("/tac-home");
        }
        else {
          this.route.navigateByUrl("/interviewer-home");
        }
        console.log(data)

      });
      // this.connection.GetEmployees().subscribe((data: any) => {
      //   this.employeeDetails = data;
      //   for (let item of this.employeeDetails) {
      //     if (this.user.ACENumber == item.employeeAceNumber) {
      //       this.employeeID = item.employeeId            
      //     }
      //   }
      // })
  
      
  }
}
