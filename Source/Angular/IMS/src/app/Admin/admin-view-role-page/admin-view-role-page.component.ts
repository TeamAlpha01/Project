import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { ConnectionService } from 'src/app/Services/connection.service';
import { MatDialog } from '@angular/material/dialog';
import { DialogBoxComponent } from 'src/app/Shared/DialogBox/dialog-box/dialog-box.component';

@Component({
  selector: 'app-admin-view-role-page',
  templateUrl: './admin-view-role-page.component.html',
  styleUrls: ['./admin-view-role-page.component.css'],
})
export class AdminViewRolePageComponent implements OnInit {
  title: string = 'Roles';
  totalLength: any;
  page: number = 1;
  role: any;

  constructor(private service: ConnectionService,private dialog: MatDialog) {}

  ngOnInit() {
    this.GetRoles();
  }
  removeRole(roleId: number) {
    let dialogRef = this.dialog.open(DialogBoxComponent);
    dialogRef.afterClosed().subscribe((result) => {
      if (result == 'confirm') {
        this.service.RemoveRole(roleId).subscribe(() => this.GetRoles());
      }
    });
  }
  GetRoles() {
    this.service.GetRoles().subscribe((data: any) => {
      this.role = data;
      this.totalLength = this.role.length;
    });
  }
}
