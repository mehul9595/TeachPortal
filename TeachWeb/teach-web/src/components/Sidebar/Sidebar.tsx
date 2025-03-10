import { Link } from "react-router-dom";
import "./Sidebar.css";

const Sidebar = () => {
  return (
    <div className="sidebar">
      <ul className="nav flex-column">
        <li className="nav-item">
          <Link to="/teacher" className="nav-link">
            Teacher
          </Link>
        </li>
        <li className="nav-item">
          <Link to="/student" className="nav-link">
            Student
          </Link>
        </li>
      </ul>
    </div>
  );
};

export default Sidebar;