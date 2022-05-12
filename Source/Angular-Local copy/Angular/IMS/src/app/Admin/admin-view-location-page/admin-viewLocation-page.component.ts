import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';

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
 
  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.http
      .get<any>('https://localhost:7072/Location/ViewLocations')
      .subscribe((data) => {
        this.data = data;
        this.totalLength = data.length;
      });
  }

}



