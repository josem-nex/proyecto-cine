import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router, RouterModule, RouterOutlet } from '@angular/router';
import { Iget_ticket_response, Iget_ticket_send, Iupdate_ticket_send } from '../../../core/models/ticket.interface';
import { TicketService } from '../../../core/services/ticket.service';

@Component({
  selector: 'app-update-tickets',
  standalone: true,
  imports: [
    RouterOutlet,
    FormsModule,
    RouterModule
  ],
  templateUrl: './update-tickets.component.html',
  styleUrl: './update-tickets.component.css'
})
export class UpdateTicketsComponent implements OnInit {
  index!: number;
  send: Iupdate_ticket_send = {
    Id: 0,
    ShowTimesId: 0,
    ChairsId: 0,
    DiscountsIds: [],
    IsWeb: false
  }
  discountsIdText!: string;

  constructor(
    private serviceTicket: TicketService,
    private route: ActivatedRoute,
    private router: Router 
  ) { }
  ngOnInit(): void {
    this.discountsIdText = ''
    this.index = this.route.snapshot.params['id'];
    const send: Iget_ticket_send = { Id: this.index }
    this.serviceTicket.get(send).subscribe((value:Iget_ticket_response)=>{
      this.send.Id = send.Id
      this.send.ChairsId = value.chairsId
      this.send.IsWeb = value.isWeb
      this.send.ShowTimesId = value.showTimesId
    },(error)=>{
      alert(error)
      this.router.navigate(['admin/tickets/'])
    })
  }

  update() { 
    this.send.DiscountsIds = this.discountsIdText.split(',').map(m=>parseInt(m,10))

    this.serviceTicket.update(this.send).subscribe((values)=>{
      alert("Actualización hecha con éxito")
    },(error)=>{
      alert(error)
    })
    this.router.navigate(['admin'])
  }
  cancel() {
    this.router.navigate(['admin/tickets/'])
  }
}
