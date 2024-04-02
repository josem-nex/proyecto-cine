import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

import { HOST } from "../const/const";
import { Iadd_points_response, Iadd_points_send, Idelete_points_send, Iget_points_response, Iget_points_send, Igetall_points_response, Iupdate_points_response, Iupdate_points_send } from "../models/pointsP.interface";


@Injectable({ providedIn: 'root' })
export class PointsService {
    constructor(private http: HttpClient) { }

    add(send: Iadd_points_send): Observable<Iadd_points_response> {
        return this.http.post<Iadd_points_response>(HOST + '/pointspurchase/add', send)
    }
    delete(send: Idelete_points_send) { 
        return this.http.post<Idelete_points_send>(HOST + '/pointspurchase/delete', send)
    }
    get(send: Iget_points_send): Observable<Iget_points_response> { 
        return this.http.post<Iget_points_response>(HOST + '/pointspurchase/get', send)
    }
    getall(): Observable<Igetall_points_response> { 
        return this.http.get<Igetall_points_response>(HOST + '/pointspurchase/getall')
    }
    update(send: Iupdate_points_send): Observable<Iupdate_points_response> { 
        return this.http.post<Iupdate_points_response>(HOST + '/pointspurchase/update', send)
    }

}