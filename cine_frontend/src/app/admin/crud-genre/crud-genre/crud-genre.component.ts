import { AsyncPipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterModule, RouterOutlet } from '@angular/router';
import { EMPTY, Observable, catchError } from 'rxjs';
import { IGetAllGenres_response } from '../../../core/models/genre.interface';
import { GenreService } from '../../../core/services/genre.service';

@Component({
  selector: 'app-crud-genre',
  standalone: true,
  imports: [
    AsyncPipe,
    RouterOutlet,
    FormsModule,
    RouterModule
  ],
  templateUrl: './crud-genre.component.html',
  styleUrl: './crud-genre.component.css'
})
export class CrudGenreComponent implements OnInit {
  genresResponse!: Observable<IGetAllGenres_response>

  constructor(
    private serviceGenres: GenreService,
    private router: Router
  ) { }
  ngOnInit(): void {
    this.genresResponse = this.serviceGenres.getAllGenres().pipe(catchError((error: string)=> { return EMPTY }))
  }


}
