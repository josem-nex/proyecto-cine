import { Component, OnInit } from '@angular/core';
import { AsyncPipe } from '@angular/common';
import { Router, RouterModule, RouterOutlet } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { EMPTY, Observable, catchError } from 'rxjs';
import { IGetAllMovies_response } from '../../core/models/movie.interface';
import { MovieService } from '../../core/services/movies.service';

@Component({
  selector: 'app-list-movie',
  standalone: true,
  imports: [
    AsyncPipe, 
    RouterOutlet, 
    FormsModule, 
    RouterModule
  ],
  templateUrl: './list-movie.component.html',
  styleUrl: './list-movie.component.css'
})
export class ListMovieComponent implements OnInit {
  moviesResponse!: Observable<IGetAllMovies_response>

  constructor(
    private serviceMovies: MovieService,
    private router: Router
  ) { }
  ngOnInit(): void {
    this.moviesResponse = this.serviceMovies.getAllMovies().pipe(catchError((error:string)=>{
      return EMPTY
    }))
  }
}
