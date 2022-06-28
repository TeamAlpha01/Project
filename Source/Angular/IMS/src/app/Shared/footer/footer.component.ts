import { Location } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css']
})
export class FooterComponent implements OnInit {
 

  constructor(private location:Location) { }
  @Input() 
  BackBtn:boolean=false;

  ngOnInit(): void {
  } 

  Back(){
    this.location.back();
  }
}
