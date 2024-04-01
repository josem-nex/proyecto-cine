import { AsyncPipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterModule, RouterOutlet } from '@angular/router';
import { EMPTY, Observable, catchError } from 'rxjs';

import { HallService } from '../../../core/services/hall.service';
import { Idelete_hall_send, Igetall_hall_response } from '../../../core/models/hall.interface';

@Component({
  selector: 'app-crud-halls',
  standalone: true,
  imports: [
    AsyncPipe, 
    RouterOutlet,
    FormsModule, 
    RouterModule
  ],
  templateUrl: './crud-halls.component.html',
  styleUrl: './crud-halls.component.css'
})
export class CrudHallsComponent implements OnInit {
  hallsResponse!: Observable<Igetall_hall_response>

  constructor(
    private serviceHall: HallService,
    private router: Router
  ) { }
  ngOnInit(): void {
    this.hallsResponse = this.serviceHall.getall().pipe(catchError((error: string) => { return EMPTY }))
  }

  delete(id: number) {
    const send: Idelete_hall_send = { Id: id }
    this.serviceHall.delete(send).subscribe(()=>{
      alert("Eliminación con éxito")
      this.router.navigate(['admin'])
    },(error)=>{
      alert("error")
    })
  }
}
