import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterModule, RouterOutlet } from '@angular/router';
import { Iadd_schedule_send } from '../../../core/models/schedule.interface';
import { ScheduleService } from '../../../core/services/schedule.service';


@Component({
  selector: 'app-create-schedule',
  standalone: true,
  imports: [
    RouterOutlet,
    FormsModule,
    RouterModule
  ],
  templateUrl: './create-schedule.component.html',
  styleUrl: './create-schedule.component.css'
})
export class CreateScheduleComponent implements OnInit {
  send: Iadd_schedule_send = {
    DateStart: new Date,
    DateEnd: new Date
  }

  constructor(
    private serviceSchedule: ScheduleService,
    private router: Router
  ) { }
  ngOnInit(): void { }

  create() { 
    console.log(this.send.DateStart)

    this.serviceSchedule.add(this.send).subscribe(()=>{
      alert("Schedule creado con éxito")
      this.router.navigate(['admin/schedule/'])
    },(error)=>{
      alert(error)
    })
  }
  cancel() {
    this.router.navigate(['admin/schedule/'])
  }

  
}
