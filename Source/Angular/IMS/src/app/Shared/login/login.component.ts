import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';

import { user } from 'src/app/Model/user';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor() { }

  userDetails: user = {
    aceNumber: '',
    password:''
  }
  ngOnInit(): void {
  }
  login(){
    console.log(this.userDetails);
    // this.userDetails.resetform();
    //this.userDetails.['reset'];
  }

}
