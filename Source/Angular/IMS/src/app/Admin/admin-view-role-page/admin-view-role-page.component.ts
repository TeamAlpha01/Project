import { DialogueBoxService } from './../../Services/dialogue-box.service';
import { Component, OnInit } from '@angular/core';
import { ConnectionService } from 'src/app/Services/connection.service';  

@Component({
  selector: 'app-admin-view-role-page',
  templateUrl: './admin-view-role-page.component.html',
  styleUrls: ['./admin-view-role-page.component.css'],
})
export class AdminViewRolePageComponent implements OnInit {
  title: string = 'Roles';
  totalLength: any;
  page: number = 1;
  role: any;

  constructor(private service: ConnectionService,private dialogueService:DialogueBoxService) {}

  ngOnInit() {
    this.GetRoles();
  }

  
  async removeRole(roleId: number) {
  
    await this.dialogueService.IsDeleteConfirmed().then((value)=> {

      if(value)
      this.service.RemoveRole(roleId).subscribe(() => this.GetRoles());
    
    });
  }
  //GET METHOD CALLED AT CONNECTION SERVICE
  GetRoles() {
    this.service.GetRoles().subscribe((data: any) => {
      this.role = data;
      this.totalLength = this.role.length;
    });
  }
}
