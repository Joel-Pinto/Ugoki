import axios from "axios";

export const api = axios.create({
    baseURL: "https://localhost:7117/api",
    headers: {
        "Content-Type": "application/json",
    }
});