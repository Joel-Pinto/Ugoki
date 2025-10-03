import { api } from "@/services/apiService";
import type {  ApiResponse, UserLoginDTO, UserRegisterDTO } from "@/types";

export function setAccessToken(token: string, expiresIn: number) {
    localStorage.setItem("jwt", token);
    localStorage.setItem("jwt_expiresIn", expiresIn.toString());
}

export function getAccessToken(): string | null {
    return localStorage.getItem("jwt");
}

export function clearAccessToken() {
    localStorage.removeItem("jwt");
    localStorage.removeItem("jwt_expiresIn");
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
  const result = await api.post<ApiResponse>("/Auth/register", UserRegisterDTO);
  return result.data;
}