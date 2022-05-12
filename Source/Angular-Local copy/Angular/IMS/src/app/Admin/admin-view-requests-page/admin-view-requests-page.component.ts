import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-admin-view-requests-page',
  templateUrl: './admin-view-requests-page.component.html',
  styleUrls: ['./admin-view-requests-page.component.css']
})
export class AdminViewRequestsPageComponent implements OnInit {
  data: any;
  totalLength: any;
  page: number = 1;
  title="View Request";
 
  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.http
      .get<any>('https://localhost:7072/Role/ViewRequests')
      .subscribe((data) => {
        this.data = data;
        this.totalLength = data.length;
      });
  }

}
