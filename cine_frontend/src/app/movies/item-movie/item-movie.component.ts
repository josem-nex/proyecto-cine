import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router, RouterModule, RouterOutlet } from '@angular/router';
import { MovieService } from '../../core/services/movies.service';
import { IGetMovie_response, IGetMovie_send, IGetshowtimemovie_response, IGetshowtimemovie_send } from '../../core/models/movie.interface';
import { EMPTY, Observable, catchError, retry } from 'rxjs';
import { AsyncPipe } from '@angular/common';
import { ShowTimeService } from '../../core/services/showtime.service';
import { Iget_showtime_response } from '../../core/models/showtime.interface';
import { MonetaryService } from '../../core/services/monetaryP.service';
import { PointsService } from '../../core/services/pointsP.service';
import { Iadd_monetary_send } from '../../core/models/monetaryP.interface';
import { TicketService } from '../../core/services/ticket.service';
import { Igetall_ticket_response } from '../../core/models/ticket.interface';
import { ILogin_response, ILogin_send } from '../../core/models/auth.interface';
import { AuthService } from '../../core/services/auth.service';
import { Iadd_points_send } from '../../core/models/pointsP.interface';
import { LocalStorageService } from '../../core/services/local.service';

@Component({
  selector: 'app-item-movie',
  standalone: true,
  imports: [
    RouterOutlet,
    FormsModule,
    RouterModule,
    AsyncPipe
  ],
  templateUrl: './item-movie.component.html',
  styleUrl: './item-movie.component.css'
})
export class ItemMovieComponent implements OnInit {
  index!: number;

  send: ILogin_send = {
    email: '',
    password: ''
  } 

  responseMovie!: Observable<IGetMovie_response>
  responseShowtime!: Observable<IGetshowtimemovie_response> 

  responseTickets!: Observable<Igetall_ticket_response>

  phaseOne!: boolean
  phaseTwo!: boolean
  phaseThree!: boolean

  showtimesIdsText!: string
  showtimesIds!: number[];

  constructor(
    private serviceMovie: MovieService,
    public serviceLocal: LocalStorageService,
    private serviceShowtime: ShowTimeService,
    private serviceTickets: TicketService,
    private serviceMonetary: MonetaryService,
    private servicePoints: PointsService,
    private serviceAuth: AuthService,
    private route: ActivatedRoute,
    private router: Router
  ) { }
  ngOnInit(): void {
    this.index = this.route.snapshot.params['id'];
    const send: IGetMovie_send = { movieId: this.index }
    const sendShowtime: IGetshowtimemovie_send = { Id: this.index }

    this.responseTickets = this.serviceTickets.getall().pipe(catchError((error:string)=>{
      this.router.navigate(['movies'])
      alert(error)
      return EMPTY
    }))

    this.responseShowtime = this.serviceMovie.getShowtimeMovie(sendShowtime).pipe(catchError((error:string)=>{
      this.router.navigate(['movies'])
      alert(error)
      return EMPTY
    }))
    this.responseMovie = this.serviceMovie.getMovie(send).pipe(catchError((error:string)=>{
      this.router.navigate(['movies'])
      alert(error)
      return EMPTY
    }))

    this.phaseOne = true
    this.phaseTwo = false
    this.phaseThree = false
  }
  
  change() {
    this.showtimesIds = this.showtimesIdsText.split(',').map(m=>parseInt(m,10))

    this.phaseOne = false
    this.phaseTwo = true
    this.phaseThree = false
  }

  ok_monetary() { 
    for (let i = 0; i < this.showtimesIds.length; i++) {
      let tmp = this.showtimesIds[i];
      const send_points: Iadd_monetary_send = {
        UserID: this.userId,
        TicketId: tmp.toString(),
        TotalPrice: '20',
        CreditCard: '12345678'
      }
      console.log(send_points)
      this.serviceMonetary.add(send_points).subscribe(()=>{
        alert("El ticket " + tmp + " fue comprado con éxito con dinero")
      },(error:string)=>{
        console.log("No se ha podido comprar el ticket")
      })
    }  
    this.router.navigate(['']) 
  }
  ok_points() { 
    for (let i = 0; i < this.showtimesIds.length; i++) {
      let tmp = this.showtimesIds[i];
      const send_points: Iadd_points_send = {
        UserID: this.userId,
        TicketId: tmp.toString(),
        TotalPoints: '200'
      }
      console.log(send_points)
      this.servicePoints.add(send_points).subscribe(()=>{
        alert("El ticket " + tmp + " fue comprado con éxito con puntos")
      },(error:string)=>{
        console.log("No se ha podido comprar el ticket")
      })
    }  
    this.router.navigate(['']) 
  }
  
  continuar() {
    this.phaseOne = false
    this.phaseTwo = false
    this.phaseThree = true

    this.serviceAuth.login(this.send).subscribe((values:ILogin_response)=>{
      this.userId = values.id
    },(error:string)=>{
      alert(error)
      this.router.navigate([''])  
    })
  }

  cancel() { 
    this.router.navigate([''])
  }
  userId!: string;
}
