import type { LoginResponse } from "./auth";

// types/api.ts
export interface ApiResponse {
    success: boolean;
    content: LoginResponse;
    // eslint-disable-next-line @typescript-eslint/no-explicit-any
    data?: any;
}
