import axios from "axios";

export const api = axios.create({
    baseURL: "https://localhost:7117/api",
    withCredentials: true,  // Important if authentication relies on cookies
    headers: {
        "Content-Type": "application/json",
    }
});

export const apiRegister = axios.create({
    baseURL: "https://localhost:7117/api",
    headers: {
        "Content-Type": "application/json",
    }
});