import axios from 'axios';
import { AuthResponse } from '../types';

const API_URL = 'https://localhost:7297/api'; // Replace with your actual API URL

export const signUp = async (username: string, email: string, firstname: string, lastname: string, password: string): Promise<AuthResponse> => {
    const response = await axios.post(`${API_URL}/auth/register`, {
        username,
        email,
        firstname,
        lastname,
        password,
    });
    console.log(response);
    return response.data;
};

export const login = async (username: string, password: string): Promise<AuthResponse> => {
    const response = await axios.post(`${API_URL}/auth/login`, {
        username,
        password,
    });
    const token = response.data.token;
    localStorage.setItem('token', token);
    return response.data;
};

export const logout = (): void => {
    localStorage.removeItem('token');
};