import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ValidationService {

  constructor() { }

  ValidateName(UserName: string){
    console.log(UserName)
  }
}
