import axios from 'axios';
import type { AxiosRequestConfig } from 'axios';

import tokenService from '../services/tokenService';

const instance = axios.create({
    baseURL: 'https://localhost:7034/api/v1/',
    headers: {
        'Content-type': 'application/json'
    },
});

instance.interceptors.request.use((config: AxiosRequestConfig<any>) => {
    const token = tokenService.getLocalAccessToken();
    if (token) {
        config.headers!["Authorization"] = 'Bearer ' + token;
    }
    return config;
},
(error) => {
    return Promise.reject(error);
});

export default instance;