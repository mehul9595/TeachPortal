import { useEffect, useState } from "react";
import { getAllTeachers } from "../services/teacherApi";
import { TeacherResponse } from "../types";
import "bootstrap/dist/css/bootstrap.min.css";

const TeacherOverview = () => {
  const [teachers, setTeachers] = useState<TeacherResponse[]>([]);
  const [loading, setLoading] = useState<boolean>(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchTeachers = async () => {
      try {
        const data = await getAllTeachers();
        setTeachers(data);
      } catch (err) {
        setError("Failed to fetch teachers");
      } finally {
        setLoading(false);
      }
    };

    fetchTeachers();
  }, []);

  if (loading) {
    return <div>Loading...</div>;
  }

  if (error) {
    return <div>{error}</div>;
  }

  return (
    <div className="container">
      <h2 className="mb-4">Teacher Overview</h2>
      <div className="row">
        {teachers.map((teacher) => (
          <div key={teacher.id} className="col-md-4 mb-4">
            <div className="card">
              <div className="card-body">
                <h5 className="card-title">
                  {teacher.firstName} {teacher.lastName}
                </h5>
                <h6 className="card-subtitle mb-2 text-muted">
                  Email: {teacher.email}
                </h6>
                <p className="card-text mb-2 text-muted">
                  Username: {teacher.username}
                </p>
                <p className="card-text">{teacher.studentCount} students</p>
              </div>
            </div>
          </div>
        ))}
      </div>
    </div>
  );
};

export default TeacherOverview;
