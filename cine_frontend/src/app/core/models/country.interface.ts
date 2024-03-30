export interface IGetAllCountries_response {
    countries: IGetAllCountries_response_aux[] 
} 
export interface IGetAllCountries_response_aux {
    id: number;
    name: string;
    movies: []
}

export interface IAddCountry_send {
    name: string;
}
export interface IAddCountry_response {
    id: number; 
    name: string;
}

export interface IGetCountry_send {
    countryId: number;
}
export interface IGetCountry_response {
    id: number;
    name: string;
}