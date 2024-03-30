import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";

import { Host, Injectable } from "@angular/core";
import { RouterOutlet } from '@angular/router';
import { HOST } from "../const/const";
import { IAddMovie_response, IAddMovie_send, IDeleteMovie_send, IGetAllMovies_response, IGetMovie_response, IGetMovie_send, IUpdateMovie_response, IUpdateMovie_send } from "../models/movie.interface";

@Injectable({ providedIn: 'root' })
export class MovieService {
    constructor(private http: HttpClient) { }

    addMovie(send: IAddMovie_send): Observable<IAddMovie_response> {
        return this.http.post<IAddMovie_response>(HOST + '/movies/add/', send);
    } 
    deleteMovie(send: IDeleteMovie_send) {
        return this.http.post(HOST + '/movies/delete', send);
    }
    getAllMovies(): Observable<IGetAllMovies_response> {
        return this.http.get<IGetAllMovies_response>(HOST + '/movies/getall')
    }
    getMovie(send: IGetMovie_send): Observable<IGetMovie_response> {
        return this.http.post<IGetMovie_response>(HOST + '/movies/get', send)
    }
    updateMovie(send: IUpdateMovie_send): Observable<IUpdateMovie_response> {
        return this.http.post<IUpdateMovie_response>(HOST + '/movies/update', send)
    }
}