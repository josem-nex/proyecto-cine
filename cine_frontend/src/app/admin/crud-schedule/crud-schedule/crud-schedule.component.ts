import { AsyncPipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterModule, RouterOutlet } from '@angular/router';
import { EMPTY, Observable, catchError } from 'rxjs';
import { Idelete_schedule_send, Igetall_schedule_response } from '../../../core/models/schedule.interface';
import { ScheduleService } from '../../../core/services/schedule.service';

@Component({
  selector: 'app-crud-schedule',
  standalone: true,
  imports: [
    AsyncPipe, 
    RouterOutlet,
    FormsModule, 
    RouterModule
  ],
  templateUrl: './crud-schedule.component.html',
  styleUrl: './crud-schedule.component.css'
})
export class CrudScheduleComponent implements OnInit {
  scheduleResponse!: Observable<Igetall_schedule_response>

  constructor(
    private serviceSchedule: ScheduleService,
    private router: Router
  ) { }
  ngOnInit(): void {
    this.scheduleResponse = this.serviceSchedule.getall().pipe(catchError((error: string) => { return EMPTY }))
  }

  delete(id: number) {
    const send: Idelete_schedule_send = { Id: id }
    this.serviceSchedule.delete(send).subscribe(()=>{
      alert("Eliminación con éxito")
      this.router.navigate(['admin'])
    },(error)=>{
      alert("error");
    })
  }

}
