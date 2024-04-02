import { Routes } from "@angular/router";
import { CrudMonetaryComponent } from "./crud-monetary/crud-monetary.component";
import { CreateMonetaryComponent } from "./create-monetary/create-monetary.component";
import { UpdateMonetaryComponent } from "./update-monetary/update-monetary.component";

export const CRUD_MONETARY_ROUTES: Routes = [
    {
        path: '',
        component: CrudMonetaryComponent
    },
    {
        path: 'create',
        component: CreateMonetaryComponent
    },
    {
        path: 'update/:id',
        component: UpdateMonetaryComponent
    }
]