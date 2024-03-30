import { Routes } from "@angular/router";
import { CrudMoviesComponent } from "./crud-movies/crud-movies.component";
import { CreateMovieComponent } from "./create-movie/create-movie.component";
import { UpdateMovieComponent } from "./update-movie/update-movie.component";

export const CRUD_MOVIES_ROUTES: Routes = [
    {
        path: '',
        component: CrudMoviesComponent
    },
    {
        path: 'create',
        component: CreateMovieComponent
    },
    {
        path: 'update',
        component: UpdateMovieComponent
    }
]