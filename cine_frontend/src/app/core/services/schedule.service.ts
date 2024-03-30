import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

import { HOST } from "../const/const";
import { Iadd_schedule_response, Iadd_schedule_send, Idelete_schedule_send, Iget_schedule_response, Iget_schedule_send, Igetall_schedule_response, Iupdate_schedule_response, Iupdate_schedule_send } from "../models/schedule.interface";

@Injectable({ providedIn: 'root' })
export class ScheduleService {
    constructor(private http: HttpClient) { }

    add(send: Iadd_schedule_send): Observable<Iadd_schedule_response> {
        return this.http.post<Iadd_schedule_response>(HOST + '/schedules/add', send);
    }
    delete(send: Idelete_schedule_send) {
        return this.http.post(HOST + '/schedules/delete', send)
    }
    get(send: Iget_schedule_send): Observable<Iget_schedule_response> {
        return this.http.post<Iget_schedule_response>(HOST + '/schedules/get', send)
    }
    getall(): Observable<Igetall_schedule_response> {
        return this.http.get<Igetall_schedule_response>(HOST + '/schedules/getall')
    }
    update(send: Iupdate_schedule_send): Observable<Iupdate_schedule_response> {
        return this.http.post<Iupdate_schedule_response>(HOST + '/schedules/update', send)
    }
}