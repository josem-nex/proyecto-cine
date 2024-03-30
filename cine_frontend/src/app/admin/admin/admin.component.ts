import { Component, OnInit } from '@angular/core';
import { Router, RouterModule, RouterOutlet } from '@angular/router';
import { FormsModule } from '@angular/forms';

import { LocalStorageService } from '../../core/services/local.service';
import { AuxiliarService } from '../../core/services/auxiliar.service';
import { AdminService } from '../../core/services/admin.service';
import { ILogin_admin_send } from '../../core/models/admin.interface';

@Component({
  selector: 'app-admin',
  standalone: true,
  imports: [
    RouterOutlet, 
    FormsModule, 
    RouterModule
  ],
  templateUrl: './admin.component.html',
  styleUrl: './admin.component.css'
})
export class AdminComponent implements OnInit {
  send: ILogin_admin_send = {
    User: '',
    Password: ''
  }

  constructor(
    public local: LocalStorageService,
    private serviceAdmin: AdminService, 
    private router: Router,
    private auxiliar: AuxiliarService
  ) { }
  ngOnInit(): void {
    
  }

}
