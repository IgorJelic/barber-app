import { Routes, Route } from "react-router-dom";
import HomePage from './pages/HomePage.js';
import BarberProfilePage from "./pages/BarberProfilePage.js";
import NotFoundPage from './pages/NotFoundPage.js';


function App() {
  return (
    <Routes>
      <Route path="/" element={<HomePage/>}/>
      <Route path="/barber/:id" element={<BarberProfilePage/>}/>
      <Route path="*" element={<NotFoundPage/>}/>
    </Routes>
  );
}

export default App;
