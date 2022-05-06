import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-admin-view-addlocation-page',
  templateUrl: './admin-view-addlocation-page.component.html',
  styleUrls: ['./admin-view-addlocation-page.component.css']
})
export class AdminViewAddlocationPageComponent implements OnInit {
  data: any;
  totalLength: any;
  page: number = 1;
 
  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.http
      .get<any>('https://localhost:7072/Role/ViewAddlocation')
      .subscribe((data) => {
        this.data = data;
        this.totalLength = data.length;
      });
  }

}
