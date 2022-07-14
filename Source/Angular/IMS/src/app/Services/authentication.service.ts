import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { ConnectionService } from './connection.service';

@Injectable({
  providedIn: 'root'
})

export class AuthenticationService {

  constructor(private service: ConnectionService, private route: Router) { }

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

  static IsAdmin(): boolean {
    return this.GetData("Admin") ? true : false;

  }
  static IsTAC(): boolean {
    return this.GetData("TAC") ? true : false;
  }

  static GetUser(): string {
    if (AuthenticationService.GetData("TAC")) {
      return "TAC";
    }
    else if (AuthenticationService.GetData("Admin")) {
      return "Admin";
    }
    else if (AuthenticationService.GetData("Management")) {
      return "Management";
    }
    else if (AuthenticationService.GetData("token")) {
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
