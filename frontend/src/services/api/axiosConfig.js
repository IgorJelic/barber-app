import axios from "axios";

// Base URL
axios.defaults.baseURL = 'https://localhost:7065/api';

// Request interceptor
axios.interceptors.request.use(
    config => {
    const authToken = localStorage.getItem("authToken");
    if (authToken) config.headers.Authorization = `Bearer ${authToken}`;
    return config;
    }, 
    error => Promise.reject(error)
);

export default axios;