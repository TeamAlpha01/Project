import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-tac-scheduled-drive',
  templateUrl: './tac-scheduled-drive.component.html',
  styleUrls: ['./tac-scheduled-drive.component.css']
})
export class TacScheduledDriveComponent implements OnInit {

  title = 'Current Drive'
  totalLength: any;
  page: number = 1;
  _dept = '';
  _pool = '';
  _date = '';
  pool: any[] = [];
  drive: any[] = [];
  constructor(private http: HttpClient) { }

  ngOnInit(): void {

    this.http
      .get<any>('https://localhost:7072/Drive/ViewTodayDrives')
      .subscribe((data) => {
        this.drive = data;
        this.totalLength = data.length;
      });
      
    for (let item of this.driveDetails) {
      this.drive.push(item);
    }
  }


  filterDropdown() {


    //To filter pool based on the department
    this.pool = [];
    for (let item of this.poolDetails) {
      if (item.departmentName == this._dept) {
        this.pool.push(item);
      }
    }

    //To filter cards based on the department and pool selection
    this.drive = [];
    for (let item of this.driveDetails) {
      if (this._dept == '' && this._pool == '' && item.date==this._date) {
        this.drive.push(item);
        console.log("0")
      }
      else if (this._dept == '' && this._date==item.date) {
        this._pool = '';
        this.drive.push(item);
        console.log("true")
      }
      else if (this._dept == '' && this._date=='') {
        this._pool = '';
        this.drive.push(item);
        console.log("false")
      }
      else if (this._dept == '' && this._pool == '' && this._date == '') {
        this.drive.push(item);
        console.log("1")
      }
      
      else if (item.department == this._dept && item.poolName == this._pool && this._date=='') {
        this.drive.push(item);
        console.log("2")
      }
      else if (item.department == this._dept && item.poolName == this._pool && item.date==this._date) {
        this.drive.push(item);
        console.log("3")
      }
      else if (item.department == this._dept && this._pool == '' && this._date == '') {
        this.drive.push(item);
        console.log("4")
      }
      else if (item.department == this._dept && this._pool == '' && this._date == item.date) {
        this.drive.push(item);
        console.log("5")
      }
       else if (item.department == this._dept && item.poolName != this._pool ) {
       }

    }

  }






  department: string[] = ['dotnet', 'java', 'lamp']

  poolDetails: any[] = [{
    departmentName: 'dotnet',
    poolName: 'Fresher 1'
  },
  {
    departmentName: 'java',
    poolName: 'Fresher 1'
  }, {
    departmentName: 'dotnet',
    poolName: 'Fresher 2'
  },
  {
    departmentName: 'java',
    poolName: 'Fresher 3'
  }]





  driveDetails: any[] = [{
    name: 'freshers 2021',
    department: 'dotnet',
    poolName: 'Fresher 1',
    date: '2022-04-11',
    mode: 'offline',
    location: 'chennai'
  },
  {
    name: 'freshers 2022',
    department: 'java',
    poolName: 'Technical Lead',
    date: '2022-04-12',
    mode: 'online',
    location: ''
  },
  {
    name: 'freshers 2022',
    department: 'java',
    poolName: 'Technical Lead',
    date: '2022-04-13',
    mode: 'online',
    location: ''
  },
  {
    name: 'freshers 2021',
    department: 'dotnet',
    poolName: 'Fresher 2',
    date: '2022-04-12',
    mode: 'offline',
    location: 'chennai'
  },
  {
    name: 'freshers 2022',
    department: 'java',
    poolName: 'Technical Lead',
    date: '2022-04-12',
    mode: 'online',
    location: ''
  },
  {
    name: 'freshers 2022',
    department: 'java',
    poolName: 'Technical Lead',
    date: '2022-04-12',
    mode: 'online',
    location: ''
  }]
}


