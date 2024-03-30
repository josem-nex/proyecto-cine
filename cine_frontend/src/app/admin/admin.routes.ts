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
        path: 'login',
        component: LoginAdminComponent
    }
]