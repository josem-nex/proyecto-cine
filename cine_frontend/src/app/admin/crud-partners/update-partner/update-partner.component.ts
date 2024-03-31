import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, RouterModule, RouterOutlet } from '@angular/router';
import { FormsModule } from '@angular/forms';

import { AuthService } from '../../../core/services/auth.service';
import { IGetPartner_send, IGetPartner_response, IUpdatePartner_send } from '../../../core/models/auth.interface';

@Component({
  selector: 'app-update-partner',
  standalone: true,
  imports: [
    RouterOutlet,
    FormsModule,
    RouterModule
  ],
  templateUrl: './update-partner.component.html',
  styleUrl: './update-partner.component.css'
})
export class UpdatePartnerComponent implements OnInit {
  index!: string;
  send: IUpdatePartner_send = {
    id: '',
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
    private route: ActivatedRoute,
    private router: Router
    ) { }
  ngOnInit(): void {
    this.index = this.route.snapshot.params['id'];
    const send: IGetPartner_send = {
      id: this.index
    }
    this.serviceAuth.getPartner(send).subscribe((value: IGetPartner_response)=>{
      this.send.id = send.id
      this.send.firstname = value.firstName
      this.send.lastname = value.lastName
      this.send.phonenumber = value.phoneNumber
      this.send.email = value.email
      this.send.ci = value.ci
      this.send.address = value.address
    },(error)=>{
      alert(error)
      this.router.navigate(['admin/partners/'])
    })
  }

  update() {
    this.serviceAuth.updatePartner(this.send).subscribe((values)=>{
      alert("Actualizacioa hecho con exito")
    }, (error)=>{
      alert(error)
    })
    this.router.navigate(['admin'])
  }
  cancel() {
    this.router.navigate(['admin/partners/'])
  }
}
