import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-admin-view-addproject-page',
  templateUrl: './admin-addproject-page.component.html',
  styleUrls: ['./admin-addproject-page.component.css']
})
export class AdminAddprojectPageComponent implements OnInit {
  data: any;
  totalLength: any;
  page: number = 1;
  title="Add Project";
 
  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.http
      .get<any>('https://localhost:7072/Role/Addproject')
      .subscribe((data) => {
        this.data = data;
        this.totalLength = data.length;
      });
  }

}
