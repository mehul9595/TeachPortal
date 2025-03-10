import api from './api';
import { TeacherResponse } from '../types';

// Function to get all teachers
export const getAllTeachers = async (): Promise<TeacherResponse[]> => {
    const response = await api.get('/teachers');
    return response.data;
};