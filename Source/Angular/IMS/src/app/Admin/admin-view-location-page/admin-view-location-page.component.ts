import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-admin-view-location-page',
  templateUrl: './admin-view-location-page.component.html',
  styleUrls: ['./admin-view-location-page.component.css']
})
export class AdminViewLocationPageComponent implements OnInit {

  title='View Location'

  data: any;
  totalLength: any;
  page: number = 1;
 
  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.http
      .get<any>('https://localhost:7072/Role/Addlocation')
      .subscribe((data) => {
        this.data = data;
        this.totalLength = data.length;
      });
  }

}
