import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router, RouterModule, RouterOutlet } from '@angular/router';
import { IGetMovie_response, IGetMovie_send, IUpdateMovie_send } from '../../../core/models/movie.interface';
import { MovieService } from '../../../core/services/movies.service';

@Component({
  selector: 'app-update-movie',
  standalone: true,
  imports: [
    RouterOutlet,
    FormsModule,
    RouterModule
  ],
  templateUrl: './update-movie.component.html',
  styleUrl: './update-movie.component.css'
})
export class UpdateMovieComponent implements OnInit {
  index!: number;
  send: IUpdateMovie_send = {
    id: 0,
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
    private serviceMovie: MovieService,
    private route: ActivatedRoute,
    private router: Router
  ) { }
  ngOnInit(): void {
    this.index = this.route.snapshot.params['id'];
    const send: IGetMovie_send = {
      movieId: this.index
    }
    this.serviceMovie.getMovie(send).subscribe((value:IGetMovie_response)=>{
      this.send.id = send.movieId
      this.send.title = value.title
      this.send.description = value.description
      this.send.director = value.director
      this.send.countryid = value.countryId
      this.send.language = value.language
      this.send.durationminutes = value.durationMinutes
      this.send.imageurl = value.imageUrl
    },(error)=>{
      alert(error)
      this.router.navigate(['admin/movies/'])
    })
  }

  update() {
    this.send.idactors = this.actorsIdText.split(',').map(m=>parseInt(m,10))
    this.send.idgenres = this.genresIdText.split(',').map(m=>parseInt(m,10))

    this.serviceMovie.updateMovie(this.send).subscribe((values)=>{
      alert("Actualizacion hecha con exito")
    },(error)=>{
      alert(error)
    })
    this.router.navigate(['admin'])
  }
  cancel() {
    this.router.navigate(['admin/movies/'])
  }


}
