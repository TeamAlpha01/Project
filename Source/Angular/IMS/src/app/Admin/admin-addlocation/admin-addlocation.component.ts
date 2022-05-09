import { Component, OnInit } from '@angular/core';
import { Location } from 'src/app/Model/Location';
import { HttpClient,HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-admin-addlocation',
  templateUrl: './admin-addlocation.component.html',
  styleUrls: ['./admin-addlocation.component.css']
})
export class AdminAddlocationComponent implements OnInit {
  title ='Location'
 location: Location={
   locationName:'',
 }
  constructor(private http: HttpClient) { }
  addLocation(){
    console.log(this.location)
  }
  ngOnInit(): void {
  }
  pageTitle="Department"

}
