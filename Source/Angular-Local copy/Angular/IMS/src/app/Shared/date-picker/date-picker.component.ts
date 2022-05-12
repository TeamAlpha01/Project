import { Component, OnInit } from '@angular/core';

// @Component({
//   selector: 'app-date-picker',
//   templateUrl: './date-picker.component.html',
//   styleUrls: ['./date-picker.component.css']
// })
// export class DatePickerComponent implements OnInit {

//   constructor() { }

//   ngOnInit(): void {
//   }

// }

@Component({
  selector: 'datepicker-min-max-example',
  templateUrl: './date-picker.component.html',
  styleUrls: ['./date-picker.component.css'],
})
export class DatepickerMinMaxExample {
  minDate = new Date(2000, 0, 1);
  maxDate = new Date(2020, 0, 1);
}