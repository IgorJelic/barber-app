import { Routes, Route } from "react-router-dom";
import HomePage from './pages/HomePage.js';
import BarberProfilePage from "./pages/BarberProfilePage.js";
import NotFoundPage from './pages/NotFoundPage.js';
import LoginPage from "./pages/LoginPage.js";
import { useEffect } from "react";


function App() {
  
  useEffect(() => {
    // Hendluj REMEMBER ME dugme na Login strani

    const handleWindowClose = () => {
      if (true) localStorage.removeItem('token');
    }

    window.addEventListener('beforeunload', handleWindowClose);

    return () => {
      window.removeEventListener('beforeunload', handleWindowClose);
    }
  },[])

  return (
    <Routes>
      <Route path="/" element={<HomePage/>}/>
      <Route path="/barber/:id" element={<BarberProfilePage/>}/>
      <Route path="/login" element={<LoginPage/>}/>
      <Route path="*" element={<NotFoundPage/>}/>
    </Routes>
  );
}

export default App;
