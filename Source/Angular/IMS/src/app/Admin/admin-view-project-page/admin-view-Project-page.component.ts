import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';

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
 
  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.http
      .get<any>('https://localhost:7072/Project/ViewProjects')
      .subscribe((data) => {
        this.data = data;
        this.totalLength = data.length;
      });
  }

}
