export interface Igetall_showtime_response {
    showTimes: Igetall_showtime_response_aux[]
}
export interface Igetall_showtime_response_aux {
    id: number;
    halls: null;
    hallsId: number;
    schedules: null;
    schedulesId: number;
    cost: number;
    costPoints: number;
    movie: null;
    movieId: number;
}
export interface Iadd_showtime_send {
    HallsId: number;
    SchedulesId: number;
    Cost: number;
    CostPoints: number;
    MovieId: number;
}
export interface Iadd_showtime_response {
    id: number;
    hallsId: number;
    schedulesId: number;
    cost: number;
    costPoints: number;
    movieId: number;
}
export interface Idelete_showtime_send {
    Id: number;
}
export interface Iget_showtime_send {
    Id: number;
}
export interface Iget_showtime_response {
    id: number;
    hallsId: number;
    schedulesId: number;
    cost: number;
    costPoints: number;
    movieId: number;
}
export interface Iupdate_showtime_send {
    Id: number;
    HallsId: number;
    SchedulesId: number;
    Cost: number;
    CostPoints: number;
    MovieId: number;
}
export interface Iupdate_showtime_response {
    id: number;
    hallsId: number;
    schedulesId: number;
    cost: number;
    costPoints: number;
    movieId: number;
}