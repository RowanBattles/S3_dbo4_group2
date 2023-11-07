import FrontPage from "./pages/Users/FrontPage";
import Home from "./pages/Users/Home";
import ItemDetails from "./pages/Users/ItemDetails";
import { Route, Routes } from "react-router-dom";
import TransactionPage from "./pages/Users/TransactionPage";
import ReservationPage from "./pages/Users/ReservationPage";
import SalesPage from "./pages/Staff/SalesPage";
import KitchenPage from "./pages/Staff/KitchenPage";

function App() {
  return (
    <Routes>
      <Route path="/" element={<FrontPage />} />
      <Route path="/details" element={<ItemDetails />} />
      <Route path="/TransactionPage" element={<TransactionPage />} />
      <Route path="/Menu" element={<Home />} />
      <Route path="/SalesPage" element={<SalesPage />} />
      <Route path="/Reservation" element={<ReservationPage />} />
      <Route path="/KitchenPage" element={<KitchenPage />} />
    </Routes>
  );
}

export default App;
