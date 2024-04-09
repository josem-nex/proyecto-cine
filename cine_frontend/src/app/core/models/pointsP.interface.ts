export interface Iadd_points_send {
    UserID: string;
    TicketId: string;
    TotalPoints: string;
}
export interface Iadd_points_response {
    userId: string;
    ticketId: number;
    totalPoints: number;
}

export interface Idelete_points_send {
    TicketId: number;
}

export interface Iget_points_send {
    TicketId: number;
}
export interface Iget_points_response {
    userId: string;
    ticketId: number;
    totalPoints: number;
}

export interface Igetall_points_response {
    pointsPurchases: Igetall_points_response_aux[]
}
export interface Igetall_points_response_aux {
    user: null
    userId: string
    ticket: null
    ticketId: number;
    totalPoints: number;
}

export interface Iupdate_points_send {
    UserID: string;
    TicketId: string;
    TotalPoints: string;
}
export interface Iupdate_points_response {
    userId: string;
    ticketId: number;
    totalPoints: number;
}