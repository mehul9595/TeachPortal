export interface Teacher {
    id: string;
    username: string;
    email: string;
    firstname: string;
    lastname: string;
    password: string; // This should be hashed in the backend
}

export interface TeacherResponse {
    id: string;
    username: string;
    email: string;
    firstName: string;
    lastName: string;
    studentCount: number;
}

export interface Student {
    id: string;
    firstname: string;
    lastname: string;
    email: string;
    teacherId: string; // Reference to the teacher who created the student
}

export interface AuthResponse {
    token: string;
    teacher: Teacher;
}