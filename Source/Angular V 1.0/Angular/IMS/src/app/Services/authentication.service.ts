import { Injectable } from '@angular/core';


@Injectable({
  providedIn: 'root'
})

export class AuthenticationService {

  constructor() { }

  static GetData(key: string): string | null {
    const itemStr = localStorage.getItem(key)
    if (!itemStr) {
      return null
    }
    const item = JSON.parse(itemStr)
    const now = new Date()
    if (now.getTime() > item.expiry) {
      localStorage.removeItem(key)
      return null
    }
    return item.value
  }

  static SetDateWithExpiry(key: string, value: string, expiryInMinutes: number) {
    const now = new Date()
    expiryInMinutes = expiryInMinutes * 60000;

    const item = {
      value: value,

      expiry: now.getTime() + expiryInMinutes,
    }
    localStorage.setItem(key, JSON.stringify(item))
  }

  static GetUser(): string {
    if (AuthenticationService.GetData("user") == "a378b5658dbdcaf167e945242572bd3339f540af202acf0ab70741e411d861b7") {
      return "TAC";
    }
    else if (AuthenticationService.GetData("user") == "6e93e549b7140ec74ade7f56aff807f19b7dec5fea37e57902e91286f3b27d64") {
      return "Admin";
    }
    else if (AuthenticationService.GetData("user") == "f0af9bc36847bc8334ffd57cab4cff0d080116b4463d788bce2fe22c5e8bc01f") {
      return "Management";
    }
    else if (AuthenticationService.GetData("user") == "3fc90e88bbe900077c96b0253ce7d279ac5646ac5d8335dea8ea9e4f98c6c582") {
      return "Interviewer";
    }
    else {
      return " ";
    }
  }
  static SetUserName(key: string, value: string) {
    localStorage.setItem(key, JSON.stringify(value))
  }
  static GetUserName() {
    return (localStorage.getItem("UserName"));
  }

  ClearToken() {
    localStorage.clear();
  }
}
