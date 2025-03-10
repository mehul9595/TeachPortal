import { useState } from 'react';
import { BrowserRouter as Router, Routes, Route, Navigate } from 'react-router-dom';
import TeacherAuth from './components/TeacherAuth/TeacherAuth';
import Header from './components/Header/Header';
import Footer from './components/Footer/Footer';
import Sidebar from './components/Sidebar/Sidebar';
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap-icons/font/bootstrap-icons.css';
import './App.css';
import StudentManagement from './components/StudentManagement';
import TeacherOverview from './components/TeacherOverview';

function App() {
  const [isLoggedIn, setIsLoggedIn] = useState(false);

  return (
    <Router>
      <div className="app-container">
        <Header isLoggedIn={isLoggedIn} setIsLoggedIn={setIsLoggedIn} />
        <div className='content'>
          {isLoggedIn && <Sidebar />}
          <main className="main-content">
            <Routes>
              <Route path="/" element={<TeacherAuth setIsLoggedIn={setIsLoggedIn} />} />
              <Route path="/teacher" element={isLoggedIn ? <TeacherOverview /> : <Navigate to="/" />} />
              <Route path="/student" element={isLoggedIn ? <StudentManagement /> : <Navigate to="/" />} />
              <Route path="*" element={<Navigate to="/" />} />
            </Routes>
          </main>
        </div>
        <Footer />
      </div>
    </Router>
  );
}

export default App;