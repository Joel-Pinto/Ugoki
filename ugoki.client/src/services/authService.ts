/* eslint-disable @typescript-eslint/no-unused-vars */
import { api } from "@/services/apiService";
import { handleError } from "@/services/errorHandler"; // runtime import
import type { ApiResponse, UserLoginDTO, UserRegisterDTO } from "@/types"; // type-only
import type { ErrorHandler } from "@/services/errorHandler"; // type-only

export async function LoginAsync(UserLoginDTO: UserLoginDTO): Promise<ApiResponse> {
    const result = await api.post<ApiResponse>("/Auth/login", UserLoginDTO);
    return result.data;
}

export async function RegisterAsync(
    userData: UserRegisterDTO
): Promise<ApiResponse | ErrorHandler> {
    try {
        const result = await api.post<ApiResponse>("/Auth/register", userData);
        return result.data;
    } catch (exception) {
        return handleError(exception);
    }
}

