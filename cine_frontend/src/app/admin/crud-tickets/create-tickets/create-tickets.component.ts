import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterModule, RouterOutlet } from '@angular/router';
import { Iadd_ticket_send } from '../../../core/models/ticket.interface';
import { TicketService } from '../../../core/services/ticket.service';


@Component({
  selector: 'app-create-tickets',
  standalone: true,
  imports: [
    FormsModule, 
    RouterModule,
    RouterOutlet
  ],
  templateUrl: './create-tickets.component.html',
  styleUrl: './create-tickets.component.css'
})
export class CreateTicketsComponent implements OnInit {
  send: Iadd_ticket_send = {
    ShowTimesId: 0,
    ChairsId: 0,
    DiscountsIds: [],
    IsWeb: false
  }
  discountsIdText!: string;

  constructor(
    private serviceTickets: TicketService,
    private router: Router
  ) { }
  ngOnInit(): void { }
  
  create() { 
    this.send.DiscountsIds = this.discountsIdText.split(',').map(m=>parseInt(m,10))

    this.serviceTickets.add(this.send).subscribe(()=>{
      alert("Ticket creado con éxito")
      this.router.navigate(['admin/tickets/'])
    },(error)=>{
      alert(error)
    })
  }
  cancel() {
    this.router.navigate(['admin/tickets/'])
  }

}
