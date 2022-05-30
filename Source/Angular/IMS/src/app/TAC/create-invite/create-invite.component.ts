import { Component, OnInit } from '@angular/core';
import { ValidationService } from 'src/app/Services/validation.service';

@Component({
  selector: 'app-create-invite',
  templateUrl: './create-invite.component.html',
  styleUrls: ['./create-invite.component.css']
})
export class CreateInviteComponent implements OnInit {
  title ='Create Invite'
  driveName='';

  constructor(private validation:ValidationService) { }

  ngOnInit(): void {
  }
  ValidateUserName(driveName:any){
    this.validation.ValidateName(driveName);
  }

}
