import { Routes } from "@angular/router";
import { CrudScheduleComponent } from "./crud-schedule/crud-schedule.component";
import { CreateScheduleComponent } from "./create-schedule/create-schedule.component";
import { UpdateScheduleComponent } from "./update-schedule/update-schedule.component";

export const CRUD_SCHEDULE_ROUTES: Routes = [
    {
        path: '',
        component: CrudScheduleComponent
    }, 
    {
        path: 'create',
        component: CreateScheduleComponent
    }, 
    {
        path: 'update/:id',
        component: UpdateScheduleComponent
    }
]