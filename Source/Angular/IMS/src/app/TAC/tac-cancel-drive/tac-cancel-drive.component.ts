import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { data } from 'jquery';
import { Observable } from 'rxjs';
import { ConnectionService } from 'src/app/Services/connection.service';

@Component({
  selector: 'app-tac-cancel-drive',
  templateUrl: './tac-cancel-drive.component.html',
  styleUrls: ['./tac-cancel-drive.component.css']
})
export class TacCancelDriveComponent implements OnInit {
  title = 'Cancel Drive';
  driveId: number = 0;
  driveDetails: any;
  Reason = '';
  errorMessage: string = '';
  data: any;
  error: string = '';
  submitted: boolean = false;
  response: string='';


  constructor(private route: ActivatedRoute, private connection: ConnectionService, private fb: FormBuilder, private router: Router) { }

  CancelDriveForm = this.fb.group({
    cancelReason: ['', [Validators.required, Validators.minLength(5)]],
  });

  getCancelReason() {
    return this.CancelDriveForm.get('cancelReason')
  }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.driveId = params['driveId']
    })

    this.connection.GetDrive(this.driveId).subscribe({
      next: (data: any) => this.driveDetails = data,
      error: (errorMessage: any) => this.errorMessage = errorMessage.message
    });

  }

  CancelDrive() {
      this.submitted = true;
      this.error = '';
      if (this.CancelDriveForm.valid) {
        console.log(this.getCancelReason()?.value)
        this.connection.CancelDrive(this.driveId, this.getCancelReason()?.value).subscribe({
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
          this.router.navigateByUrl("tac/home");
        }, 2000);
      
    }
}
