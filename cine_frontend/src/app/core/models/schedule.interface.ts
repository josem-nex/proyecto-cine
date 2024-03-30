export interface Igetall_schedule_response {
    schedules: Igetall_schedule_response_aux[]
}
export interface Igetall_schedule_response_aux { 
    id: number; 
    dateStart: Date;
    dateEnd: Date;
    halls: number[]
}

export interface Iadd_schedule_send {
    DateStart: Date;
    DateEnd: Date;
}
export interface Iadd_schedule_response {
    id: number;
    dateStart: Date;
    dateEnd: Date;    
}
export interface Idelete_schedule_response {
    Id: number;
}
export interface Iget_schedule_send {
    Id: number;
}
export interface Iget_schedule_response {
    id: number;
    dateStart: Date;
    dateEnd: Date;
}
export interface Iupdate_schedule_send {
    Id: number;
    DateStart: Date;
    DateEnd: Date;
}
export interface Iupdate_schedule_response {
    id: number;
    dateStart: Date;
    dateEnd: Date;
}