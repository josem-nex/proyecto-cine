import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router, RouterModule, RouterOutlet } from '@angular/router';
import { HallService } from '../../../core/services/hall.service';
import { Iget_hall_response, Iget_hall_send, Iupdate_hall_send } from '../../../core/models/hall.interface';


@Component({
  selector: 'app-update-hall',
  standalone: true,
  imports: [
    RouterOutlet,
    FormsModule,
    RouterModule
  ],
  templateUrl: './update-hall.component.html',
  styleUrl: './update-hall.component.css'
})
export class UpdateHallComponent implements OnInit {
  index!: number;
  send: Iupdate_hall_send = {
    Id: 0,
    Name: '',
    Capacity: 0,
    SchedulesId: []
  }

  constructor(
    private serviceHall: HallService,
    private route: ActivatedRoute,
    private router: Router 
  ) { }
  ngOnInit(): void {
    this.index = this.route.snapshot.params['id'];
    const send: Iget_hall_send = {
      Id: this.index
    }
    this.serviceHall.get(send).subscribe((value:Iget_hall_response)=>{
      this.send.Id = send.Id
      this.send.Name = value.name
      this.send.Capacity = value.capacity
    },(error)=>{
      alert(error)
      this.router.navigate(['admin/halls/'])
    })
  }

  update() {
    this.serviceHall.update(this.send).subscribe((values)=>{
      alert("Actualización hecha con éxito")
    },(error)=>{
      alert(error)
    })
    this.router.navigate(['admin'])
  }
  cancel() {
    this.router.navigate(['admin/halls/'])
  }
}
