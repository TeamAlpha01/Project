import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ConnectionService } from 'src/app/Services/connection.service';

@Component({
  selector: 'app-tac-edit-pool',
  templateUrl: './tac-edit-pool.component.html',
  styleUrls: ['./tac-edit-pool.component.css']
})

export class TacEditPoolComponent implements OnInit {
  title = 'Edit Pool'
  data: any;
  response: string = '';
  poolId: any;
  poolDetails: any;
  _pool = '';
  _dept = '';
  error: string = '';
  submitted: boolean = false;

  constructor(private connection: ConnectionService, private fb: FormBuilder, private route: ActivatedRoute, private router: Router) { }

  EditPoolForm = this.fb.group({
    poolName: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(15), Validators.pattern('[A-Za-z.0-9\\s]*')]],
  });

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.poolId = params['poolId']
    });
    this.GetPools();
  }

  GetPools() {
    this.connection.GetPools().subscribe((data: any) => {
      this.poolDetails = data;
      for (let item of this.poolDetails) {
        if (this.poolId == item.poolId) {
          this._pool = item.poolName;
          console.log(this._pool);
          this._dept = item.departmentName;
        }
      }
    })
  }

  getpoolName() {
    return this.EditPoolForm.get('poolName')
  }

  EditPool() {
    this.submitted = true;
    this.error = '';
    if (this.EditPoolForm.valid) {
      console.log(true)
      this.connection.EditPool(this.poolId, this.getpoolName()?.value).subscribe({
        next: (data) => this.response = data.message,
        error: (error) => this.error = error.error.message,
        complete: () => this.clearInputFields(),
      });
    }
  }

  clearInputFields() 
  {    
      this.submitted = false;
      setTimeout(() => {
        this.response = '';
        this.router.navigateByUrl("/tac/managepool");
      }, 2000);
  }

}
