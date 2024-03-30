import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

import { HOST } from "../const/const";
import { IGetActor_response, IGetActor_send, IGetAllActors_response } from "../models/actor.interface";

@Injectable({ providedIn: 'root' })
export class ActorService {
    constructor(private http: HttpClient) { }

    getActor(send: IGetActor_send): Observable<IGetActor_response> {
        return this.http.post<IGetActor_response>(HOST + '/actors/get', send);
    }
    getAllActors(): Observable<IGetAllActors_response> {
        return this.http.get<IGetAllActors_response>(HOST + '/actors/all');
    }
}
