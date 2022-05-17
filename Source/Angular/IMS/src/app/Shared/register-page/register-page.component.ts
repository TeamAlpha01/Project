import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-register-page',
  templateUrl: './register-page.component.html',
  styleUrls: ['./register-page.component.css']
})
export class RegisterPageComponent implements OnInit {
  registerForm: any;

  constructor() { }

  ngOnInit(): void {
  }
  // validateName() {
  //   this.registerForm = this.formBuilder.group({
  //     Name: ['', [Validators.required, Validators.pattern('^[a-zA-Z]{3,30}$')]],
  //     ACENumber: ['', [Validators.required, Validators.pattern('^[ACE][0-9]{4}$')]],
  //     Department: ['', [Validators.required, Validators.pattern('^[a-zA-Z][*@#.]$')]],
  //     Role: ['', [Validators.required, Validators.pattern('^[a-zA-Z]{10}$')]],
  //     Project: ['', [Validators.required, Validators.pattern('^[a-zA-Z][20]$')]],
  //     EMailId: ['', [Validators.required, Validators.pattern('^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$')]],
  //     MobileNumber: ['', [Validators.required, Validators.pattern('^[6-9][0-9]{9}$')]],
  //     Password: ['', [Validators.required, Validators.pattern('^(?=.*[A-Z].*[A-Z])(?=.*[!@#$&*])(?=.*[0-9].*[0-9])(?=.*[a-z].*[a-z].*[a-z]).{8}$')]],
  //     ConfirmPassword: ['', [Validators.required, Validators.pattern('^(?=.*[A-Z].*[A-Z])(?=.*[!@#$&*])(?=.*[0-9].*[0-9])(?=.*[a-z].*[a-z].*[a-z]).{8}$')]]
  //   })
  // }
}
