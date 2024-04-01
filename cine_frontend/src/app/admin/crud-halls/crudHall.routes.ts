import { Routes } from "@angular/router";
import { CreateHallComponent } from "./create-hall/create-hall.component";
import { UpdateHallComponent } from "./update-hall/update-hall.component";
import { CrudHallsComponent } from "./crud-halls/crud-halls.component";

export const CRUD_HALLS_ROUTES: Routes = [
    {
        path: '',
        component: CrudHallsComponent
    },
    {
        path: 'create',
        component: CreateHallComponent
    },
    {
        path: 'update/:id',
        component: UpdateHallComponent
    }
]