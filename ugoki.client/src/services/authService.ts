import apiService from "@/services/apiService";
import type {  ApiResponse, LoginResponse, UserRegisterDTO, RegisterResponse } from "@/types";

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

export async function LoginAsync(username: string, password: string) {
    const result = await apiService.post<ApiResponse<LoginResponse>>("/auth/login", {
        username: username,
        password: password,
    });

    if (result.data.success) {
        setAccessToken(result.data.content.token, result.data.content.expiresIn);
    }
}

export async function RegisterAsync(UserRegisterDTO: UserRegisterDTO) : Promise<ApiResponse<RegisterResponse> | undefined>  
{
  const result = await apiService.post<ApiResponse<RegisterResponse>>("/auth/register", {
    data: UserRegisterDTO
  });

  if(result.data.success) {
    return result.data;
  }
  return undefined;
}