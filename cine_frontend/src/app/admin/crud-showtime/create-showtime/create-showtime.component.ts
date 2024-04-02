import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterModule, RouterOutlet } from '@angular/router';
import { ShowTimeService } from '../../../core/services/showtime.service';
import { Iadd_showtime_send } from '../../../core/models/showtime.interface';

@Component({
  selector: 'app-create-showtime',
  standalone: true,
  imports: [
    FormsModule, 
    RouterModule,
    RouterOutlet
  ],
  templateUrl: './create-showtime.component.html',
  styleUrl: './create-showtime.component.css'
})
export class CreateShowtimeComponent implements OnInit {
  send: Iadd_showtime_send = {
    HallsId: 0,
    SchedulesId: 0,
    Cost: 0,
    CostPoints: 0,
    MovieId: 0
  }

  constructor(
    private serviceShowtime: ShowTimeService,
    private router: Router
  ) { }
  ngOnInit(): void { }

  create() { 
    this.serviceShowtime.add(this.send).subscribe(()=>{
      alert("ShowTime creado con éxito")
      this.router.navigate(['admin/showtime/'])
    },(error)=>{
      alert(error)
    })
  }
  cancel() { 
    this.router.navigate(['admin/showtime/'])
  }
}
