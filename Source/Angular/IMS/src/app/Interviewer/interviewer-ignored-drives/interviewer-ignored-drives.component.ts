import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ConnectionService } from 'src/app/Services/connection.service';

@Component({
  selector: 'app-interviewer-ignored-drives',
  templateUrl: './interviewer-ignored-drives.component.html',
  styleUrls: ['./interviewer-ignored-drives.component.css']
})
export class InterviewerIgnoredDrivesComponent implements OnInit {

  title='Ignored Drives';
  Ignored: any;
  totalLength: any;
  page: number = 1;

  _pool = '';
  _date = '';

  //To store the filtered data in the array
  pool: any[] = [];
  drive: any[] = [];

  //To get the details from the db
  driveDetails: any;
  poolDetails: any;

  date = {
    From: '',
    To: ''
  }

  constructor(private connection :ConnectionService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.date.From = params['fromDate']   //This methods gets the data from the query string
      this.date.To = params['toDate']
    })
    this.GetIgnoredDrives();
    this.GetPoolsbyId();
  }

  GetIgnoredDrives(){
    this.connection.GetIgnoredDrives(this.date).subscribe((data: any) => {
      this.Ignored = data;
      this.drive=data;
    }) 
  }

  GetPoolsbyId(){
    this.connection.GetPoolsbyId().subscribe((data: any) => {
      this.poolDetails = data;
    })
  }
  
  filterDropdown() {
  
    this.drive = [];
  
    for (let item of this.Ignored) {
      if ( this._pool == '' && item.fromDate <= this._date && this._date <= item.toDate) {
        this.drive.push(item);
      }
      else if (item.drivePool == this._pool && item.fromDate <= this._date && this._date <= item.toDate) {
        this.drive.push(item);
      }
      else if (this._pool == '' && this._date == '') {
        this.drive.push(item);
      }
      else if (item.drivePool == this._pool && this._date == '') {
        this.drive.push(item);
      }
    }
  }

}
