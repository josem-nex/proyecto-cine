import { AsyncPipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterModule, RouterOutlet } from '@angular/router';
import { EMPTY, Observable, catchError } from 'rxjs';

import { AuthService } from '../../../core/services/auth.service';
import { IDeletePartner_send, IGetAllPartners_response } from '../../../core/models/auth.interface';

import { jsPDF } from 'jspdf'

@Component({
  selector: 'app-crud-partners',
  standalone: true,
  imports: [
    AsyncPipe,
    RouterOutlet,
    FormsModule,
    RouterModule
  ],
  templateUrl: './crud-partners.component.html',
  styleUrl: './crud-partners.component.css'
})
export class CrudPartnersComponent implements OnInit {
  partnersResponse!: Observable<IGetAllPartners_response>

  constructor(
    private servicePartners: AuthService,
    private router: Router
  ) { }
  ngOnInit(): void {
    this.partnersResponse = this.servicePartners.getAllPartners().pipe(catchError((error: string) => {
      return EMPTY
    }))

    this.partnersResponse.subscribe((value: IGetAllPartners_response)=>{
      this.response = value
    })
  }

  delete(id: string) {
    const send: IDeletePartner_send = { id: id }
    this.servicePartners.deletePartner(send).subscribe(()=>{
      this.router.navigate(['admin'])
    },(error)=>{
      alert(error);
    })
  }

  response!: IGetAllPartners_response;
  save_pdf(): void {
    

    const doc = new jsPDF();
    let t = this.response.partners

    const lista_convertida = t.map(obj => `Nombre del actor: ${obj.firstName}\nEmail: ${obj.email}\nNúmero de teléfono ${obj.phoneNumber} `)

    const result = lista_convertida.join('\n')

    doc.text(result, 10, 10);
    doc.save('save.pdf');
  }
}
