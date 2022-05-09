import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-admin-view-project-page',
  templateUrl: './admin-view-project-page.component.html',
  styleUrls: ['./admin-view-project-page.component.css']
})
export class AdminViewProjectPageComponent implements OnInit {

  title='View Project'
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
