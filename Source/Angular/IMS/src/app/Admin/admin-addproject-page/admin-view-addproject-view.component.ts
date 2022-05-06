import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-admin-view-addproject-page',
  templateUrl: './admin-view-addproject-page.component.html',
  styleUrls: ['./admin-view-addproject-page.component.css']
})
export class AdminViewAddprojectPageComponent implements OnInit {
  data: any;
  totalLength: any;
  page: number = 1;
 
  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.http
      .get<any>('https://localhost:7072/Role/ViewAddproject')
      .subscribe((data) => {
        this.data = data;
        this.totalLength = data.length;
      });
  }

}
