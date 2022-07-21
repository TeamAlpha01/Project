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
  response: string = '';
  error: string = '';

  constructor(private service: ConnectionService, private dialogueService: DialogueBoxService) { }

  ngOnInit(): void {
    this.GetDepartments();
  }

  async removeDepartment(departmentId: number, departmentName: string) {

    const department = {
      departmentId: departmentId,
      departmentName: departmentName
    }

    await this.dialogueService.IsDeleteConfirmed().then((value) => {

      if (value)
        this.service.RemoveDepartment(department).subscribe({
          next: (data) => { this.response = data },
          error: (error) => { this.error = error.error, this.snackBar() },
          complete: () => this.snackBar(),
        });

    });
  }

  //GET METHOD CALLED AT CONNECTION SERVICE
  GetDepartments() {
    this.service.GetDepartments().subscribe((data: any) => {
      this.department = data;
      this.totalLength = data.length;
    });
  }
  snackBar() {
    setTimeout(() => {
      this.error = '';
      this.response = '';
    }, 2000);

  }
}
