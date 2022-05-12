import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-tac-scheduled-drive',
  templateUrl: './tac-scheduled-drive.component.html',
  styleUrls: ['./tac-scheduled-drive.component.css']
})
export class TacScheduledDriveComponent implements OnInit {

  title = 'Scheduled Drive'
  totalLength: any;
  page: number = 1;
  _dept = '';
  _pool = '';
  _date='';

  pool: any[] = [];
  drive: any[] = [];

  driveDetails: any;
  poolDetails: any;
  departmentDetails: any;
  deptId: any;
  constructor(private http: HttpClient) { }

  ngOnInit(): void {

    this.http
      .get<any>('https://localhost:7072/Drive/ViewScheduledDrives')
      .subscribe((data) => {
        this.driveDetails = data;
        this.drive = data;
        console.log(this.driveDetails)
      });

    this.http
      .get<any>('https://localhost:7072/Pool/ViewPools')
      .subscribe((data) => {
        this.poolDetails = data;
        console.log(this.poolDetails)
      });

    this.http
      .get<any>('https://localhost:7072/Deparment/ViewDepartments')
      .subscribe((data) => {
        this.departmentDetails = data;
        console.log(this.departmentDetails)
      });
    
  }


  filterDropdown() {


    //To filter pool based on the department
    this.pool = [];

    if (this._dept == '') {
      this._pool = ''
    }

    for (let item of this.departmentDetails) {
      if (item.departmentName == this._dept) {
        this.deptId = item.departmentId;
      }
    }

    for (let item of this.poolDetails) {
      if (item.departmentId == this.deptId) {
        this.pool.push(item);
      }
    }

    //To filter cards based on the department and pool selection
    this.drive = [];
    for (let item of this.driveDetails) {
      console.log(item.fromDate)
      console.warn(this._date)
      if (this._dept == '' && this._pool == '' && item.fromDate==this._date) {
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






  // department: string[] = ['dotnet', 'java', 'lamp']

  // poolDetails: any[] = [{
  //   departmentName: 'dotnet',
  //   poolName: 'Fresher 1'
  // },
  // {
  //   departmentName: 'java',
  //   poolName: 'Fresher 1'
  // }, {
  //   departmentName: 'dotnet',
  //   poolName: 'Fresher 2'
  // },
  // {
  //   departmentName: 'java',
  //   poolName: 'Fresher 3'
  // }]





  // driveDetails: any[] = [{
  //   name: 'freshers 2021',
  //   department: 'dotnet',
  //   poolName: 'Fresher 1',
  //   date: '2022-04-11',
  //   mode: 'offline',
  //   location: 'chennai'
  // },
  // {
  //   name: 'freshers 2022',
  //   department: 'java',
  //   poolName: 'Technical Lead',
  //   date: '2022-04-12',
  //   mode: 'online',
  //   location: ''
  // },
  // {
  //   name: 'freshers 2022',
  //   department: 'java',
  //   poolName: 'Technical Lead',
  //   date: '2022-04-13',
  //   mode: 'online',
  //   location: ''
  // },
  // {
  //   name: 'freshers 2021',
  //   department: 'dotnet',
  //   poolName: 'Fresher 2',
  //   date: '2022-04-12',
  //   mode: 'offline',
  //   location: 'chennai'
  // },
  // {
  //   name: 'freshers 2022',
  //   department: 'java',
  //   poolName: 'Technical Lead',
  //   date: '2022-04-12',
  //   mode: 'online',
  //   location: ''
  // },
  // {
  //   name: 'freshers 2022',
  //   department: 'java',
  //   poolName: 'Technical Lead',
  //   date: '2022-04-12',
  //   mode: 'online',
  //   location: ''
  // }]
}


