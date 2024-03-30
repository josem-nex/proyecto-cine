import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

import { HOST } from "../const/const";
import { Iadd_showtime_response, Iadd_showtime_send, Idelete_showtime_send, Iget_showtime_response, Iget_showtime_send, Igetall_showtime_response, Iupdate_showtime_response, Iupdate_showtime_send } from "../models/showtime.interface";

@Injectable({ providedIn: 'root' })
export class ShowTimeService {
    constructor(private http: HttpClient) { }

    add(send: Iadd_showtime_send): Observable<Iadd_showtime_response> {
        return this.http.post<Iadd_showtime_response>(HOST + '/showtimes/add', send)
    }
    delete(send: Idelete_showtime_send) {
        return this.http.post(HOST + '/showtimes/delete', send)
    }
    get(send: Iget_showtime_send): Observable<Iget_showtime_response> {
        return this.http.post<Iget_showtime_response>(HOST + '/showtimes/get', send)
    }
    getall(): Observable<Igetall_showtime_response> {
        return this.http.get<Igetall_showtime_response>(HOST + '/showtimes/getall')
    }
    update(send: Iupdate_showtime_send): Observable<Iupdate_showtime_response> {
        return this.http.post<Iupdate_showtime_response>(HOST + '', send);
    }
}