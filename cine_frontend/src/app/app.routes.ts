import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';

export const routes: Routes = [
    {
        path: 'auth',
        loadChildren: () => import('./auth/auth.routes').then(m => m.AUTH_ROUTES)
    },
    {
        path: 'admin',
        loadChildren: () => import('./admin/admin.routes').then(m => m.ADMIN_ROUTES)
    },
    {
        path: 'movies',
        loadChildren: () => import('./movies/movies.routes').then(m => m.MOVIES_ROUTES)
    },
    {
        path: '',
        component: HomeComponent
    }
]