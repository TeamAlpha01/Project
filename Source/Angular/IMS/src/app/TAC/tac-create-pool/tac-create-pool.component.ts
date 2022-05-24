import { Component, OnInit } from '@angular/core';
import { ConnectionService } from 'src/app/Services/connection.service';

@Component({
  selector: 'app-tac-create-pool',
  templateUrl: './tac-create-pool.component.html',
  styleUrls: ['./tac-create-pool.component.css']
})
export class TacCreatePoolComponent implements OnInit {
  
  title ='Create pool';
  _dept = ''; 
  departmentDetails: any;



  constructor(private connection: ConnectionService) { }

  ngOnInit(): void {
    this.connection.GetDepartments().subscribe((data: any) => {
      this.departmentDetails = data;
    })
  }

}
