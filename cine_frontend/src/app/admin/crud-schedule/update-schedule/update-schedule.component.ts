import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router, RouterModule, RouterOutlet } from '@angular/router';
import { Iget_schedule_response, Iget_schedule_send, Iupdate_schedule_send } from '../../../core/models/schedule.interface';
import { ScheduleService } from '../../../core/services/schedule.service';


@Component({
  selector: 'app-update-schedule',
  standalone: true,
  imports: [
    RouterOutlet,
    FormsModule,
    RouterModule
  ],
  templateUrl: './update-schedule.component.html',
  styleUrl: './update-schedule.component.css'
})
export class UpdateScheduleComponent implements OnInit {
  index!: number;
  send: Iupdate_schedule_send = {
    Id: 0,
    DateStart: new Date,
    DateEnd: new Date
  }

  constructor(
    private serviceSchedule: ScheduleService,
    private route: ActivatedRoute,
    private router: Router
  ) { }
  ngOnInit(): void {
    this.index = this.route.snapshot.params['id'];
    const send: Iget_schedule_send = { Id: this.index }

    this.serviceSchedule.get(send).subscribe((value:Iget_schedule_response)=>{
      this.send.Id = send.Id
      this.send.DateStart = value.dateStart
      this.send.DateEnd = value.dateEnd
    },(error)=>{
      alert(error)
      this.router.navigate(['admin/schedule'])
    })
  }

  update() {
    this.serviceSchedule.update(this.send).subscribe((values)=>{
      alert("Actualización hecha con éxito")
    },(error)=>{
      alert(error)
    })
    this.router.navigate(['admin'])
  }
  cancel() { 
    this.router.navigate(['admin/schedule'])
  }


}
