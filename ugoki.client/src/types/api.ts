import type { LoginResponse } from "./auth";

// types/api.ts
export interface ApiResponse {
    success: boolean;
    content: LoginResponse;
    info: string;
}
