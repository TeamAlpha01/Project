import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { ConnectionService } from 'src/app/Services/connection.service';
import { AuthenticationService } from 'src/app/Services/authentication.service';
import { DialogueBoxService } from 'src/app/Services/dialogue-box.service';

@Component({
  selector: 'app-admin-view-requests-page',
  templateUrl: './admin-view-requests-page.component.html',
  styleUrls: ['./admin-view-requests-page.component.css']
})
export class AdminViewRequestsPageComponent implements OnInit {
  data: any[] = [];
  totalLength: any;
  page: number = 1;
  error: string = '';
  response: string = '';
  title = "Employee Requests";
  result: any;

  constructor(private service: ConnectionService, private dialogueService: DialogueBoxService) { }

  ngOnInit(): void {
    this.GetEmployeeRequests();
  }
  //THIS METHOD IS CALLED ON CLICK0F ACCEPT OR REJECT BUTTON
  async RespondEmployeeRequest(employeeId: number, response: boolean) {
    if (response == false)
      await this.dialogueService.IsDeleteConfirmed().then((value) => {
        if (value)
          this.service.RespondEmployeeRequest(employeeId, response).subscribe({
            next: (data) => { this.response = data.message },
            error: (error) => { this.error = error.error, this.snackBar() },
            complete: () => { this.snackBar(), this.GetEmployeeRequests() }
          })
      });
    else {
      this.service.RespondEmployeeRequest(employeeId, response).subscribe({
        next: (data) => { this.response = data.message },
        error: (error) => { this.error = error.error, this.snackBar() },
        complete: () => { this.snackBar(), this.GetEmployeeRequests() }
      })
    }
  }
  //GET METHOD CALLED AT CONNECTION SERVICE
  GetEmployeeRequests() {
    this.service.GetEmployeeRequests()
      .subscribe((data: any) => {
        this.data = data;
        this.totalLength = data.length;
      });
  }
  snackBar() {
    setTimeout(() => {
      this.response = '';
      //this.error = '';
    }, 2000);
  }

}
