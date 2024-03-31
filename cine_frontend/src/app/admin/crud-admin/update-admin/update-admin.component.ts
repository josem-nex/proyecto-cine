import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router, RouterModule, RouterOutlet } from '@angular/router';
import { IGet_admin_response, IGet_admin_send, IUpdate_admin_send } from '../../../core/models/admin.interface';
import { AdminService } from '../../../core/services/admin.service';

@Component({
  selector: 'app-update-admin',
  standalone: true,
  imports: [
    RouterOutlet,
    FormsModule,
    RouterModule
  ],
  templateUrl: './update-admin.component.html',
  styleUrl: './update-admin.component.css'
})
export class UpdateAdminComponent implements OnInit {
  index!: string;
  send: IUpdate_admin_send = {
    id: '',
    user: '',
    password: ''
  }
  
  constructor(
    private serviceAdmin: AdminService, 
    private route: ActivatedRoute,
    private router: Router
  ) { } 
  ngOnInit(): void {
    this.index = this.route.snapshot.params['id'];
    const send: IGet_admin_send = {
      id: this.index
    }
    this.serviceAdmin.Get(send).subscribe((value:IGet_admin_response)=>{
      this.send.id = send.id
      this.send.user = value.user
    },(error)=>{
      alert(error)
      this.router.navigate(['admin/admin/'])
    })
  }

  update() { 
    this.serviceAdmin.Update(this.send).subscribe((values)=>{
      alert("Actualizacion hecha con exito")
    },(error)=>{
      alert(error)
    })
    this.router.navigate(['admin'])
  }
  cancel() { 
    this.router.navigate(['admin/admin/'])
  }

}
