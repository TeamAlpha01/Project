import { Component, Input, OnInit } from '@angular/core';
import { ConnectionService } from 'src/app/Services/connection.service';


@Component({
  selector: 'app-tac-profile',
  templateUrl: './tac-profile.component.html',
  styleUrls: ['./tac-profile.component.css']
})
export class TacProfileComponent implements OnInit {
  title = 'Profile';
  data: any;
  profileDetails: any;



  constructor(private connection: ConnectionService) { }

  ngOnInit():void{
    this.connection.GetEmployeeProfile().subscribe((data: any) => {
      console.warn(data)
    })    

  }

}
