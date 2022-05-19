import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { ConnectionService } from 'src/app/Services/connection.service';

@Component({
  selector: 'app-admin-AddLocation-page',
  templateUrl: './admin-viewLocation-page.component.html',
  styleUrls: ['./admin-viewLocation-page.component.css']
})
export class AdminviewLocationPageComponent implements OnInit {
  data: any;
  totalLength: any;
  page: number = 1;
  title ="View Location";
 
  constructor(private connection: ConnectionService) { }

  ngOnInit(): void {
    this.connection.GetLocations().subscribe((data: any) => {
      this.data = data;
      console.log(this.data)
    })
  }

}



