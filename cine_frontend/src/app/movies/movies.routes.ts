
import { Routes } from "@angular/router";
import { ItemMovieComponent } from "./item-movie/item-movie.component";
import { ListMovieComponent } from "./list-movie/list-movie.component";

export const MOVIES_ROUTES: Routes = [
    { path: '', component: ListMovieComponent },
    { path: 'item/:id', component: ItemMovieComponent }
];