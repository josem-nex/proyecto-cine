import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterModule, RouterOutlet } from '@angular/router';

import { ILogin_send } from '../../core/models/auth.interface';
import { AuthService } from '../../core/services/auth.service';
import { AuxiliarService } from '../../core/services/auxiliar.service';
import { LocalStorageService } from '../../core/services/local.service';

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
export class LoginComponent implements OnInit {
  send: ILogin_send = {
    email: '',
    password: ''
  }

  constructor(
    private serviceAuth: AuthService,
    private router: Router, 
    private local: LocalStorageService,
    private auxiliar: AuxiliarService
  ) { }

  ngOnInit(): void { 
    this.local.setItem("isUser", "false")
  }

  login() {
    this.serviceAuth.login(this.send).subscribe(()=>{
      alert("Usuario loggeado con exito")
      this.local.setItem("isUser", "true")
    }, (error)=> {
      alert(error)
    })
    this.router.navigate([''])
  }
  cancel() {
    this.router.navigate([''])
  }
}
//isUser