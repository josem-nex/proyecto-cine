import { Routes } from "@angular/router";
import { CrudAdminComponent } from "./crud-admin/crud-admin.component";
import { CreateAdminComponent } from "./create-admin/create-admin.component";
import { UpdateAdminComponent } from "./update-admin/update-admin.component";

export const CRUD_ADMIN_ROUTES: Routes = [
    {
        path: '',
        component: CrudAdminComponent
    },
    {
        path: 'create',
        component: CreateAdminComponent
    },
    {
        path: 'update/:id',
        component: UpdateAdminComponent
    }
]