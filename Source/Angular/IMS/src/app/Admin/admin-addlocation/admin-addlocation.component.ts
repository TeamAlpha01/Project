import { data } from 'jquery';
import { Component, OnInit } from '@angular/core';
import { Location } from 'src/app/Model/Location';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { ConnectionService } from 'src/app/Services/connection.service';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-admin-addlocation',
  templateUrl: './admin-addlocation.component.html',
  styleUrls: ['./admin-addlocation.component.css'],
})
export class AdminAddlocationComponent implements OnInit {
  title = 'Add Location';
  response:string = '';

  constructor(private service: ConnectionService,private fb : FormBuilder) {}

  AddLocationForm = this.fb.group(
    {
      locationName:['',[Validators.required,Validators.minLength(3),Validators.pattern('[A-Za-z\\s]*')]]
    }
  );

  getLocationName(){
    return this.AddLocationForm.get('locationName');
  }
  ngOnInit(): void {}
  pageTitle = 'Department';

  addLocation() 
  {
    if(this.getLocationName()?.valid)
    {
      this.service.AddLocation(this.getLocationName()?.value).subscribe((data)=> this.response=data.message);
    }
  }
}
