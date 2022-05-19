import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { ConnectionService } from 'src/app/Services/connection.service';

@Component({
  selector: 'app-admin-addproject-page',
  templateUrl: './admin-view-Project-page.component.html',
  styleUrls: ['./admin-view-Project-page.component.css']
})
export class AdminviewProjectPageComponent implements OnInit {
  data: any;
  totalLength: any;
  page: number = 1;
  title = "View Project";
 
  constructor(private connection: ConnectionService) { }

  ngOnInit(): void {
    this.connection.GetLocations().subscribe((data: any) => {
      this.data = data;
      console.log(this.data)
    })
  }

}
