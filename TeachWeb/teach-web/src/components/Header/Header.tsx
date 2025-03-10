import { Link } from "react-router-dom";
import "./Header.css";
import { JSX } from "react";

interface HeaderProps {
  readonly isLoggedIn: boolean;
  setIsLoggedIn: (isLoggedIn: boolean) => void;
}

const Header = ({ isLoggedIn, setIsLoggedIn }: HeaderProps): JSX.Element => {
  const handleLogout = () => {
    setIsLoggedIn(false);
  };

  return (
    <header className="header bg-primary text-white p-3">
      <div className="container d-flex justify-content-between align-items-center">
        <h1 className="h3">Teach Portal</h1>
        <nav>
          {isLoggedIn ? (
            <ul className="nav">
              {/* <li className="nav-item">
                <Link to="/dashboard" className="nav-link text-white">
                  Dashboard
                </Link>
              </li>
              <li className="nav-item">
                <button className="btn btn-link nav-link text-white d-flex align-items-center">
                  <i className="bi bi-plus-circle">&nbsp;</i>
                  <span className="me-2">Student</span>
                </button>
              </li> */}
              <li className="nav-item">
                <button
                  onClick={handleLogout}
                  className="btn btn-link nav-link text-white"
                >
                  Logout
                </button>
              </li>
            </ul>
          ) : (
            <Link to="/" className="btn btn-light">
              Teacher Login
            </Link>
          )}
        </nav>
      </div>
    </header>
  );
};

export default Header;
