import { Component, OnInit } from '@angular/core';
import { ConnectionService } from 'src/app/Services/connection.service';
import { DialogueBoxService } from 'src/app/Services/dialogue-box.service';

@Component({
  selector: 'app-admin-add-location-page',
  templateUrl: './admin-viewLocation-page.component.html',
  styleUrls: ['./admin-viewLocation-page.component.css'],
})

export class AdminviewLocationPageComponent implements OnInit {
  title = 'Locations';
  
  //TO GET USER INPUT
  location: any;
  
  //PAGINATION
  totalLength: any;
  page: number = 1;

  constructor(private service: ConnectionService,private dialogueService:DialogueBoxService) {}

  ngOnInit(): void {
    this.GetLocations();
  }
  async removeLocation(locationId: number, locationName:string) {

    const location={
      locationId:locationId,
      locationName:locationName
    }
  
    await this.dialogueService.IsDeleteConfirmed().then((value)=> {

      if(value)
      this.service.RemoveLocation(location).subscribe(() => this.GetLocations());
    
    });
  }

  //GET METHOD CALLED AT CONNECTION SERVICE
  GetLocations() {
    this.service.GetLocations().subscribe((data: any) => {
      this.location = data;
      this.totalLength = data.length;
    });
  }
}
