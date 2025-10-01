import {apiRegister, api} from "@/services/apiService";
import type {  ApiResponse, UserLoginDTO, UserRegisterDTO } from "@/types";

// auth.ts
let accessToken: string | null = null;
let expiresIn: number | null = null;

export function setAccessToken(token: string, expiresIn: number) {
    accessToken = token;
    expiresIn = expiresIn;
}

export function getAccessToken(): string | null {
    return accessToken;
}

export function clearAccessToken() {
    accessToken = null;
}

export async function LoginAsync(UserLoginDTO: UserLoginDTO): Promise<ApiResponse> {
    const result = await api.post<ApiResponse>("/Auth/login", UserLoginDTO);

    if (result.data.success) {
        setAccessToken(result.data.content.token, result.data.content.expiresIn);
        // Redirect to the front page
    }
    return result.data;
}

export async function RegisterAsync(UserRegisterDTO: UserRegisterDTO) : Promise<ApiResponse>  
{
  const result = await apiRegister.post<ApiResponse>("/Auth/register", UserRegisterDTO);
  return result.data;
}