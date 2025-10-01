import axios from "axios";

const api = axios.create({
    baseURL: "https://localhost:7117/api",
    withCredentials: true,  // Important if authentication relies on cookies
    headers: {
        "Content-Type": "application/json",
    }
});

export default api;