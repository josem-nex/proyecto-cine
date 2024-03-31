import { Component, OnInit } from '@angular/core';
import { AsyncPipe } from '@angular/common';
import { Router, RouterModule, RouterOutlet } from '@angular/router';
import { FormsModule } from '@angular/forms';

import { MovieService } from '../../../core/services/movies.service';
import { EMPTY, Observable, catchError } from 'rxjs';
import { IDeleteMovie_send, IGetAllMovies_response } from '../../../core/models/movie.interface';

@Component({
  selector: 'app-crud-movies',
  standalone: true,
  imports: [
    AsyncPipe, 
    RouterOutlet, 
    FormsModule, 
    RouterModule
  ],
  templateUrl: './crud-movies.component.html',
  styleUrl: './crud-movies.component.css'
})
export class CrudMoviesComponent implements OnInit {
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
  
  delete(id: number) {
    const send: IDeleteMovie_send = { Id: id }
    this.serviceMovies.deleteMovie(send).subscribe(()=>{
      this.router.navigate(['admin'])
    },(error)=>{
      alert("error")
    })
  }
}