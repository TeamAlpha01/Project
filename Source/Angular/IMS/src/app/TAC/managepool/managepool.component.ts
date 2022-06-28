import { Component, OnInit } from '@angular/core';
import { ConnectionService } from 'src/app/Services/connection.service';
import { DialogBoxComponent } from 'src/app/Shared/DialogBox/dialog-box/dialog-box.component';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-managepool',
  templateUrl: './managepool.component.html',
  styleUrls: ['./managepool.component.css']
})
export class ManagepoolComponent implements OnInit {
  title = 'Manage Pool'

  poolDetails: any;
  departmentDetails: any;
  _dept = '';
  _pool = '';
  page: number = 1;
  totalLength: any;


  constructor(private connection: ConnectionService, private dialog: MatDialog) { }

  ngOnInit(): void {
    this.GetPools();
    this.GetDepartments();
  }

  GetPools() {
    this.connection.GetPools().subscribe((data: any) => {
      this.poolDetails = data;
    })
  }

  GetDepartments() {
    this.connection.GetDepartments().subscribe((data: any) => {
      this.departmentDetails = data;
    })
  }

  RemovePool(poolId: number) {
    let dialogRef = this.dialog.open(DialogBoxComponent);
    dialogRef.afterClosed().subscribe((result) => {
      if (result == 'confirm') {
        this.connection.RemovePool(poolId).subscribe(() => this.GetPools());
      }
    });
  }


}
