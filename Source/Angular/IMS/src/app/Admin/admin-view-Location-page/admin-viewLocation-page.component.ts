import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { ConnectionService } from 'src/app/Services/connection.service';
import { DialogBoxComponent } from 'src/app/Shared/DialogBox/dialog-box/dialog-box.component';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-admin-AddLocation-page',
  templateUrl: './admin-viewLocation-page.component.html',
  styleUrls: ['./admin-viewLocation-page.component.css'],
})
export class AdminviewLocationPageComponent implements OnInit {
  title = 'Locations';
  location: any;
  totalLength: any;
  page: number = 1;

  constructor(private service: ConnectionService,private dialog: MatDialog) {}

  ngOnInit(): void {
    this.GetLocations();
  }

  removeLocation(employeeId: number) {
    let dialogRef = this.dialog.open(DialogBoxComponent);
    dialogRef.afterClosed().subscribe((result) => {
      if (result == 'confirm') {
        this.service
          .RemoveLocation(employeeId)
          .subscribe(() => this.GetLocations());
      }
    });
  }

  GetLocations() {
    this.service.GetLocations().subscribe((data: any) => {
      this.location = data;
      this.totalLength = data.length;
    });
  }
}
