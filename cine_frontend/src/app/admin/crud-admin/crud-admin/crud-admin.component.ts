import { AsyncPipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterModule, RouterOutlet } from '@angular/router';
import { EMPTY, Observable, catchError } from 'rxjs';

import { AdminService } from '../../../core/services/admin.service';
import { IDelete_admin_send, IGetAll_admin_response } from '../../../core/models/admin.interface';

@Component({
  selector: 'app-crud-admin',
  standalone: true,
  imports: [
    AsyncPipe, 
    RouterOutlet,
    FormsModule, 
    RouterModule
  ],
  templateUrl: './crud-admin.component.html',
  styleUrl: './crud-admin.component.css'
})
export class CrudAdminComponent implements OnInit {
  adminResponse!: Observable<IGetAll_admin_response>

  constructor(
    private serviceAdmin: AdminService,
    private router: Router
  ) { }
  ngOnInit(): void {
    this.adminResponse = this.serviceAdmin.GetAll().pipe(catchError((error: string) => { return EMPTY }))
  }

  delete(id: string) {
    const send: IDelete_admin_send = { id: id }
    this.serviceAdmin.Delete(send).subscribe(()=>{
      alert("Eliminación con éxito")
      this.router.navigate(['admin'])
    },(error)=>{
      alert("error");
    })
  } 
}
