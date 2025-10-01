// types/auth.ts
export interface LoginResponse {
    token: string;
    refreshToken: string;
    expiresIn: number;
}

export interface RegisterResponse {
    success: string;
    content?: Object;
    info: string;
}

export interface RefreshTokenResponse {
    token: string;
}

export interface AuthState {
    token: string | null;
    refreshToken: string | null;
    isAuthenticated: boolean;
}