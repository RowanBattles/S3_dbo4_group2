import FrontPage from "./pages/Users/FrontPage";
import Home from "./pages/Users/Home";
import ItemDetails from "./pages/Users/ItemDetails";
import { Route, Routes } from "react-router-dom";
import TransactionPage from "./pages/Users/TransactionPage";
import SalesTab from "./pages/Staff/SalesTab";
import ReservationPage from "./pages/Users/ReservationPage";

function App() {
  return (
    <Routes>
      <Route path="/" element={<FrontPage />} />
      <Route path="/details" element={<ItemDetails />} />
      <Route path="/TransactionPage" element={<TransactionPage />} />
      <Route path="/Menu" element={<Home />} />
      <Route path="/SalesTab" element={<SalesTab />} />
      <Route path="/Reservation" element={<ReservationPage />} />
    </Routes>
  );
}

export default App;
