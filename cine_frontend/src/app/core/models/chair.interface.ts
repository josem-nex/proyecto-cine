export interface IGetAllChairs_response {
    chairs: IGetAllChairs_response_aux[]
}
export interface IGetAllChairs_response_aux {
    id: number;
    row: number;
    column: number;
    hall: null;
    hallId: number;
}
export interface IGetChair_send {
    Id: number;
}
export interface IGetChair_response {
    id: number;
    row: number;
    column: number;
    hallId: number;
}
