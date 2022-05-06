import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-tac-scheduled-drive',
  templateUrl: './tac-scheduled-drive.component.html',
  styleUrls: ['./tac-scheduled-drive.component.css']
})
export class TacScheduledDriveComponent implements OnInit {

  drive: any;
  totalLength: any;
  page: number = 1;
  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.http
      .get<any>('https://localhost:7072/Drive/ViewTodayDrives')
      .subscribe((data) => {
        this.drive = data;
        this.totalLength = data.length;
      });
  }

}
