import { DialogueBoxService } from './../../Services/dialogue-box.service';
import { Component, OnInit } from '@angular/core';
import { ConnectionService } from 'src/app/Services/connection.service';

@Component({
  selector: 'app-admin-addproject-page',
  templateUrl: './admin-view-Project-page.component.html',
  styleUrls: ['./admin-view-Project-page.component.css']
})
export class AdminviewProjectPageComponent implements OnInit {
  title = "Projects";
  
  //TO STORE DATA FROM DATABASE
  data: any;
  
  //PAGINATION
  totalLength: any;
  page: number = 1;
  response: string = '';
  error: string = '';
  
 
  constructor(private connection: ConnectionService,private dialogueService:DialogueBoxService) { }

  ngOnInit(): void {
    this.GetProjects()
  }
  
  //GET METHOD CALLED AT CONNECTIONS SERVICE
  GetProjects(){
    this.connection.GetProjects().subscribe((data: any) => {
      this.data = data;
    })
  }

  async RemoveProject(projectId: number) {
  
    await this.dialogueService.IsDeleteConfirmed().then((value) => {

      if (value)
        this.connection.RemoveProject(projectId).subscribe({
          next: (data) => { this.response = data.message, this.GetProjects() },
          error: (error) => { this.error = error.error, this.snackBar() },
          complete: () => this.snackBar(),
        });

    });
    
  }
  snackBar() {
    setTimeout(() => {
      this.error = '';
      this.response = '';
    }, 2000);
}
}
