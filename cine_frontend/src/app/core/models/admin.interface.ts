export interface IAdd_admin_send {
    User: string;
    Password: string;
}
export interface IAdd_admin_response {
    id: string;
    user: string;
    password: string;
}

export interface IGet_admin_send {
    id: string;
}
export interface IGet_admin_response {
    id: string; 
    user: string;
    password: string;
}

export interface IGetAll_admin_response {
    admins: IGetAll_admin_response_aux[]
}
export interface IGetAll_admin_response_aux {
    id: string;
    user: string;
    password: string;
}

export interface ILogin_admin_send {
    User: string;
    Password: string;
}
export interface ILogin_admin_response {
    id: string; 
    user: string;
    password: string;
}

export interface IUpdate_admin_send {
    id: string;
    user: string;
    password: string;
}
export interface IUpdate_admin_response {
    id: string;
    user: string;
    password: string;
}

export interface IDelete_admin_send {
    id: string;
}