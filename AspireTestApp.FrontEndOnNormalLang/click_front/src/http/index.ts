import axios from "axios";

export const AUTH_API_URL = "api/"

export const $auth_api = axios.create({
    withCredentials : true,
    baseURL: AUTH_API_URL
})

$auth_api.interceptors.response.use((config) => {return config}, async (error) =>
{
    const originalRequest = error.config;
    if(error.response.status !== 200 && error.config && !error.config._isRetry)
    {
        originalRequest._isRetry = true;
        // try
        // {
        //     const response = await axios.get
        // }
    }
})