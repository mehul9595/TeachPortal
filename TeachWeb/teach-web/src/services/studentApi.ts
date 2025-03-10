import api from "./api";
import axios from "axios";
import { Student } from "../types";

// Function to create a student
export const createStudent = async (studentData: Student): Promise<Student> => {
  try {
    const response = await api.post(`/students`, studentData);
    return response.data;
  } catch (error) {
    if (axios.isAxiosError(error) && error.response) {
      throw error.response.data;
    } else {
      throw error;
    }
  }
};

// Function to get students for a teacher
export const getStudents = async (): Promise<Student[]> => {
  try {
    const response = await api.get(`/students`);
    return response.data;
  } catch (error) {
    if (axios.isAxiosError(error) && error.response) {
      throw error.response.data;
    } else {
      throw error;
    }
  }
};
