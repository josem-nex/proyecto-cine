import { AsyncPipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterModule, RouterOutlet } from '@angular/router';
import { EMPTY, Observable, catchError } from 'rxjs';
import { Idelete_ticket_send, Igetall_ticket_response } from '../../../core/models/ticket.interface';
import { TicketService } from '../../../core/services/ticket.service';

@Component({
  selector: 'app-crud-tickets',
  standalone: true,
  imports: [
    AsyncPipe, 
    RouterOutlet,
    FormsModule, 
    RouterModule
  ],
  templateUrl: './crud-tickets.component.html',
  styleUrl: './crud-tickets.component.css'
})
export class CrudTicketsComponent implements OnInit {
  ticketsResponse!: Observable<Igetall_ticket_response>

  constructor(
    private serviceTicket: TicketService,
    private router: Router
  ) { }
  ngOnInit(): void {
    this.ticketsResponse = this.serviceTicket.getall().pipe(catchError((error:string)=>{return EMPTY}))
  }

  delete(id: number) {
    const send: Idelete_ticket_send = { Id: id }
    this.serviceTicket.delete(send).subscribe(()=>{
      alert("Eliminación con éxito")
      this.router.navigate(['admin'])
    },(error)=>{
      alert("error")
    })
  }
}
