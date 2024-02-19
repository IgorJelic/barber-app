import axios from "axios";

// Base URL
axios.defaults.baseURL = process.env.REACT_APP_API_URL;

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