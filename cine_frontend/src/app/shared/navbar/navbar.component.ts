import { Component, OnInit } from '@angular/core';
import { LocalStorageService } from '../../core/services/local.service';
import { AuxiliarService } from '../../core/services/auxiliar.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent implements OnInit {
  constructor(
    public service: LocalStorageService,
    private router: Router, 
    private auxiliar: AuxiliarService
    ) { }
  ngOnInit(): void { 
  }
  desconnect() {
    this.service.setItem("isUser", "false")
    //this.service.setItem("isAdmin", "false")
    this.router.navigate([''])
  }

}
