import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { Injectable } from "@angular/core";
import { RouterOutlet } from '@angular/router';

import { HOST } from "../const/const";
import { IDeletePartner_send, IGetAllPartners_response, IGetPartner_response, IGetPartner_send, ILogin_response, ILogin_send, IRegister_response, IRegister_send, IUpdatePartner_response, IUpdatePartner_send } from '../models/auth.interface';

@Injectable({ providedIn: 'root' })
export class AuthService {
    constructor(private http: HttpClient) { }

    getAllPartners(): Observable<IGetAllPartners_response> {
        return this.http.get<IGetAllPartners_response>(HOST + "/auth/Partners");
    }
    register(send: IRegister_send): Observable<IRegister_response> {
        return this.http.post<IRegister_response>(HOST + "/auth/register", send);
    }
    login(send: ILogin_send): Observable<ILogin_response> {
        return this.http.post<ILogin_response>(HOST + "/auth/login", send);
    }
    deletePartner(send: IDeletePartner_send) {
        return this.http.post(HOST + "/auth/delete", send);
    }
    updatePartner(send: IUpdatePartner_send): Observable<IUpdatePartner_response> {
        return this.http.post<IUpdatePartner_response>(HOST + "/auth/update", send);
    }
    getPartner(send: IGetPartner_send): Observable<IGetPartner_response> {
        return this.http.post<IGetPartner_response>(HOST + '/auth/get', send);
    }
}
