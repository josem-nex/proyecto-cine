import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterModule, RouterOutlet } from '@angular/router';

import { ILogin_admin_send } from '../../core/models/admin.interface';
import { LocalStorageService } from '../../core/services/local.service';
import { AdminService } from '../../core/services/admin.service';
import { AuxiliarService } from '../../core/services/auxiliar.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [
    RouterOutlet, 
    FormsModule, 
    RouterModule
  ],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginAdminComponent {
  send: ILogin_admin_send = {
    User: '',
    Password: ''
  }
  constructor(
    public local: LocalStorageService,
    private serviceAdmin: AdminService,
    private router: Router,
    private auxiliar: AuxiliarService
  ) { }
  ngOnInit(): void {
    this.local.setItem("isAdmin", "false")
  }

  login() {
    this.serviceAdmin.Login(this.send).subscribe((values)=>{
      this.local.setItem("isAdmin", "true")
      alert("Admin loggeado con exito")
      this.router.navigate(['admin'])
    }, (error)=>{
      alert(error)
      this.router.navigate([''])
    })
  }
  cancel() {
    this.router.navigate([''])
  }

}
