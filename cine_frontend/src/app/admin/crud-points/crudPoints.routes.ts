import { Routes } from "@angular/router";
import { CrudPointsComponent } from "./crud-points/crud-points.component";
import { CreatePointsComponent } from "./create-points/create-points.component";
import { UpdatePointsComponent } from "./update-points/update-points.component";

export const CRUD_POINTS_ROUTES: Routes = [
    {
        path: '',
        component: CrudPointsComponent
    },
    {
        path: 'create',
        component: CreatePointsComponent
    },
    {
        path: 'update/:id',
        component: UpdatePointsComponent
    }
]