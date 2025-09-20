import axios from "axios";

const api = axios.create({
    baseURL: "https://localhost:7117/api/user",
    headers: {
        "Content-Type": "application/json"
    }
});


export default api;
