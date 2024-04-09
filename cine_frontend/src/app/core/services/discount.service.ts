import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

import { HOST } from "../const/const";
import { IGetAllDiscounts_response, IGetDiscount_response, IGetDiscount_send } from '../models/discount.interface';

@Injectable({ providedIn: 'root' })
export class DiscountService {
    constructor(private http: HttpClient) { }

    GetAllDiscounts(): Observable<IGetAllDiscounts_response> {
        return this.http.get<IGetAllDiscounts_response>(HOST + '/discounts/all')
    }
    GetDiscount(send: IGetDiscount_send): Observable<IGetDiscount_response> {
        return this.http.post<IGetDiscount_response>(HOST + '/discounts/get', send)
    } 
}