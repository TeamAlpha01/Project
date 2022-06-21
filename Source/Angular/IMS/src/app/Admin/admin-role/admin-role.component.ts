import { Component, OnInit } from '@angular/core';
import { Role } from 'src/app/Model/Role';
import { ConnectionService } from 'src/app/Services/connection.service';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-admin-role',
  templateUrl: './admin-role.component.html',
  styleUrls: ['./admin-role.component.css'],
})
export class AdminRoleComponent implements OnInit {
  title = 'Add Role';
  response: string = '';
  submitted: boolean = false;

  constructor(private service: ConnectionService, private fb: FormBuilder) {}

  ngOnInit(): void {    
  }

  AddRoleForm = this.fb.group({
    roleName: [
      '',
      [
        Validators.required,
        Validators.minLength(3),
        Validators.pattern('[A-Za-z\\s]*')
      ],
    ],
  });

  getRoleName(){
    return this.AddRoleForm.get('roleName');
  }

  addRole() {
    this.submitted = true;
    if (this.AddRoleForm.valid) {
      this.service
        .AddRole(this.getRoleName()?.value)
        .subscribe((data) => (this.response = data.message));

      setTimeout(() => {
        this.response = '';
        this.AddRoleForm.reset();
      }, 1000);

      this.submitted = false;
    }
  }

  pageTitle = 'Department';
}
