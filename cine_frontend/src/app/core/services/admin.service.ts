import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { Injectable } from "@angular/core";
import { RouterOutlet } from '@angular/router';

import { HOST } from "../const/const";
import { IAdd_admin_response, IAdd_admin_send, IDelete_admin_send, IGetAll_admin_response, IGet_admin_response, IGet_admin_send, ILogin_admin_response, ILogin_admin_send, IUpdate_admin_response, IUpdate_admin_send } from "../models/admin.interface";

@Injectable({ providedIn: 'root' })
export class AdminService {
    constructor(private http: HttpClient) { }

    Add(send: IAdd_admin_send): Observable<IAdd_admin_response> {
        return this.http.post<IAdd_admin_response>(HOST + "/admin/add", send);
    }
    Delete(send: IDelete_admin_send) {
        return this.http.post(HOST + '/admin/delete', send);
    }
    Get(send: IGet_admin_send): Observable<IGet_admin_response> {
        return this.http.post<IGet_admin_response>(HOST + '/admin/get', send)
    }
    GetAll(): Observable<IGetAll_admin_response> {
        return this.http.get<IGetAll_admin_response>(HOST + '/admin/all')
    }
    Login(send: ILogin_admin_send): Observable<ILogin_admin_response> {
        return this.http.post<ILogin_admin_response>(HOST + '/admin/login', send);
    }
    Update(send: IUpdate_admin_send): Observable<IUpdate_admin_response> {
        return this.http.post<IUpdate_admin_response>(HOST + '/admin/update', send)
    }
}
