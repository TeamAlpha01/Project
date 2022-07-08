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

  //TO STORE THE DATA FROM THE DATABASE
  poolDetails: any;
  departmentDetails: any;

  //TO GET USER INPUT
  _dept = '';
  _pool = '';

  //PAGINATION
  page: number = 1;
  totalLength: any;

  //HTTP RESPONSE
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
    await this.dialogueService.IsDeleteConfirmed().then((value) => {
      if (value)
        this.connection.RemovePool(poolId).subscribe({
          next: (data) => { this.response = data.message, this.GetPools() },
          error: (error) => { this.error = error.error, this.snackBar() },
          complete: () => this.snackBar(),
        });
    });
  }

  snackBar() {
    setTimeout(() => {
      this.error = '';
      this.response = '';
    }, 2000);
  }
}
