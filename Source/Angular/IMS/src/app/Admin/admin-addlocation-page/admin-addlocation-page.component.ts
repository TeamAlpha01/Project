import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-admin-addlocation-page',
  templateUrl: './admin-addlocation-page.component.html',
  styleUrls: ['./admin-addlocation-page.component.css']
})
export class AdminAddlocationPageComponent implements OnInit {
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
