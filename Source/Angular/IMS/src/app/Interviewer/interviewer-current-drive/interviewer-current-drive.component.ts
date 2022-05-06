import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-interviewer-current-drive',
  templateUrl: './interviewer-current-drive.component.html',
  styleUrls: ['./interviewer-current-drive.component.css']
})
export class InterviewerCurrentDriveComponent implements OnInit {

  // drive: any;
  totalLength: any;
  page: number = 1;
  dept='';
  _pool='';
  pool: any[]=[];
  drive:any[]=[];
  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    
    // this.http
    //   .get<any>('https://localhost:7072/Drive/ViewTodayDrives')
    //   .subscribe((data) => {
    //     this.drive = data;
    //     this.totalLength = data.length;
    //   });
  }
  

  filterDropdown(){
    this.pool=[];
    for(let item of this.poolDetails){
      if(item.departmentName==this.dept)
      {       
        this.pool.push(item);  
      }     
    }
  }

  filterButton(){
    console.log(this.dept)
    console.log(this._pool)
    this.drive=[];
    for(let item of this.driveDetails){
      if(item.department==this.dept && item.poolName==this._pool){
        this.drive.push(item);
        console.log("true");
      }
      else if(item.department==this.dept && item.poolName=='any'){
        this.drive.push(item);
        console.log("false");
      }
      else if(item.department=='any' && item.poolName==this._pool){
        this.drive.push(item);
        console.log("null");
      }
      
    }
  }


  
  department: string[] = ['dotnet', 'java', 'lamp']

  poolDetails: any[] = [{
    departmentName: 'dotnet',
    poolName: 'Fresher'
  },
  {
    departmentName: 'java',
    poolName: 'Fresher 1'
  },{
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
    poolName: 'Fresher',
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
    poolName: 'Fresher',
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
