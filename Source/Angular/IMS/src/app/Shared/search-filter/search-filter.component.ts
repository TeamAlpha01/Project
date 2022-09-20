import { Component, OnInit, Output } from '@angular/core';
import { ConnectionService } from 'src/app/Services/connection.service';

@Component({
  selector: 'app-search-filter',
  templateUrl: './search-filter.component.html',
  styleUrls: ['./search-filter.component.css']
})
export class SearchFilterComponent implements OnInit {
@Output() 


  _dept = '';
  _pool = '';


  //TO STORE THE DATA FROM THE DATABASE
  poolDetails: any;
  departmentDetails: any;


  constructor(private connection: ConnectionService) { }

  ngOnInit(): void {
    this.GetPools();
    this.GetDepartments();
  }

  GetPools() {
    this.connection.GetPools().subscribe({
      next: (data: any) => (this.poolDetails = data),
    });
  }

  GetDepartments() {
    this.connection.GetDepartments().subscribe({
      next: (data: any) => (this.departmentDetails = data),
    });
  }


  OnDepartmentChange() {
    this._pool = '';

  }




}
