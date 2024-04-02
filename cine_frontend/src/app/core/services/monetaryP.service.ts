import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";

import { Host, Injectable } from "@angular/core";
import { RouterOutlet } from '@angular/router';
import { HOST } from "../const/const";
import { Iadd_monetary_response, Iadd_monetary_send, Idelete_monetary_send, Iget_monetary_response, Iget_monetary_send, Igetall_monetary_response, Iupdate_monetary_response, Iupdate_monetary_send } from "../models/monetaryP.interface";

@Injectable({ providedIn: 'root' })
export class MonetaryService {
    constructor(private http: HttpClient) { }

    add(send: Iadd_monetary_send): Observable<Iadd_monetary_response> {
        return this.http.post<Iadd_monetary_response>(HOST + '/monetarypurchase/add', send)
    }
    delete(send: Idelete_monetary_send) {
        return this.http.post(HOST + '/monetarypurchase/delete', send)
    }
    get(send: Iget_monetary_send): Observable<Iget_monetary_response> {
        return this.http.post<Iget_monetary_response>(HOST + '/monetarypurchase/get', send)  
    }
    getall(): Observable<Igetall_monetary_response> { 
        return this.http.get<Igetall_monetary_response>(HOST + '/monetarypurchase/getall')
    }
    update(send: Iupdate_monetary_send): Observable<Iupdate_monetary_response> {
        return this.http.post<Iupdate_monetary_response>(HOST + '/monetarypurchase/update', send)
    }
}