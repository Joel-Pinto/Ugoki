export interface User {
    id: string;
    username: string;
    email: string;
    createdAt: string;
}

export interface UserLoginDTO {
    email: string;
    password: string;
}

export interface UserRegisterDTO {
    username: string;
    email: string;
    password: string;
}
