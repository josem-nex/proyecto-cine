import { AsyncPipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterModule, RouterOutlet } from '@angular/router';
import { EMPTY, Observable, catchError } from 'rxjs';

import { IGetAllActors_response } from '../../../core/models/actor.interface';
import { ActorService } from '../../../core/services/actor.service';

import { jsPDF } from 'jspdf'

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

  response!: IGetAllActors_response;

  constructor(
    private serviceActors: ActorService,
    private router: Router
  ) { }
  ngOnInit(): void {
    this.actorsResponse = this.serviceActors.getAllActors().pipe(catchError((error: string)=> { return EMPTY }))

    this.actorsResponse.subscribe((value: IGetAllActors_response)=>{
      this.response = value
    })

  }
  save_pdf(): void {
    

    const doc = new jsPDF();
    let t = this.response.actors

    const lista_convertida = t.map(obj => `Nombre del actor: ${obj.name}`)

    const result = lista_convertida.join('\n')

    doc.text(result, 10, 10);
    doc.save('save.pdf');
  }
} 


