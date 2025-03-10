import React, { useState, useEffect } from 'react';
import { Student } from '../types';
import { createStudent, getStudents } from '../services/studentApi';
import { validateStudentFields } from '../utils/validation';
import 'bootstrap/dist/css/bootstrap.min.css';

const StudentManagement: React.FC = () => {
    const [students, setStudents] = useState<Student[]>([]);
    const [firstname, setFirstname] = useState<string>('');
    const [lastname, setLastname] = useState<string>('');
    const [email, setEmail] = useState<string>('');
    const [error, setError] = useState<string>('');
    const [showForm, setShowForm] = useState<boolean>(false);

    useEffect(() => {
        const loadStudents = async () => {
            const fetchedStudents = await getStudents();
            setStudents(fetchedStudents);
        };
        loadStudents();
    }, []);

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        const validationError = !validateStudentFields(firstname, lastname, email) ? 'Invalid student fields' : '';
        if (validationError) {
            setError(validationError);
            return;
        }
        const newStudent: Student = { id: '', firstname, lastname, email, teacherId: '' };
        const createdStudent = await createStudent(newStudent);
        setStudents([...students, createdStudent]);
        setFirstname('');
        setLastname('');
        setEmail('');
        setError('');
        setShowForm(false); // Hide the form after submission
    };

    return (
        <div className="container">
            <h2>Student Management</h2>
            <button className="btn btn-primary mb-4" onClick={() => setShowForm(!showForm)}>
                {showForm ? 'Close Form' : 'Add Student'}
            </button>
            {showForm && (
                <form onSubmit={handleSubmit} className="mb-4">
                    <div className="mb-3">
                        <label htmlFor="firstname" className="form-label">First Name</label>
                        <input
                            type="text"
                            id="firstname"
                            className="form-control"
                            placeholder="First Name"
                            value={firstname}
                            onChange={(e) => setFirstname(e.target.value)}
                            required
                        />
                    </div>
                    <div className="mb-3">
                        <label htmlFor="lastname" className="form-label">Last Name</label>
                        <input
                            type="text"
                            id="lastname"
                            className="form-control"
                            placeholder="Last Name"
                            value={lastname}
                            onChange={(e) => setLastname(e.target.value)}
                            required
                        />
                    </div>
                    <div className="mb-3">
                        <label htmlFor="email" className="form-label">Email</label>
                        <input
                            type="email"
                            id="email"
                            className="form-control"
                            placeholder="Email"
                            value={email}
                            onChange={(e) => setEmail(e.target.value)}
                            required
                        />
                    </div>
                    <button type="submit" className="btn btn-primary">Add Student</button>
                </form>
            )}
            {error && <p className="text-danger">{error}</p>}
            <h3>Student List</h3>
            <div className="row">
                {students.map((student) => (
                    <div key={student.id} className="col-md-4 mb-4">
                        <div className="card">
                            <div className="card-body">
                                <h5 className="card-title">{student.firstname} {student.lastname}</h5>
                                <p className="card-text">{student.email}</p>
                            </div>
                        </div>
                    </div>
                ))}
            </div>
        </div>
    );
};

export default StudentManagement;