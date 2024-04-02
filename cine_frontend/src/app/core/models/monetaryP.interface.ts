export interface Iadd_monetary_send {
    UserID: string;
    TicketId: string;
    TotalPrice: string;
    CreditCard: string;
}
export interface Iadd_monetary_response {
    userId: string;
    ticketId: number;
    totalPrice: number;
    creditCard: string;
}
export interface Idelete_monetary_send {
    TicketId: number;
}
export interface Iget_monetary_send {
    TicketId: number;
}
export interface Iget_monetary_response {
    userId: string;
    ticketId: number;
    totalPrice: number;
    creditCard: string;
}
export interface Igetall_monetary_response {
    monetaryPurchases: Igetall_monetary_response_aux[]
}
export interface Igetall_monetary_response_aux {
    user: null
    userId: string;
    ticket: null
    ticketId: number;
    totalPrice: number;
    creditCard: string;
}
export interface Iupdate_monetary_send {
    UserID: string;
    TicketId: string;
    TotalPrice: string;
    CreditCard: string;
}
export interface Iupdate_monetary_response {
    userId: string;
    ticketId: number;
    totalPrice: number;
    creditCard: string;
}
