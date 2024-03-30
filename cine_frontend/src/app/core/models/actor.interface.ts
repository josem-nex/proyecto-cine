// Send
export interface IGetActor_send {
    Id: number;
}
// Response
export interface IGetActor_response {
    id: number;
    name: string;
}
export interface IGetAllActors_response {
    actors: IGetAllActors_response_aux[]
}
export interface IGetAllActors_response_aux {
    id: number;
    name: string;
    movies: number[];
}
