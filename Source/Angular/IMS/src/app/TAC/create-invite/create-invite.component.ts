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
  title = 'Create Invite'
  driveName = '';
  departmentDetails: any;
  error: string = '';
  poolDetails: any;
  locationDetails: any;
  response: string = '';
  minDate: Date = new Date();
  maxDate: Date = new Date();
  toDate: Date = new Date();
  toDateActive: boolean = true;

  _dept = '';
  _pool = '';

  constructor(private connection: ConnectionService, private fb: FormBuilder, private datepipe: DatePipe) { }

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
    return this.CreateInviteForm.get('driveName')
  }
  getFromDate() {
    return this.CreateInviteForm.get('fromDate')
  }
  getToDate() {
    return this.CreateInviteForm.get('toDate')
  }
  getDepartmentId() {
    return this.CreateInviteForm.get('departmentId')
  }
  getPoolId() {
    return this.CreateInviteForm.get('poolId')
  }
  getModeId() {
    return this.CreateInviteForm.get('modeId')
  }
  getLocationId() {
    return this.CreateInviteForm.get('locationId')
  }
  getSlotTiming() {
    return this.CreateInviteForm.get('slotTiming')
  }

  ngOnInit(): void {
    this.GetDepartments();
    this.GetPools();
    this.GetLocation();
    this.minDate.setDate(this.minDate.getDate() + 7);
    this.maxDate.setDate(this.maxDate.getDate() + 31);
  }

  toDateEnabler(date: any) {
    this.toDateActive = false;
    this.CreateInviteForm.controls['toDate'].enable();
    this.toDate = new Date(date);
    this.toDate.setDate(this.toDate.getDate() + 7)
  }

  //GET METHODS CALLED AT CONNECTION SERVICE

  poolEnabler() {
    if (this.getDepartmentId()?.value == '') { this.CreateInviteForm.controls['poolId'].disable() }
    else { this.CreateInviteForm.controls['poolId'].enable() }
  }

  poolName() {
    for (let item of this.poolDetails) {
      if (this.getDepartmentId()?.value == item.departmentId) {
        this._dept = item.departmentName
      }
    }
  }


  locationEnabler() {
    if (this.getModeId()?.value == '1' || '') { { this.CreateInviteForm.controls['locationId'].disable() }; this.CreateInviteForm.controls['locationId'].setValue('9') }
    else { { this.CreateInviteForm.controls['locationId'].enable() } }
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

  CreateInvite() {
    this.submitted = true;
    this.error = '';
    const drive = {
      driveId: 0,
      name: this.getDriveName()?.value,
      fromDate: this.getFromDate()?.value,
      toDate: this.getToDate()?.value,
      departmentId: this.getDepartmentId()?.value,
      poolId: this.getPoolId()?.value,
      modeId: this.getModeId()?.value,
      locationId: this.getLocationId()?.value,
      slotTiming: this.getSlotTiming()?.value,
    }

    if (this.CreateInviteForm.valid) {
      this.connection.CreateDrive(drive).subscribe({
        next: (data) => this.response = data.message,
        error: (error) => { this.error = error.error.message; this.isNameError(error.error.message) },
        complete: () => this.clearInputFields(),
      });
    }
  }

  clearInputFields() {

    this.submitted = false;
    setTimeout(() => {
      this.response = '';
      this.CreateInviteForm.reset();
    }, 1000);

  }

  isNameError(error: string): boolean {
    if (error.toString().includes('Name'))
      return true;
    return false;
  }

}


