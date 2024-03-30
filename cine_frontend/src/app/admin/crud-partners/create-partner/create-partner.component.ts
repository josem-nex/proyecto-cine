import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterModule, RouterOutlet } from '@angular/router';
import { AuthService } from '../../../core/services/auth.service';
import { IRegister_send } from '../../../core/models/auth.interface';

@Component({
  selector: 'app-create-partner',
  standalone: true,
  imports: [RouterOutlet, FormsModule, RouterModule],
  templateUrl: './create-partner.component.html',
  styleUrl: './create-partner.component.css'
})
export class CreatePartnerComponent implements OnInit {
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
    private router: Router
    ) { }

  ngOnInit(): void { }

  create() {
    this.serviceAuth.register(this.send).subscribe(()=>{
      alert("Usuario creado con exito")
      this.router.navigate(['admin/partners/'])
    }, (error)=>{
      alert(error)
    })
  }
  cancel() {
    this.router.navigate(['admin/partners/'])
  }
}
