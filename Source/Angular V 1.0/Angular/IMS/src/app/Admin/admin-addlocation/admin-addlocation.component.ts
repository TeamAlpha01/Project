import { Component, OnInit } from '@angular/core';
import { ConnectionService } from 'src/app/Services/connection.service';
import { FormBuilder, Validators } from '@angular/forms';
import { Location } from '@angular/common';

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

  constructor(private service: ConnectionService, private fb: FormBuilder, private location: Location) { }

  AddLocationForm = this.fb.group({
    //VALIDATE THE INPUT

    locationName: [
      '',
      [
        Validators.required,
        Validators.minLength(3),
        Validators.maxLength(25),
        Validators.pattern("^(?!.*([ ])\\1)(?!.*([A-Za-z])\\2{2})\\w[a-zA-Z\\s]*$"),
      ],
    ],
  });

  getLocationName() {
    return this.AddLocationForm.get('locationName');
  }

  ngOnInit(): void { }


  addLocation() {
    this.submitted = true;
    this.error = '';
    const location={
      locationId:0,
      locationName:this.getLocationName()?.value
    }

    if (this.AddLocationForm.valid) {
      this.service.AddLocation(location).subscribe({
        next: (data) => this.response = data.message,
        error: (error) => this.error = error.error.message,
        complete: () => this.clearInputFields(),
      });
    }

  }

  clearInputFields() {

    this.submitted = false;
    setTimeout(() => {
      this.response = '';
      this.AddLocationForm.reset();
    }, 2000);

  }


}
