import { Component, Input, OnInit } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { ConnectionService } from 'src/app/Services/connection.service';

@Component({
  selector: 'app-interviewer-current-drive',
  templateUrl: './interviewer-current-drive.component.html',
  styleUrls: ['./interviewer-current-drive.component.css']
})
export class InterviewerCurrentDriveComponent implements OnInit {

  title = 'Current Drive'
  totalLength: any;
  page: number = 1;
  dept = 'dotnet';
  _pool = '';
  pool: any[] = [];
  drive: any[] = [];
  interviwerpoolDetails :any;
  constructor(private connection :ConnectionService) { }

  ngOnInit(): void {
    this.connection.GetPools().subscribe((data: any) => {
      this.interviwerpoolDetails = data;
  })
    for (let item of this.driveDetails) {
      this.drive.push(item);
    }
  }


  filterDropdown() {

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






  department: any[] = [{
    departmentId: '1',
    departmentName: 'dotnet'
  }]

  poolDetails: any[] = [{
    departmentId: '1',
    poolName: 'Fresher'
  },
  {
    departmentId: '1',
    poolName: 'Fresher 1'
  }, 
  {
    departmentId: '1',
    poolName: 'Fresher 2'
  },
  {
    departmentId: '1',
    poolName: 'Fresher 3'
  },]





  driveDetails: any[] = [{
    name: 'freshers 2021',
    department: 'dotnet',
    poolName: 'Fresher 1',
    date: '2022-04-12',
    fromTime: '4.00',
    toTime: '5.00',
    mode: 'offline',
    location: 'chennai'
  }, {
    name: 'freshers 2022',
    department: 'dotnet',
    poolName: 'Fresher 2',
    fromTime: '4.00',
    toTime: '5.00',
    date: '2022-04-12',
    mode: 'online',
    location: ''
  }, {
    name: 'freshers 2022',
    department: 'dotnet',
    poolName: 'Fresher 3',
    fromTime: '4.00',
    toTime: '5.00',
    date: '2022-04-12',
    mode: 'online',
    location: ''
  }, {
    name: 'freshers 2021',
    department: 'dotnet',
    poolName: 'Fresher 2',
    fromTime: '4.00',
    toTime: '5.00',
    date: '2022-04-12',
    mode: 'offline',
    location: 'chennai'
  }, {
    name: 'freshers 2022',
    department: 'dotnet',
    poolName: 'Fresher 1',
    fromTime: '4.00',
    toTime: '5.00',
    date: '2022-04-12',
    mode: 'online',
    location: ''
  }, {
    name: 'freshers 2022',
    department: 'dotnet',
    poolName: 'Fresher',
    fromTime: '4.00',
    toTime: '5.00',
    date: '2022-04-12',
    mode: 'online',
    location: ''
  }]
}
