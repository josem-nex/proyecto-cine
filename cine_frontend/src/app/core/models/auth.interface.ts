export interface IGetAllPartners_response {
    partners: IGetAllPartners_response_aux[]
}
export interface IGetAllPartners_response_aux {
    address: string;
    phoneNumber: string;
    points: number;
    password: string;
    id: string;
    firstName: string;
    lastName: string;
    email: string;
    ci: string; 
}
export interface IDeletePartner_send {
    id: string;
}
export interface IGetPartner_send {
    id: string;
}
export interface IGetPartner_response {
    id: string;
    firstName: string;
    lastName: string;
    email: string;
    ci: string;
    address: string;
    phoneNumber: string;
    points: number;
    token: string;
}
export interface IUpdatePartner_send {
    id: string;
    firstname: string;
    lastname: string;
    email: string;
    ci: string;
    address: string;
    phonenumber: string;
    password: string;
}
export interface IUpdatePartner_response {
    id: string;
    firstName: string;
    lastName: string;
    email: string;
    ci: string;
    address: string;
    phoneNumber: string;
    points: number;
    token: string;
}
export interface ILogin_send {
    email: string;
    password: string;
}
export interface ILogin_response {
    id: string;
    firstName: string;
    lastName: string;
    email: string;
    ci: string; 
    address: string;
    phoneNumber: string;
    points: number;
    token: string;
}
export interface IRegister_send {
    firstname: string;
    lastname: string;
    email: string;
    ci: string;
    address: string;
    phonenumber: string;
    password: string;
}
export interface IRegister_response {
    id: string;
    firstName: string;
    lastName: string;
    email: string;
    ci: string;
    address: string;
    phoneNumber: string;
    points: number;
    token: string;
}