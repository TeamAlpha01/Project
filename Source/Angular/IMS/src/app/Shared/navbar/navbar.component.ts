import { Component, Input, OnInit } from '@angular/core';
import * as $ from 'jquery';


@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  constructor() { }
  @Input() title = '';


  ngOnInit(): void {
  }

  toggle() {
    $('.sidebar, .content').toggleClass("open");
  }
}
