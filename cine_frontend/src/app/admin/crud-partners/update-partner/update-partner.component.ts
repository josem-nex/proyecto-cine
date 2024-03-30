import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { AuthService } from '../../../core/services/auth.service';

@Component({
  selector: 'app-update-partner',
  standalone: true,
  imports: [],
  templateUrl: './update-partner.component.html',
  styleUrl: './update-partner.component.css'
})
export class UpdatePartnerComponent implements OnInit {
  constructor(
    private serviceAuth: AuthService,
    private route: ActivatedRoute,
    private router: Router
    ) { }
  ngOnInit(): void {
    this.index = this.route.snapshot.params['id'];
  }

  index!: number;

  update() {

  }
  cancel() {
    this.router.navigate(['admin/partners/'])
  }
}
