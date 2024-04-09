export interface Iadd_ticket_send {
    ShowTimesId: number;
    ChairsId: number;
    DiscountsIds: number[]
    IsWeb: boolean
}
export interface Iadd_ticket_response {
   id: number;
   showTimesId: number;
   chairsId: number;
   isWeb: boolean 
}

export interface Idelete_ticket_send {
    Id: number;
}

export interface Iget_ticket_send {
    Id: number;
}
export interface Iget_ticket_response {
    id: number;
    showTimesId: number;
    chairsId: number;
    isWeb: boolean
}
export interface Igetall_ticket_response {
    tickets: Igetall_ticket_response_aux[];

}
export interface Igetall_ticket_response_aux {
    id: number
    showTimes: null
    showTimesId: number;
    chairs: null;
    chairsId: number;
    discounts: number[]
    isWeb: boolean
}

export interface Iupdate_ticket_send {
    Id: number;
    ShowTimesId: number;
    ChairsId: number;
    DiscountsIds: number[]
    IsWeb: boolean
}
export interface Iupdate_ticket_response {
    id: number
    showTimesId: number
    chairsId: number;
    isWeb: boolean
}