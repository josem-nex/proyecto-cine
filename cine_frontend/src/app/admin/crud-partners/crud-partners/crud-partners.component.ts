import { AsyncPipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterModule, RouterOutlet } from '@angular/router';
import { EMPTY, Observable, catchError } from 'rxjs';
import { AuthService } from '../../../core/services/auth.service';
import { IDeletePartner_send, IGetAllPartners_response } from '../../../core/models/auth.interface';

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
  }

  delete(id: string) {
    const send: IDeletePartner_send = { id: id }
    this.servicePartners.deletePartner(send).subscribe(()=>{
      this.router.navigate(['admin'])
    },(error)=>{
      alert("error");
    })
  }

}
