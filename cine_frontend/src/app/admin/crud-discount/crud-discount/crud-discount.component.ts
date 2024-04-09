import { AsyncPipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterModule, RouterOutlet } from '@angular/router';
import { EMPTY, Observable, catchError } from 'rxjs';
import { IGetAllDiscounts_response } from '../../../core/models/discount.interface';
import { DiscountService } from '../../../core/services/discount.service';

@Component({
  selector: 'app-crud-discount',
  standalone: true,
  imports: [
    AsyncPipe,
    RouterOutlet,
    FormsModule,
    RouterModule
  ],
  templateUrl: './crud-discount.component.html',
  styleUrl: './crud-discount.component.css'
})
export class CrudDiscountComponent implements OnInit {
  discountsResponse!: Observable<IGetAllDiscounts_response> 

  constructor(
    private serviceDiscounts: DiscountService,
    private router: Router
  ) { }
  ngOnInit(): void {
    this.discountsResponse = this.serviceDiscounts.GetAllDiscounts().pipe(catchError((error:string)=> { return EMPTY }))
  }
}
