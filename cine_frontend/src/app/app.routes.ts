import { Routes } from '@angular/router';

import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { AboutComponent } from './about/about.component';
import { MoviesComponent } from './movies/movies.component';

export const routes: Routes = [
    { path: '', component: HomeComponent, }, 
    { path: 'login', component: LoginComponent },
    { path: 'about', component: AboutComponent }, 
    { path: 'movie', component: MoviesComponent },
];
