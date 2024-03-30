export interface Igetall_hall_response {
    halls: Igetall_hall_response_aux[]
}
export interface Igetall_hall_response_aux {
    id: number;
    name: string;
    capacity: number;

    chairs: [];
    schedules: null;
}
export interface Iadd_hall_send {
    Name: string;
    Capacity: number;
    SchedulesId: number[];
}
export interface Idelete_hall_send {
    Id: number;
}
export interface Iget_hall_send {
    Id: number;
}
export interface Iget_hall_response {
    id: number;
    name: string;
    capacity: number;
}
export interface Iupdate_hall_send {
    Id: number;
    Name: string;
    Capacity: number;
    SchedulesId: number[];
}