import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-admin-AddLocation-page',
  templateUrl: './admin-AddLocation-page.component.html',
  styleUrls: ['./admin-AddLocation-page.component.css']
})
export class AdminAddLocationPageComponent implements OnInit {
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
