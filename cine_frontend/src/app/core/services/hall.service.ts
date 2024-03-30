import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

import { HOST } from "../const/const";
import { Iadd_hall_send, Idelete_hall_send, Iget_hall_response, Iget_hall_send, Igetall_hall_response, Iupdate_hall_send } from "../models/hall.interface";

@Injectable({ providedIn: 'root' })
export class HallService {
    constructor(private http: HttpClient) { }

    add(send: Iadd_hall_send) {
        return this.http.post(HOST + '/halls/add', send);
    }
    delete(send: Idelete_hall_send) {
        return this.http.post(HOST + '/halls/delete', send);
    }
    get(send: Iget_hall_send): Observable<Iget_hall_response> {
        return this.http.post<Iget_hall_response>(HOST + '/halls/get', send)
    }
    getall(): Observable<Igetall_hall_response> {
        return this.http.get<Igetall_hall_response>(HOST + '/halls/getall');
    }
    update(send: Iupdate_hall_send) {
        return this.http.post(HOST + '/halls/update', send);
    }
}
