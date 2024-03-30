import { AsyncPipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule, RouterOutlet } from '@angular/router';
import { EMPTY, Observable, catchError } from 'rxjs';
import { AdminService } from '../../../core/services/admin.service';
import { IGetAll_admin_response } from '../../../core/models/admin.interface';

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

  constructor(
    private serviceAdmin: AdminService
  ) { }
  ngOnInit(): void {
  }

  
}
