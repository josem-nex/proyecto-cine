import { Component, OnInit } from '@angular/core';
import { AsyncPipe } from '@angular/common';
import { RouterModule, RouterOutlet } from '@angular/router';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-crud-movies',
  standalone: true,
  imports: [AsyncPipe, RouterOutlet, FormsModule, RouterModule],
  templateUrl: './crud-movies.component.html',
  styleUrl: './crud-movies.component.css'
})
export class CrudMoviesComponent implements OnInit {

  constructor(
    ) { }

  ngOnInit(): void {
  } 
}