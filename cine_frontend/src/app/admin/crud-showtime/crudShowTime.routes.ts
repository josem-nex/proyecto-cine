import { Routes } from "@angular/router";
import { CrudShowtimeComponent } from "./crud-showtime/crud-showtime.component";
import { CreateShowtimeComponent } from "./create-showtime/create-showtime.component";
import { UpdateShowtimeComponent } from "./update-showtime/update-showtime.component";

export const CRUD_SHOWTIME_ROUTES: Routes = [
    {
        path: '',
        component: CrudShowtimeComponent
    }, 
    {
        path: 'create',
        component: CreateShowtimeComponent
    },
    {
        path: 'update/:id',
        component: UpdateShowtimeComponent
    }
]