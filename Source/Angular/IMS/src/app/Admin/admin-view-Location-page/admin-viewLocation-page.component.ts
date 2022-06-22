import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { ConnectionService } from 'src/app/Services/connection.service';

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

  constructor(private service: ConnectionService) {}

  ngOnInit(): void {
    this.GetLocations();
  }

  removeLocation(employeeId: number) {
    this.service
      .RemoveLocation(employeeId)
      .subscribe(() => this.GetLocations());
  }

  GetLocations() {
    this.service.GetLocations().subscribe((data: any) => {
      this.location = data;
      this.totalLength = data.length;
    });
  }
}
