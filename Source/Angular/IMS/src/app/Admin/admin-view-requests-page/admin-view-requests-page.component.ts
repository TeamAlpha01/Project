import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { ConnectionService } from 'src/app/Services/connection.service';

@Component({
  selector: 'app-admin-view-requests-page',
  templateUrl: './admin-view-requests-page.component.html',
  styleUrls: ['./admin-view-requests-page.component.css']
})
export class AdminViewRequestsPageComponent implements OnInit {
  data: any[]=[];
  totalLength: any;
  page: number = 1;
  title="Employee Requests";
  result: any;
 
  constructor(private http: HttpClient,private service:ConnectionService) { }

  ngOnInit(): void {
    this.GetEmployeeRequests();
  }
  RespondEmployeeRequest(employeeId:number,responese:boolean){
    this.service.RespondEmployeeRequest(employeeId,responese).subscribe(() => this.GetEmployeeRequests());   

  }
  GetEmployeeRequests(){
    this.service.GetEmployeeRequests()
    .subscribe((data:any) => {
      this.data = data;
      this.totalLength = data.length;
    });
  }

}
