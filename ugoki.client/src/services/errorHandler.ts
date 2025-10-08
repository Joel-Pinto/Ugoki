import { AxiosError } from "axios";
import { forEachChild } from "typescript";

// types/errorHandler.ts
export interface ErrorDetail {
    code: string;
    description: string;
}

export interface ErrorHandler {
    success: boolean;
    statusCode: number;
    message: string;             // User-friendly summary
    details?: ErrorDetail[];     // Optional list of validation errors
}

export function handleError(error: unknown): ErrorHandler {
    const axiosError = error as AxiosError;

    const statusCode = axiosError.response?.status ?? 500;
    const data = axiosError.response?.data;

    let message = "An unexpected error occurred.";
    let details: ErrorDetail[] | undefined;

    if (Array.isArray(data)) {
        // Validation errors array from backend
        message = "Please correct the following errors:";
        details = data.map((d: any) => ({
            code: d.code,
            description: d.description,
        }));
    } else if (typeof data === "string") {
        message = data;
    } else if (typeof data === "object" && data?.message) {
        message = data?.message;
    }

    return {
        success: false,
        statusCode,
        message,
        details,
    };
}