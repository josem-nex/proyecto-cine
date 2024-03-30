export interface IGetAllGenres_response {
    genres: IGetAllGenres_response_aux[]
}
export interface IGetAllGenres_response_aux {
    id: number;
    string: string;
    movies: []
}

export interface IGetGenre_send {
    Id: number;
}
export interface IGetGenre_response {
    id: number;
    name: string;
}