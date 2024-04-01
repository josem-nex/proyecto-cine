import { AsyncPipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterModule, RouterOutlet } from '@angular/router';
import { EMPTY, Observable, catchError } from 'rxjs';
import { IGetAllChairs_response } from '../../../core/models/chair.interface';
import { ChairService } from '../../../core/services/chair.service';

@Component({
  selector: 'app-crud-chairs',
  standalone: true,
  imports: [
    AsyncPipe, 
    RouterOutlet,
    FormsModule,
    RouterModule
  ],
  templateUrl: './crud-chairs.component.html',
  styleUrl: './crud-chairs.component.css'
})
export class CrudChairsComponent implements OnInit {
  chairsResponse!: Observable<IGetAllChairs_response>

  constructor(
    private serviceChairs: ChairService, 
    private router: Router
  ) { }
  ngOnInit(): void {
    this.chairsResponse = this.serviceChairs.getAllChair().pipe(catchError((error: string)=> { return EMPTY }))
  }
}
