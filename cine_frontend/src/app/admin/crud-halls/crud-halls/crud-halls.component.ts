import { Component, OnInit } from '@angular/core';
import { AsyncPipe } from '@angular/common';
import { RouterModule, RouterOutlet } from '@angular/router';
import { FormsModule } from '@angular/forms';

import { EMPTY, Observable, catchError } from 'rxjs';
import { HallService } from '../../../core/services/hall.service';

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

  constructor(
    private serviceHall: HallService
  ) { }
  ngOnInit(): void {
    
  }
  

}
