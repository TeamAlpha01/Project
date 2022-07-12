import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Router } from '@angular/router';
import { AuthenticationService } from './authentication.service';

@Injectable({
  providedIn: 'root'
})

export class AuthorizationService {

  constructor(private route: Router, private authService: AuthenticationService) { }

  canActivate(route: ActivatedRouteSnapshot) {
    if (AuthenticationService.GetData("token")) {
      if (route.data['User'] == AuthenticationService.GetUser()) {
        return true;
      }
      else if (route.data['User'] == AuthenticationService.GetUser()) {
        return true;
      }
      else if (route.data['User'] == AuthenticationService.GetUser()) {
        return true;
      }
      else {
        this.authService.ClearToken();
        return this.route.navigateByUrl("");
      }
    }
    else {
      this.authService.ClearToken();
      return this.route.navigateByUrl("");
    }

  }
}
