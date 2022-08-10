import { DialogueBoxService } from './../../Services/dialogue-box.service';
import { Component, OnInit } from '@angular/core';
import { ConnectionService } from 'src/app/Services/connection.service';

@Component({
  selector: 'app-admin-view-role-page',
  templateUrl: './admin-view-role-page.component.html',
  styleUrls: ['./admin-view-role-page.component.css'],
})
export class AdminViewRolePageComponent implements OnInit {
  title = "Role"

  role: any;
  totalLength: any;
  page: number = 1;
  response: string = '';
  error: string = '';
  constructor(private service: ConnectionService, private dialogueService: DialogueBoxService) { }

  ngOnInit() {
    this.GetRoles();
  }



  async removeRole(roleId: number, roleName: string) {

    const role = {
      roleId: roleId,
      roleName: roleName
    }

    await this.dialogueService.IsDeleteConfirmed().then((value) => {

      if (value)
        this.service.RemoveRole(role).subscribe({
          next: (data) => { this.response = data.message, this.GetRoles() },
          error: (error) => { this.error = error.error, this.snackBar() },
          complete: () => this.snackBar(),
        });

    });
  }
  //GET METHOD CALLED AT CONNECTION SERVICE
  GetRoles() {
    this.service.GetRoles().subscribe((data: any) => {
      this.role = data;
      this.totalLength = this.role.length;
    });
  }

  snackBar() {
    setTimeout(() => {
      this.error = '';
      this.response = '';
    }, 2000);

  }
}
