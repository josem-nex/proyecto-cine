import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

import { HOST } from "../const/const";

@Injectable({ providedIn: 'root' })
export class ShowTimeService {
    constructor(private http: HttpClient) { }
}