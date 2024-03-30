import { Routes } from "@angular/router";
import { CrudPartnersComponent } from "./crud-partners/crud-partners.component";
import { CreatePartnerComponent } from "./create-partner/create-partner.component";
import { UpdatePartnerComponent } from "./update-partner/update-partner.component";

export const CRUD_PARTNERS_ROUTES: Routes = [
    {
        path: '',
        component: CrudPartnersComponent
    },
    {
        path: 'create',
        component: CreatePartnerComponent
    },
    {
        path: 'update/:id',
        component: UpdatePartnerComponent
    }
]