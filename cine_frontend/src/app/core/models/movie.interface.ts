export interface IGetAllMovies_response {
    movies: IGetAllMovies_response_aux[]
}
export interface IGetAllMovies_response_aux {
    id: number;
    title: string;
    description: string;
    director: string;
    imageUrl: string;
    durationMinutes: number;
    releaseDate: Date;
    language: string;
    rating: number;
    actors: number[];
    genres: number[];
    country: null;
    countryId: number;
    showTimes: number[];
}
export interface IAddMovie_send {
    title: string;
    description: string;
    director: string;
    imageurl: string;
    durationminutes: number;
    releasedate: Date;
    language: string;
    rating: number;
    idactors: number[];
    idgenres: number[];
    countryid: number;
}
export interface IAddMovie_response {
    id: number;
    title: string;
    description: string;
    director: string;
    imageUrl: string;
    durationMinutes: number;
    releaseDate: Date;
    language: string;
    rating: number;
    countryId: number;
}
export interface IDeleteMovie_send {
    Id: number;
}
export interface IGetMovie_send {
    movieId: number;
}
export interface IGetMovie_response {
    id: number;
    title: string;
    description: string;
    director: string;
    imageUrl: string;
    durationMinutes: number;
    releaseDate: Date
    language: string;
    rating: number;
    countryId: number;
}
export interface IUpdateMovie_send {
    id: number;    
    title: string;
    description: string;
    director: string;
    imageurl: string;
    durationminutes: number;
    releasedate: Date;
    language: string;
    rating: number;
    idactors: number[];
    idgenres: number[];
    countryid: number;
}
export interface IUpdateMovie_response {
    id: number;
    title: string;
    description: string;
    director: string;
    imageUrl: string;
    durationMinutes: number;
    releaseDate: Date;
    language: string;
    rating: number;
    countryId: number;
}
export interface IGetactorsgenres_send {
    Id: number;
}
export interface IGetactorsgenres_response {
    actors: number[]
    genres: number[]
}
export interface IGetshowtimemovie_send {
    Id: number;
}
export interface IGetshowtimemovie_response {
    showtimesId: number[]
}