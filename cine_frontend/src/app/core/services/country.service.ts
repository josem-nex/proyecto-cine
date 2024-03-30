import { HttpClient } from "@angular/common/http";
import { EMPTY, Observable, catchError } from "rxjs";

import { Injectable } from "@angular/core";
import { RouterOutlet } from '@angular/router';
import { IAddCountry_send, IAddCountry_response, IGetAllCountries_response, IGetCountry_send, IGetCountry_response } from '../models/country.interface';
import { HOST } from "../const/const";

@Injectable({ providedIn: 'root' })
export class CountryService {
    constructor(private http: HttpClient) { }

    addCountry(send: IAddCountry_send): Observable<IAddCountry_response> {
        return this.http.post<IAddCountry_response>(HOST + "/countries/add", send)
    }
    getAllCountries(): Observable<IGetAllCountries_response> {
        return this.http.get<IGetAllCountries_response>(HOST + "/countries/all");
    }
    getCountryById(send: IGetCountry_send): Observable<IGetCountry_response> {
        return this.http.post<IGetCountry_response>(HOST + "/countries/get", send)
    }
}
