import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";

import { Host, Injectable } from "@angular/core";
import { RouterOutlet } from '@angular/router';
import { HOST } from "../const/const";
import { IAddMovie_response, IAddMovie_send } from "../models/movie.interface";

@Injectable({ providedIn: 'root' })
export class MovieService {
    constructor(private http: HttpClient) { }

    addMovie(send: IAddMovie_send): Observable<IAddMovie_response> {
        return this.http.post<IAddMovie_response>(HOST + '/movies/add/', send);
    } 

    // TODO: HERE
}