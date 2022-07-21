import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ConnectionService } from 'src/app/Services/connection.service';
import { DatePipe } from '@angular/common'

@Component({
  selector: 'app-create-invite',
  templateUrl: './create-invite.component.html',
  styleUrls: ['./create-invite.component.css']
})
export class CreateInviteComponent implements OnInit {

  title = 'Create Invite';  //This gives the title of the page

  //To store the HTTP responses
  response: string = '';
  error: string = '';

  //To store the data receives from server 
  departmentDetails: any;
  poolDetails: any;
  locationDetails: any;

  //Declaractions
  minDate: Date = new Date();
  maxDate: Date = new Date();
  toDate: Date = new Date();
  toDateActive: boolean = true;

  //To get the user input 
  _dept = '';

  constructor(private connection: ConnectionService, private fb: FormBuilder) { }

  submitted: boolean = false;

  CreateInviteForm = this.fb.group({
    driveName: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(25), Validators.pattern('[A-Za-z.0-9\\s]*')]],
    fromDate: ['', [Validators.required]],
    toDate: [{ value: '', disabled: true }, [Validators.required]],
    departmentId: ['', [Validators.required]],
    poolId: [{ value: '', disabled: true }, [Validators.required]],
    modeId: ['', [Validators.required]],
    locationId: [{ value: '', disabled: true }, [Validators.required]],
    slotTiming: ['', [Validators.required]],
  });

  getDriveName() {
    return this.CreateInviteForm.get('driveName')?.value;
  }
  getFromDate() {
    return this.CreateInviteForm.get('fromDate')?.value;
  }
  getToDate() {
    return this.CreateInviteForm.get('toDate')?.value;
  }
  getDepartmentId() {
    return this.CreateInviteForm.get('departmentId')?.value;
  }
  getPoolId() {
    return this.CreateInviteForm.get('poolId')?.value;
  }
  getModeId() {
    return this.CreateInviteForm.get('modeId')?.value;
  }
  getLocationId() {
    return this.CreateInviteForm.get('locationId')?.value;
  }
  getSlotTiming() {
    return this.CreateInviteForm.get('slotTiming')?.value;
  }

  resetForm() {
    this.CreateInviteForm.controls['driveName'].setValue('')
    this.CreateInviteForm.controls['fromDate'].setValue('')
    this.CreateInviteForm.controls['toDate'].setValue('')
    this.CreateInviteForm.controls['departmentId'].setValue('')
    this.CreateInviteForm.controls['poolId'].setValue('')
    this.CreateInviteForm.controls['modeId'].setValue('')
    this.CreateInviteForm.controls['locationId'].setValue('')
    this.CreateInviteForm.controls['slotTiming'].setValue('')
  }


  ngOnInit(): void {
    this.GetDepartments();
    this.GetPools();
    this.GetLocation();
    this.minDate.setDate(this.minDate.getDate() + 7);
    this.maxDate.setDate(this.maxDate.getDate() + 31);
  }

  GetDepartments() {
    this.connection.GetDepartments().subscribe((data: any) => {
      this.departmentDetails = data;
    })
  }

  GetPools() {
    this.connection.GetPools().subscribe((data: any) => {
      this.poolDetails = data;
    })
  }

  GetLocation() {
    this.connection.GetLocations().subscribe((data: any) => {
      this.locationDetails = data;
    })
  }

  //To enable to date field
  toDateEnabler(date: any) {
    this.toDateActive = false;
    this.CreateInviteForm.controls['toDate'].enable();
    this.toDate = new Date(date);
    this.toDate.setDate(this.toDate.getDate() + 7)
  }

  //To enable pool field
  poolEnabler() {
    this.CreateInviteForm.controls['poolId'].setValue('')
    if (this.getDepartmentId() == '') { this.CreateInviteForm.controls['poolId'].disable() }
    else { this.CreateInviteForm.controls['poolId'].enable() }
  }

  //For pool filteration 
  poolName() {
    for (let item of this.poolDetails) {
      if (this.getDepartmentId() == item.departmentId) {
        this._dept = item.departmentName
      }
    }
  }

  //To enable location field when mode is offline
  locationEnabler() {
    this.CreateInviteForm.controls['locationId'].setValue('')
    if (this.getModeId() == '1') {
      this.CreateInviteForm.controls['locationId'].disable();
      for (let item of this.locationDetails) {
        if (item.locationName == 'Online') {
          this.CreateInviteForm.controls['locationId'].setValue(item.locationId) //If mode is online setting the location to Online
        }
      }
    }
    else {
      {
        this.CreateInviteForm.controls['locationId'].enable();
        this.CreateInviteForm.controls['locationId'].setValue('')
      }
    }
  }



  CreateInvite() {
    this.submitted = true;
    this.error = '';

    const drive = {
      driveId: 0,
      name: this.getDriveName(),
      fromDate: this.getFromDate(),
      toDate: this.getToDate(),
      departmentId: this.getDepartmentId(),
      poolId: this.getPoolId(),
      modeId: this.getModeId(),
      locationId: this.getLocationId(),
      slotTiming: this.getSlotTiming(),
    }

    //This function post the data to Server
    if (this.CreateInviteForm.valid) {
      this.connection.CreateDrive(drive).subscribe({
        next: (data) => this.response = data.message,
        error: (error) => this.error = error.error.message,
        complete: () => this.clearInputFields(),
      });
    }
  }

  //This methods clears the input field and activates snackbar
  clearInputFields() {
    this.submitted = false;
    setTimeout(() => {
      this.response = '';
      this.CreateInviteForm.reset();
    }, 1000);
  }
}


