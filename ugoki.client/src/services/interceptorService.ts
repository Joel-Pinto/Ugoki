// This file sets up an Axios interceptor to attach the JWT token to every request if available.

import { api } from "./apiService";
import { getAccessToken } from "./authService";

api.interceptors.request.use(
  (config) => {
    console.log(config);
//    const token = getAccessToken();
//    if (token) {
//      config.headers.Authorization = `Bearer ${token}`;
//    }
    return config;
  },
  (error) => Promise.reject(error)
);
