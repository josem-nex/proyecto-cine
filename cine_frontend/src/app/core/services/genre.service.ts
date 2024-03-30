import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

import { HOST } from "../const/const";
import { IGetAllGenres_response, IGetGenre_response, IGetGenre_send } from "../models/genre.interface";

@Injectable({ providedIn: 'root' })
export class GenreService {
    constructor(private http: HttpClient) { }

    getAllGenres(): Observable<IGetAllGenres_response> {
        return this.http.get<IGetAllGenres_response>(HOST + '/genres/all')
    }
    getGenre(send: IGetGenre_send): Observable<IGetGenre_response> {
        return this.http.post<IGetGenre_response>(HOST + '/genres/get', send);
    }
}