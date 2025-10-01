export interface User {
    id: string;
    username: string;
    email: string;
    createdAt: string;
}

export interface UserLoginDTO {
    username: string;
    password: string;
}

export interface UserRegisterDTO {
    username: string;
    password: string;
    email: string;
}
