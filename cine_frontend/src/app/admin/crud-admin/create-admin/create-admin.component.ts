import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterModule, RouterOutlet } from '@angular/router';

import { IAdd_admin_send } from '../../../core/models/admin.interface';
import { AdminService } from '../../../core/services/admin.service';

@Component({
  selector: 'app-create-admin',
  standalone: true,
  imports: [
    RouterOutlet,
    FormsModule,
    RouterModule
  ],
  templateUrl: './create-admin.component.html',
  styleUrl: './create-admin.component.css'
})
export class CreateAdminComponent implements OnInit {
  send: IAdd_admin_send = {
    User: '',
    Password: ''
  }

  constructor(
    private serviceAdmin: AdminService,
    private router: Router
  ) { }
  ngOnInit(): void { }
  
  create() {
    this.serviceAdmin.Add(this.send).subscribe(()=>{
      alert("Admin creado con exito")
      this.router.navigate(['admin/admin/'])
    },(error)=>{
      alert(error)
    })
  }
  cancel() {
    this.router.navigate(['admin/admin/'])
  }

}
