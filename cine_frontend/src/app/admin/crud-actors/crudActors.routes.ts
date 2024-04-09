import { Routes } from "@angular/router";
import { CrudActorsComponent } from "./crud-actors/crud-actors.component";

export const CRUD_ACTORS_ROUTES: Routes = [
    {
        path: '',
        component: CrudActorsComponent
    }
]