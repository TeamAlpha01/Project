import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { ConnectionService } from 'src/app/Services/connection.service';
import { AuthenticationService } from 'src/app/Services/authentication.service';

@Component({
  selector: 'app-admin-view-requests-page',
  templateUrl: './admin-view-requests-page.component.html',
  styleUrls: ['./admin-view-requests-page.component.css']
})
export class AdminViewRequestsPageComponent implements OnInit {
  data: any[] = [];
  totalLength: any;
  page: number = 1;
  title = "Employee Requests";
  result: any;

  constructor(private http: HttpClient, private service: ConnectionService) { }

  ngOnInit(): void {
    console.log(AuthenticationService.GetData("Admin"))
    this.GetEmployeeRequests();
  }
  //THIS METHOD IS CALLED ON CLICK0F ACCEPT OR REJECT BUTTON
  RespondEmployeeRequest(employeeId: number, response: boolean) {
    this.service.RespondEmployeeRequest(employeeId, response).subscribe(() => this.GetEmployeeRequests());

  }
  //GET METHOD CALLED AT CONNECTION SERVICE
  GetEmployeeRequests() {
    this.service.GetEmployeeRequests()
      .subscribe((data: any) => {
        this.data = data;
        this.totalLength = data.length;
      });
  }

}
