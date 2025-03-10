import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import { signUp, login } from "../../services/auth";
import { validateSignUp, validateLogin } from "../../utils/validation";
import "./TeacherAuth.css";
import axios from "axios";

interface TeacherAuthProps {
  readonly setIsLoggedIn: (isLoggedIn: boolean) => void;
}

function TeacherAuth({ setIsLoggedIn }: TeacherAuthProps) {
  const [isLogin, setIsLogin] = useState(true);
  const [formData, setFormData] = useState({
    username: "",
    email: "",
    firstname: "",
    lastname: "",
    password: "",
  });
  const [error, setError] = useState("");
  const navigate = useNavigate();

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    setFormData({ ...formData, [name]: value });
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setError("");

    const validationError = isLogin
      ? validateLogin(formData)
      : validateSignUp(formData);
    if (validationError) {
      setError(validationError);
      return;
    }

    try {
      if (isLogin) {
        await login(formData.username, formData.password);
        setIsLoggedIn(true);
        navigate("/teacher");
      } else {
        await signUp(
          formData.username,
          formData.email,
          formData.firstname,
          formData.lastname,
          formData.password
        );
      }
      setIsLogin(true);
    } catch (err) {
      if (axios.isAxiosError(err) && err.response) {
        if (err.response.status === 500) {
          setError("Server error. Please try again later.");
          // log the error for tracing
          console.error(err.response.data);
        } else {
          setError(err.response.data || "Authentication failed. Please try again.");
        }
      } else {
        setError("An unexpected error occurred. Please try again.");
      }
    }
  };

  return (
    <div className="auth-container">
      <h2>{isLogin ? "Teacher Login" : "Teacher Sign Up"}</h2>
      {error && <p className="error">{error}</p>}
      <form onSubmit={handleSubmit}>
        {!isLogin && (
          <>
            <div className="form-group">
              <input
                type="text"
                name="firstname"
                placeholder="First Name"
                className="form-control"
                onChange={handleChange}
                required
              />
            </div>
            <div className="form-group">
              <input
                type="text"
                name="lastname"
                placeholder="Last Name"
                className="form-control"
                onChange={handleChange}
                required
              />
            </div>
            <div className="form-group">
              <input
                type="email"
                name="email"
                placeholder="Email"
                className="form-control"
                onChange={handleChange}
                required
              />
            </div>
          </>
        )}
        <div className="form-group">
          <input
            type="text"
            name="username"
            placeholder="Username"
            className="form-control"
            onChange={handleChange}
            required
          />
        </div>
        <div className="form-group">
          <input
            type="password"
            name="password"
            placeholder="Password"
            className="form-control"
            onChange={handleChange}
            required
          />
        </div>
        <button type="submit" className="btn btn-primary btn-block">
          {isLogin ? "Login" : "Sign Up"}
        </button>
      </form>
      <div className="toggle-btn">
        <button onClick={() => setIsLogin(!isLogin)} className="btn btn-link">
          {isLogin
            ? "Need an account? Sign Up"
            : "Already have an account? Login"}
        </button>
      </div>
    </div>
  );
}

export default TeacherAuth;
