import { Routes } from '@angular/router';
import { AdminComponent } from './admin/admin.component';
import { LoginAdminComponent } from './login/login.component';

export const ADMIN_ROUTES: Routes = [
    { 
        path: '', 
        component: AdminComponent 
    }, 
    {
        path: 'movies', 
        loadChildren: () => import('./crud-movies/crudMovie.routes').then(m => m.CRUD_MOVIES_ROUTES)
    },
    {
        path: 'halls',
        loadChildren: () => import('./crud-halls/crudHall.routes').then(m => m.CRUD_HALLS_ROUTES)
    },
    {
        path: 'partners',
        loadChildren: () => import('./crud-partners/crudPartner.routes').then(m => m.CRUD_PARTNERS_ROUTES)
    }, 
    {
        path: 'admin',
        loadChildren: () => import('./crud-admin/crudAdmin.routes').then(m => m.CRUD_ADMIN_ROUTES)
    },
    {
        path: 'actors',
        loadChildren: () => import('./crud-actors/crudActors.routes').then(m => m.CRUD_ACTORS_ROUTES)
    },
    {
        path: 'chairs',
        loadChildren: () => import('./crud-chairs/crudChairs.routes').then(m => m.CRUD_CHAIRS_ROUTES)
    },
    {
        path: 'country',
        loadChildren: () => import('./crud-country/crudCountry.routes').then(m => m.CRUD_COUNTRY_ROUTES)
    },
    {
        path: 'discounts',
        loadChildren: () => import('./crud-discount/crudDiscount.routes').then(m => m.CRUD_DISCOUNT_ROUTES)
    },
    {
        path: 'genres',
        loadChildren: () => import('./crud-genre/crudGenre.routes').then(m => m.CRUD_GENRE_ROUTES)
    },
    {
        path: 'schedule',
        loadChildren: () => import('./crud-schedule/crudSchedule.routes').then(m => m.CRUD_SCHEDULE_ROUTES)
    },
    {
        path: 'login',
        component: LoginAdminComponent
    }
]