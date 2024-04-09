import { AsyncPipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterModule, RouterOutlet } from '@angular/router';
import { EMPTY, Observable, catchError } from 'rxjs';
import { IGetAllCountries_response } from '../../../core/models/country.interface';
import { CountryService } from '../../../core/services/country.service';

@Component({
  selector: 'app-crud-country',
  standalone: true,
  imports: [
    AsyncPipe,
    RouterOutlet,
    FormsModule,
    RouterModule
  ],
  templateUrl: './crud-country.component.html',
  styleUrl: './crud-country.component.css'
})
export class CrudCountryComponent implements OnInit {
  countryResponse!: Observable<IGetAllCountries_response> 

  constructor(
    private serviceCountry: CountryService,
    private router: Router
  ) { }
  ngOnInit(): void {
    this.countryResponse = this.serviceCountry.getAllCountries().pipe(catchError((error:string)=>{ return EMPTY }))
  }
}
