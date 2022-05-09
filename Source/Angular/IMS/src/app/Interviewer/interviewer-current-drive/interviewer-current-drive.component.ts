import { Component, Input, OnInit } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-interviewer-current-drive',
  templateUrl: './interviewer-current-drive.component.html',
  styleUrls: ['./interviewer-current-drive.component.css']
})
export class InterviewerCurrentDriveComponent implements OnInit {

  title = 'Current Drive'
  totalLength: any;
  page: number = 1;
  dept = '';
  _pool = '';
  pool: any[] = [];
  drive: any[] = [];
  constructor(private http: HttpClient) { }

  ngOnInit(): void {

    // this.http
    //   .get<any>('https://localhost:7072/Drive/ViewTodayDrives')
    //   .subscribe((data) => {
    //     this.drive = data;
    //     this.totalLength = data.length;
    //   });
    for (let item of this.driveDetails) {
      this.drive.push(item);
    }
  }


  filterDropdown() {

    //To filter pool based on the department
    this.pool = [];
    for (let item of this.poolDetails) {
      if (item.departmentName == this.dept) {
        this.pool.push(item);
      }
    }

    //To filter cards based on the department and pool selection
    this.drive = [];
    for (let item of this.driveDetails) {
      if (this.dept == '') {
        this._pool = '';
      }
      else if (this.dept == '' && this._pool == '') {
        this.drive.push(item);
      }
      else if (item.department == this.dept && item.poolName == this._pool) {
        this.drive.push(item);
      }
      else if (item.department == this.dept && this._pool == '') {
        this.drive.push(item);
      }
      else if (item.department == this.dept && item.poolName != this._pool) {
      }

    }

  }


  // filterButton(){
  //   console.log(this.dept)
  //   console.log(this._pool)
  //   this.drive=[];
  //   for(let item of this.driveDetails){
  //     if(item.department==this.dept && item.poolName==this._pool){
  //       this.drive.push(item);
  //       console.log("true");
  //     }
  //   }
  // }



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
    date: '2022-04-12',
    mode: 'offline',
    location: 'chennai'
  }, {
    name: 'freshers 2022',
    department: 'java',
    poolName: 'Technical Lead',
    date: '2022-04-12',
    mode: 'online',
    location: ''
  }, {
    name: 'freshers 2022',
    department: 'java',
    poolName: 'Technical Lead',
    date: '2022-04-12',
    mode: 'online',
    location: ''
  }, {
    name: 'freshers 2021',
    department: 'dotnet',
    poolName: 'Fresher 2',
    date: '2022-04-12',
    mode: 'offline',
    location: 'chennai'
  }, {
    name: 'freshers 2022',
    department: 'java',
    poolName: 'Technical Lead',
    date: '2022-04-12',
    mode: 'online',
    location: ''
  }, {
    name: 'freshers 2022',
    department: 'java',
    poolName: 'Technical Lead',
    date: '2022-04-12',
    mode: 'online',
    location: ''
  }]
}
