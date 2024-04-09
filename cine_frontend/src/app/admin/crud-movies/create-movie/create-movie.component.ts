import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterModule, RouterOutlet } from '@angular/router';

import { IAddMovie_send, IDeleteMovie_send, IGetAllMovies_response } from '../../../core/models/movie.interface';
import { MovieService } from '../../../core/services/movies.service';

@Component({
  selector: 'app-create-movie',
  standalone: true,
  imports: [
    RouterOutlet,
    FormsModule,
    RouterModule
  ],
  templateUrl: './create-movie.component.html',
  styleUrl: './create-movie.component.css'
})
export class CreateMovieComponent implements OnInit {
  send: IAddMovie_send = {
    title: '',
    description: '',
    director: '',
    imageurl: '',
    durationminutes: 0,
    releasedate: new Date,
    language: '',
    rating: 0,
    idactors: [],
    idgenres: [],
    countryid: 0
  }
  actorsIdText!: string;
  genresIdText!: string;

  constructor(
    private serviceMovies: MovieService,
    private router: Router
  ) { } 
  ngOnInit(): void { }

  create() {
    this.send.idactors = this.actorsIdText.split(',').map(m=>parseInt(m,10))
    this.send.idgenres = this.genresIdText.split(',').map(m=>parseInt(m,10))

    this.serviceMovies.addMovie(this.send).subscribe(()=>{
      alert("Movie creada con éxito")
      this.router.navigate(['admin/movies/'])
    },(error)=>{
      alert(error)
    })
  }
  cancel() {
    this.router.navigate(['admin/movies/'])
  }

}
