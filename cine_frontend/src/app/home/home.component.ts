import { Component, OnInit } from '@angular/core';
import { AsyncPipe } from '@angular/common';
import { Router, RouterModule, RouterOutlet } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { MovieService } from '../core/services/movies.service';
import { EMPTY, Observable, catchError } from 'rxjs';
import { IGetAllMovies_response, IGetAllMovies_response_aux } from '../core/models/movie.interface';


@Component({
  selector: 'app-home',
  standalone: true,
  imports: [
    AsyncPipe, 
    RouterOutlet, 
    FormsModule, 
    RouterModule
  ],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit {
  movieResponse!: IGetAllMovies_response_aux[]

  constructor(
    private serviceMovies: MovieService,
    private router: Router
  ) { }
  ngOnInit(): void {
    this.serviceMovies.getAllMovies().subscribe((values:IGetAllMovies_response)=>{
      this.movieResponse = values.movies.slice(0,10)
    },(error:string)=>{
      alert(error)
    })
  }
  
}
/*

*/