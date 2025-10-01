// types/api.ts
export interface ApiResponse<T> {
    success: boolean;
    content: T;
    error?: string;
}
