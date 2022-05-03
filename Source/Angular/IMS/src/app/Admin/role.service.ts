import { Injectable } from '@angular/core';
import { Role } from './role.model';

@Injectable({
  providedIn: 'root'
})
export class RoleService {

  constructor() { }
  formData:Role = new Role();
}
