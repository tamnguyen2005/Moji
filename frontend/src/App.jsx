import NavBar from "./components/NavBar";
import { Route, Routes } from "react-router-dom";
import Home from "./pages/Home";
import Create from "./pages/Create";
import Detail from "./pages/Detail";
import Product from "./pages/Product";
import Profile from "./pages/Profile";
import Footer from "./components/Footer";
function App() {
  return (
    <>
      <NavBar />
      <Routes>
        <Route path="/" element={<Home />}></Route>
        <Route path="/Create" element={<Create />}></Route>
        <Route path="/Detail/:id" element={<Detail />}></Route>
        <Route path="/Product" element={<Product />}></Route>
        <Route path="/Profile" element={<Profile />}></Route>
      </Routes>
      <Footer />
    </>
  );
}

export default App;
