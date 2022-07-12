import { Component, OnInit } from '@angular/core';
import { ConnectionService } from 'src/app/Services/connection.service';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-admin-role',
  templateUrl: './admin-role.component.html',
  styleUrls: ['./admin-role.component.css'],
})
export class AdminRoleComponent implements OnInit {
  title = 'Add Role';

  _management = "false";
  //HTTP RESPONSE
  response: string = '';
  error: string = '';
  submitted: boolean = false;

  constructor(private service: ConnectionService, private fb: FormBuilder) { }

  ngOnInit(): void {
  }

  AddRoleForm = this.fb.group({
    //VALIDATE THE INPUT
    roleName: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(30), Validators.pattern('[A-Za-z\\s]*')],],
    management: ['']
  });

  getRoleName() {
    return this.AddRoleForm.get('roleName')?.value;
  }

  getIsManagement() {
    if (this.AddRoleForm.get('management')?.value == '') {
      return 'false';
    }
    else {
      return this.AddRoleForm.get('management')?.value;
    }
  }

  addRole() {
    this.submitted = true;
    this.error = '';
    if (this.AddRoleForm.valid) {
      this.service.AddRole(this.getRoleName(), this.getIsManagement()).subscribe({
        next: (data) => this.response = data.message,
        error: (error) => this.error = error.error.message,
        complete: () => this.clearInputFields(),
      });
    }
  }


  //RESET AFTER SUBMIT
  clearInputFields() {

    this.submitted = false;
    setTimeout(() => {
      this.response = '';
      this.AddRoleForm.reset();
    }, 2000);

  }

  pageTitle = 'Department';
}
