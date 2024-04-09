import { Routes } from "@angular/router";
import { CrudCountryComponent } from "./crud-country/crud-country.component";
import { CreateCountryComponent } from "./create-country/create-country.component";

export const CRUD_COUNTRY_ROUTES: Routes = [
    {
        path: '',
        component: CrudCountryComponent
    }, 
    {
        path: 'create',
        component: CreateCountryComponent
    }
]