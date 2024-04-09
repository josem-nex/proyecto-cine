import { AsyncPipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterModule, RouterOutlet } from '@angular/router';
import { EMPTY, Observable, catchError } from 'rxjs';
import { Idelete_showtime_send, Igetall_showtime_response } from '../../../core/models/showtime.interface';
import { ShowTimeService } from '../../../core/services/showtime.service';

@Component({
  selector: 'app-crud-showtime',
  standalone: true,
  imports: [    
    AsyncPipe, 
    RouterOutlet,
    FormsModule, 
    RouterModule
  ],
  templateUrl: './crud-showtime.component.html',
  styleUrl: './crud-showtime.component.css'
})
export class CrudShowtimeComponent implements OnInit {
  showtimeResponse!: Observable<Igetall_showtime_response>

  constructor(
    private serviceShowtime: ShowTimeService,
    private router: Router
  ) { }
  ngOnInit(): void {
    this.showtimeResponse = this.serviceShowtime.getall().pipe(catchError((error:string)=>{return EMPTY}))
  }

  delete(id: number) {
    const send: Idelete_showtime_send = { Id: id }
    this.serviceShowtime.delete(send).subscribe(()=>{
      alert("Eliminación con éxito")
      this.router.navigate(['admin'])
    },(error)=>{
      alert("error");
    })
  }

}
