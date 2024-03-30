import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

import { HOST } from "../const/const";
import { IGetAllChairs_response, IGetChair_response, IGetChair_send } from "../models/chair.interface";

@Injectable({ providedIn: 'root' })
export class ChairService {
    constructor(private http: HttpClient) { }

    getChair(send: IGetChair_send): Observable<IGetChair_response> {
        return this.http.post<IGetChair_response>(HOST + '/chairs/get', send);
    }
    getAllChair(): Observable<IGetAllChairs_response> {
        return this.http.get<IGetAllChairs_response>(HOST + '/chairs/all')
    }
}