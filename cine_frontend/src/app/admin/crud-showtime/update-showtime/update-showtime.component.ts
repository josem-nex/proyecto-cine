import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router, RouterModule, RouterOutlet } from '@angular/router';

import { Iget_showtime_response, Iget_showtime_send, Iupdate_showtime_send } from '../../../core/models/showtime.interface';
import { ShowTimeService } from '../../../core/services/showtime.service';

@Component({
  selector: 'app-update-showtime',
  standalone: true,
  imports: [
    RouterOutlet,
    FormsModule,
    RouterModule
  ],
  templateUrl: './update-showtime.component.html',
  styleUrl: './update-showtime.component.css'
})
export class UpdateShowtimeComponent implements OnInit{
  index!: number;
  send: Iupdate_showtime_send = {
    Id: 0,
    HallsId: 0,
    SchedulesId: 0,
    Cost: 0,
    CostPoints: 0,
    MovieId: 0
  }

  constructor(
    private serviceShowtime: ShowTimeService,
    private route: ActivatedRoute,
    private router: Router
  ) { }
  ngOnInit(): void {
    this.index = this.route.snapshot.params['id'];
    const send: Iget_showtime_send = { Id: this.index }

    this.serviceShowtime.get(send).subscribe((values:Iget_showtime_response)=>{
      this.send.Id = send.Id
      this.send.Cost = values.cost
      this.send.CostPoints = values.costPoints
      this.send.HallsId = values.hallsId
      this.send.MovieId = values.movieId
      this.send.SchedulesId = values.schedulesId
    },(error)=>{
      alert(error)
      this.router.navigate(['admin/showtime/'])
    })
  }

  update() { 
    this.serviceShowtime.update(this.send).subscribe((values)=>{
      alert("Actualización hecha con éxito")
    },(error)=>{
      alert(error)
    })
    this.router.navigate(['admin'])
  }
  cancel() { 
    this.router.navigate(['admin/admin/'])
  }

}
