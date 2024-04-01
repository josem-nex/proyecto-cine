import { AsyncPipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterModule, RouterOutlet } from '@angular/router';
import { EMPTY, Observable, catchError } from 'rxjs';

import { IGetAllActors_response } from '../../../core/models/actor.interface';
import { ActorService } from '../../../core/services/actor.service';

@Component({
  selector: 'app-crud-actors',
  standalone: true,
  imports: [
    AsyncPipe,
    RouterOutlet,
    FormsModule,
    RouterModule
  ],
  templateUrl: './crud-actors.component.html',
  styleUrl: './crud-actors.component.css'
})
export class CrudActorsComponent implements OnInit {
  actorsResponse!: Observable<IGetAllActors_response>

  constructor(
    private serviceActors: ActorService,
    private router: Router
  ) { }
  ngOnInit(): void {
    this.actorsResponse = this.serviceActors.getAllActors().pipe(catchError((error: string)=> { return EMPTY }))
  }
} 
