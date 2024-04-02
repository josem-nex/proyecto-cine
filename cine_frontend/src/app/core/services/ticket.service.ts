import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

import { HOST } from "../const/const";
import { Iadd_ticket_response, Iadd_ticket_send, Idelete_ticket_send, Iget_ticket_response, Iget_ticket_send, Igetall_ticket_response, Iupdate_ticket_response, Iupdate_ticket_send } from "../models/ticket.interface";

@Injectable({ providedIn: 'root' })
export class TicketService {
    constructor(private http: HttpClient) { }

    add(send: Iadd_ticket_send): Observable<Iadd_ticket_response> {
        return this.http.post<Iadd_ticket_response>(HOST + '/tickets/add', send)
    }
    delete(send: Idelete_ticket_send) {
        return this.http.post(HOST + '/tickets/delete', send)
    }   
    get(send: Iget_ticket_send): Observable<Iget_ticket_response> {
        return this.http.post<Iget_ticket_response>(HOST + '/tickets/get', send)
    }
    update(send: Iupdate_ticket_send): Observable<Iupdate_ticket_response> {
        return this.http.post<Iupdate_ticket_response>(HOST + '/tickets/update', send)
    }
    getall(): Observable<Igetall_ticket_response> {
        return this.http.get<Igetall_ticket_response>(HOST + '/tickets/getall')
    }
}
