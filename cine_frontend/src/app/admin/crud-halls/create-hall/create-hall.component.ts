import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterModule, RouterOutlet } from '@angular/router';
import { Iadd_hall_send } from '../../../core/models/hall.interface';
import { HallService } from '../../../core/services/hall.service';

@Component({
  selector: 'app-create-hall',
  standalone: true,
  imports: [
    RouterOutlet,
    FormsModule,
    RouterModule
  ],
  templateUrl: './create-hall.component.html',
  styleUrl: './create-hall.component.css'
})
export class CreateHallComponent implements OnInit {
  send: Iadd_hall_send = {
    Name: '',
    Capacity: 0,
    SchedulesId: []
  }
  schedulesIdText!: string;

  constructor(
    private serviceHall: HallService,
    private router: Router
  ) { }
  ngOnInit(): void { }

  create() { 
    this.send.SchedulesId = this.schedulesIdText.split(',').map(m=>parseInt(m,10))
    
    this.serviceHall.add(this.send).subscribe(()=>{
      alert("Hall creado con éxito")
      this.router.navigate(['admin/halls/'])
    })
  }
  cancel() {
    this.router.navigate(['admin/halls/'])
  }


}
