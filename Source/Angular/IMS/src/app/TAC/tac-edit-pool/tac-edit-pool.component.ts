import { Component, OnInit } from '@angular/core';
import { ConnectionService } from 'src/app/Services/connection.service';

@Component({
  selector: 'app-tac-edit-pool',
  templateUrl: './tac-edit-pool.component.html',
  styleUrls: ['./tac-edit-pool.component.css']
})
export class TacEditPoolComponent implements OnInit {
  title = 'Edit Pool'

  poolDetails: any;
  departmentDetails: any;
  _dept = ''; 
  _pool = '';
  constructor(private connection: ConnectionService) { }

  ngOnInit(): void {
    this.connection.GetPools().subscribe((data: any) => {
      this.poolDetails = data;
    })
    this.connection.GetDepartments().subscribe((data: any) => {
      this.departmentDetails = data;
    })
  }

}
