import { DialogueBoxService } from './../../Services/dialogue-box.service';
import { Component, OnInit } from '@angular/core';
import { ConnectionService } from 'src/app/Services/connection.service';

@Component({
  selector: 'app-admin-view-department-page',
  templateUrl: './admin-view-Department-page.component.html',
  styleUrls: ['./admin-view-department-page.component.css'],
})

export class AdminviewDepartmentPageComponent implements OnInit {
  title = 'Departments';
  
  //TO GET DATA FROM DATABASE
  department: any;
  
  //PAGNATION
  totalLength: any;
  page: number = 1;
  
  constructor(private service: ConnectionService,private dialogueService:DialogueBoxService) {}

  ngOnInit(): void {
    this.GetDepartments();
  }

  async removeDepartment(departmentId: number,departmentName:string) {

    const department={
      departmentId:departmentId,
      departmentName:departmentName
    }
  
    await this.dialogueService.IsDeleteConfirmed().then((value)=> {

      if(value)
      this.service.RemoveDepartment(department).subscribe(() => this.GetDepartments());
    
    });
  }

  //GET METHOD CALLED AT CONNECTION SERVICE
  GetDepartments() {
    this.service.GetDepartments().subscribe((data: any) => {
      this.department = data;
      this.totalLength= data.length;
    });
  }
}
