import { Component, OnInit } from '@angular/core';
import { IRegister_send } from '../../core/models/auth.interface';
import { AuthService } from '../../core/services/auth.service';
import { Router, RouterModule, RouterOutlet } from '@angular/router';
import { LocalStorageService } from '../../core/services/local.service';
import { AuxiliarService } from '../../core/services/auxiliar.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [
    RouterOutlet, 
    FormsModule, 
    RouterModule
  ],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent implements OnInit {
  send: IRegister_send = {
    firstname: '',
    lastname: '',
    email: '',
    ci: '',
    address: '',
    phonenumber: '',
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

  register() {
    this.serviceAuth.register(this.send).subscribe(()=>{
      alert("Usuario registrado con exito")
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
