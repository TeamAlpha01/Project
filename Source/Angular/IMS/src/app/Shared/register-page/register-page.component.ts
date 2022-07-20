import { Project } from './../../Model/Project';
import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ConnectionService } from 'src/app/Services/connection.service';
import { AlertBoxComponent } from '../AlertBox/alert-box/alert-box.component';

@Component({
  selector: 'app-register-page',
  templateUrl: './register-page.component.html',
  styleUrls: ['./register-page.component.css']
})
export class RegisterPageComponent implements OnInit {
  formSubmitted: boolean = false;
  departmentDetails: any;
  roleDetails: any;
  projectDetails: any;
  _dept = '';
  error: string = '';

  registerForm: FormGroup;


  constructor(private FB: FormBuilder, private connection: ConnectionService, private dialog: MatDialog, private router: Router) {
    this.registerForm = this.FB.group({});
  }

  ngOnInit(): void {

    this.registerForm = this.FB.group({
      Name: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(25), Validators.pattern("^(?!.*([ ])\\1)(?!.*([A-Za-z])\\2{2})\\w[a-zA-Z\\s]*$")]],
      ACENumber: ['', [Validators.required, Validators.pattern("^ACE[0-9]{4,5}$"),Validators.pattern("^(?!.*ACE0000).*$"),Validators.pattern("^(?!.*ACE00000).*$")]],
      Department: ['', [Validators.required]],
      Role: [{ value: '', disabled: true }, [Validators.required]],
      Project: [{ value: '', disabled: true } , [Validators.required]],
      Email: ['', [Validators.required, Validators.pattern("([a-zA-Z0-9-_\.]{5,22})@(aspiresys.com)")]],
      Password: ['', [Validators.required, Validators.pattern("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,15}$")]],
      ConfirmPassword: ['', [Validators.required, this.ValidateConfirmPassword]]
    });

    this.GetDepartments();
    this.GetRoles();
    this.GetProjects();
  }

  GetDepartments() {
    this.connection.GetDepartments().subscribe((data: any) => {
      this.departmentDetails = data;
    })
  }
  GetRoles() {
    this.connection.GetRoles().subscribe((data: any) => {
      this.roleDetails = data;
    })
  }
  GetProjects() {
    this.connection.GetProjects().subscribe((data: any) => {
      this.projectDetails = data;
    })
  }

  projectEnabler(){
    if (this.registerForm.get('Department')?.value == '')
    {
      this.registerForm.controls['Project'].disable();
      this.registerForm.controls['Role'].disable();
    }
    else {
      this.registerForm.controls['Project'].enable()
      this.registerForm.controls['Role'].enable()
    }
  }
  projectName() {
    for (let item of this.departmentDetails) {
      if (this.registerForm.value['Department'] == item.departmentId) {
        this._dept = item.departmentName
      }
    }
  }

  submit() {
    this.formSubmitted = true;
    if (this.registerForm.valid) {
      const user = {
        employeeId: 0,
        employeeAceNumber: this.registerForm.value['ACENumber'],
        name: this.registerForm.value['Name'],
        departmentId: this.registerForm.value['Department'],
        roleId: this.registerForm.value['Role'],
        projectId: this.registerForm.value['Project'],
        emailId: this.registerForm.value['Email'],
        password: this.registerForm.value['Password'],
      }

      this.connection.CreateEmployee(user).subscribe({
        next: (data) => { this.OpenAlertBox() },
        error: (error) => this.error = error.error
      });
    }
  }


  ValidateConfirmPassword(control: AbstractControl) {
    if (control.value != control.parent?.get('Password')?.value) {
      return { passwordNotMatched: true };
    }
    return null;
  }

  OpenAlertBox() {
    var dialogRef = this.dialog.open(AlertBoxComponent);
    dialogRef.afterClosed().subscribe((result) => {
      if (result == 'confirm' || result == undefined)
        this.router.navigateByUrl('');
    })
  }
}
