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
  response: string = '';
  error: string = '';
  submitted: boolean = false;

  constructor(private service: ConnectionService, private fb: FormBuilder) {}

  AddLocationForm = this.fb.group({
    locationName: [
      '',
      [
        Validators.required,
        Validators.minLength(3),
        Validators.pattern('[A-Za-z\\s]*'),
      ],
    ],
  });

  getLocationName() {
    return this.AddLocationForm.get('locationName');
  }

  ngOnInit(): void {}


  addLocation() 
  {
    this.submitted = true;
    this.error = '';

    if (this.AddLocationForm.valid)
     {
      this.service.AddLocation(this.getLocationName()?.value).subscribe({
        next: (data) => this.response = data.message,
        error: (error) => this.error = error.error.message,
        complete: () => this.clearInputFields(),
      });
    }

  }
  
  clearInputFields() 
  {
    
      this.submitted = false;
      setTimeout(() => {
        this.response = '';
        this.AddLocationForm.reset();
      }, 2000);
    
  }
}
