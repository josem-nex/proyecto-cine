export interface IGetAllDiscounts_response {
    discounts: IGetAllDiscounts_response_aux[]
}
export interface IGetAllDiscounts_response_aux {
    id: number
    name: string;
    value: number;
    tickets: number[]
}
export interface IGetDiscount_send {
    Id: number
}
export interface IGetDiscount_response {
    id: number;
    name: string;
    value: number;
}