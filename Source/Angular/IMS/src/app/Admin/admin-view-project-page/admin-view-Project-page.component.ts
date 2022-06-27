import { DialogueBoxService } from './../../Services/dialogue-box.service';
import { Component, OnInit } from '@angular/core';
import { ConnectionService } from 'src/app/Services/connection.service';

@Component({
  selector: 'app-admin-addproject-page',
  templateUrl: './admin-view-Project-page.component.html',
  styleUrls: ['./admin-view-Project-page.component.css']
})
export class AdminviewProjectPageComponent implements OnInit {
  data: any;
  totalLength: any;
  page: number = 1;
  title = "Projects";
 
  constructor(private connection: ConnectionService,private dialogueService:DialogueBoxService) { }

  ngOnInit(): void {
    this.GetProjects()
  }
  
  GetProjects(){
    this.connection.GetProjects().subscribe((data: any) => {
      this.data = data;
    })
  }

  async RemoveProject(projectId: number) {
  
    await this.dialogueService.IsDeleteConfirmed().then((value)=> {

      if(value)
      this.connection.RemoveProject(projectId).subscribe(()=>this.GetProjects());
    
    });
  }

}
