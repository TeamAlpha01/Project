import { Component, OnInit } from '@angular/core';
import { ConnectionService } from 'src/app/Services/connection.service';
import { DialogBoxComponent } from 'src/app/Shared/DialogBox/dialog-box/dialog-box.component';
import { MatDialog } from '@angular/material/dialog';
import { DialogueBoxService } from 'src/app/Services/dialogue-box.service';

@Component({
  selector: 'app-managepool',
  templateUrl: './managepool.component.html',
  styleUrls: ['./managepool.component.css']
})
export class ManagepoolComponent implements OnInit {
  title = 'Manage Pool'

  poolDetails: any;
  departmentDetails: any;
  _dept = '';
  _pool = '';
  page: number = 1;
  totalLength: any;


  constructor(private connection: ConnectionService, private dialogueService:DialogueBoxService) { }

  ngOnInit(): void {
    
    this.GetPools();
    this.GetDepartments();
    this.poolEnabler();
  }

  GetPools() {
    this.connection.GetPools().subscribe((data: any) => {
      this.poolDetails = data;
    })
  }

  GetDepartments() {
    this.connection.GetDepartments().subscribe((data: any) => {
      this.departmentDetails = data;
    })
  }

  async RemovePool(poolId: number) {
  
    await this.dialogueService.IsDeleteConfirmed().then((value)=> {

      if(value)
      this.connection.RemovePool(poolId).subscribe(() => this.GetPools());
    
    });
  }
  poolEnabler():boolean  {
    if (this._dept == '') { 
      
      return true;
    }
    else {
      return false; 
    }
  }


}
