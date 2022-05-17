import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { FormGroup } from '@angular/forms';
import { Validators } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  public registerForm!: FormGroup;
  constructor(private formBuilder: FormBuilder, private http: HttpClient, private router: Router) { }

  ngOnInit(): void { }
  validateName() {
    this.registerForm = this.formBuilder.group({
      Name: ['', [Validators.required, Validators.pattern('^[a-zA-Z]{3,30}$')]],
      ACENumber: ['', [Validators.required, Validators.pattern('^[ACE][0-9]{4}$')]],
      Department: ['', [Validators.required, Validators.pattern('^[a-zA-Z][*@#.]$')]],
      Role: ['', [Validators.required, Validators.pattern('^[a-zA-Z]{10}$')]],
      Project: ['', [Validators.required, Validators.pattern('^[a-zA-Z][20]$')]],
      EMailId: ['', [Validators.required, Validators.pattern('^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$')]],
      MobileNumber: ['', [Validators.required, Validators.pattern('^[6-9][0-9]{9}$')]],
      Password: ['', [Validators.required, Validators.pattern('^(?=.*[A-Z].*[A-Z])(?=.*[!@#$&*])(?=.*[0-9].*[0-9])(?=.*[a-z].*[a-z].*[a-z]).{8}$')]],
      ConfirmPassword: ['', [Validators.required, Validators.pattern('^(?=.*[A-Z].*[A-Z])(?=.*[!@#$&*])(?=.*[0-9].*[0-9])(?=.*[a-z].*[a-z].*[a-z]).{8}$')]]
    })
  }
}