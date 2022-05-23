import { Component, OnInit } from '@angular/core';
import { Location } from 'src/app/Model/Location';
import { HttpClient,HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-admin-addlocation',
  templateUrl: './admin-addlocation.component.html',
  styleUrls: ['./admin-addlocation.component.css']
})
export class AdminAddlocationComponent implements OnInit {
  title ='Add Location'
 
  constructor(private http: HttpClient) { }

    _locationName='' 

  addLocation(){
    const headers = {'content-type':'application/json'}
  
    this.http.post<any>(`https://localhost:7072/Location/CreateNewLocation?locationName=${this._locationName}`,this._locationName)
        .subscribe((data) => {
          console.log(data)
        }
        )
  }

  ngOnInit(): void {
  }
  pageTitle="Department"

  RemoveLocation(locationId:number){

    console.warn("Location Id :" +locationId)
    if(confirm("Do you want to remove the Location?")==true){
    this.http
    .delete(`https://localhost:7072/Location/RemoveLocation?LocationId=${locationId}`)  
    .subscribe((data)=>{
      console.log(data);
    });
  }
}
}
