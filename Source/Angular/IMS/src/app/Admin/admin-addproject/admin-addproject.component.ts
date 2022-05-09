import { Component, OnInit } from '@angular/core';
import { Project } from 'src/app/Model/Project';
import { HttpClient } from '@angular/common/http';
@Component({
  selector: 'app-admin-addproject',
  templateUrl: './admin-addproject.component.html',
  styleUrls: ['./admin-addproject.component.css']
})
export class AdminAddprojectComponent implements OnInit {
 title ='Manage Project'
 project: Project={
   projectName: '',
   
 }
  constructor(private http:HttpClient) { }
  addProject(){
    console.log(this.project)
  }
  ngOnInit(): void {
  }

}
