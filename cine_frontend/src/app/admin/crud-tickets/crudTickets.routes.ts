import { Routes } from "@angular/router";
import { CrudTicketsComponent } from "./crud-tickets/crud-tickets.component";
import { CreateTicketsComponent } from "./create-tickets/create-tickets.component";
import { UpdateTicketsComponent } from "./update-tickets/update-tickets.component";

export const CRUD_TICKETS_ROUTES: Routes = [
    {
        path: '',
        component: CrudTicketsComponent
    },
    {
        path: 'create',
        component: CreateTicketsComponent
    },
    {
        path: 'update/:id',
        component: UpdateTicketsComponent
    },
]