import { Component, OnInit } from '@angular/core';
import { ConnectionService } from 'src/app/Services/connection.service';
import { DialogueBoxService } from 'src/app/Services/dialogue-box.service';

@Component({
  selector: 'app-managepool',
  templateUrl: './managepool.component.html',
  styleUrls: ['./managepool.component.css']
})

export class ManagepoolComponent implements OnInit {
  title = 'Manage Pool'

  //To store the data receives from server 
  poolDetails: any[] = [];
  departmentDetails: any;

  //To get the user input
  _dept = '';
  _pool = '';

  //Pagination
  page: number = 1;
  totalLength: any;

  //To store the HTTP responses
  error: string = '';
  response: string = '';

  constructor(private connection: ConnectionService, private dialogueService: DialogueBoxService) { }

  ngOnInit(): void {
    this.GetPools();
    this.GetDepartments();
  }

  GetPools() {
    this.connection.GetPools().subscribe({
      next: (data: any) => this.poolDetails = data,
      error: (error: any) => this.error = error.error.message
    })
  }

  GetDepartments() {
    this.connection.GetDepartments().subscribe({
      next: (data: any) => this.departmentDetails = data,
      error: (error: any) => this.error = error.error.message
    })
  }

  async RemovePool(poolId: number) {
    await this.dialogueService.IsDeleteConfirmed().then((value) => { // This function triggers the dialogue box
      if (value)
        this.connection.RemovePool(poolId).subscribe({
          next: (data) => { this.response = data.message, this.GetPools() },
          error: (error) => { this.error = error.error, this.snackBar() },
          complete: () => this.snackBar(),
        });
    });
  }

  //This method triggers the snackbar
  snackBar() {
    setTimeout(() => {
      this.error = '';
      this.response = '';
    }, 2000);
  }
}
