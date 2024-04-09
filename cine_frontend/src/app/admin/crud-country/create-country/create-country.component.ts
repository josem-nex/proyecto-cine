import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterModule, RouterOutlet } from '@angular/router';
import { IAddCountry_send } from '../../../core/models/country.interface';
import { CountryService } from '../../../core/services/country.service';

@Component({
  selector: 'app-create-country',
  standalone: true,
  imports: [
    RouterOutlet,
    FormsModule,
    RouterModule
  ],
  templateUrl: './create-country.component.html',
  styleUrl: './create-country.component.css'
})
export class CreateCountryComponent implements OnInit {
  send: IAddCountry_send = {
    name: ''
  }

  constructor(
    private serviceCountry: CountryService,
    private router: Router
  ) { }
  ngOnInit(): void { }

  create() { 
    this.serviceCountry.addCountry(this.send).subscribe(()=>{
      alert("Country creado con éxito")
      this.router.navigate(['admin/country'])
    },(error)=>{
      alert(error)
    })
  }
  cancel() { 
    this.router.navigate(['admin/country'])
  }
}
