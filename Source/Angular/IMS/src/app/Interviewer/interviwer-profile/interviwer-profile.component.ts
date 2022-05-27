import { Component, OnInit } from '@angular/core';
import { ConnectionService } from 'src/app/Services/connection.service';

@Component({
  selector: 'app-interviwer-profile',
  templateUrl: './interviwer-profile.component.html',
  styleUrls: ['./interviwer-profile.component.css']
})
export class InterviwerProfileComponent implements OnInit {
  title ='My Profile'
  profileDetails:any;
  data :any;
  constructor(private connection :ConnectionService) { }

  ngOnInit(): void {
    this.connection.GetProfile().subscribe((data: any) => {
      this.profileDetails = data;
    }) 
  }

}
