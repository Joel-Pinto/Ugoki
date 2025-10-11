import axios from "axios";

axios.defaults.withCredentials = true;

export const api = axios.create({
    baseURL: "https://localhost:7117/api",
    headers: {
        "Content-Type": "application/json",
    }
});
