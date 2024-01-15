import FrontPage from "./pages/Users/FrontPage";
import Home from "./pages/Users/Home";
import ItemDetails from "./pages/Users/ItemDetails";
import { Navigate, Route, Routes } from "react-router-dom";
import { useCookies } from "react-cookie";
import TransactionPage from "./pages/Users/TransactionPage";
import ReservationPage from "./pages/Users/ReservationPage";
import SalesPage from "./pages/Staff/SalesPage";
import KitchenPage from "./pages/Staff/KitchenPage";
import BarPage from "./pages/Staff/BarPage";
import { Suspense } from "react";
import { ToastContainer } from "react-toastify";
import DashboardPage from "./pages/Staff/DashboardPage";
import Receipt from "./pages/Users/Receipt";

function App() {
  const [cookies] = useCookies(["isAuthenticated"]);

  return (
    <Suspense fallback="loading">
      <Routes>
        <Route path="/" element={<FrontPage />} />
        <Route
          path="/details/:id"
          element={
            cookies.isAuthenticated ? <ItemDetails /> : <Navigate to="/" />
          }
        />
        <Route
          path="/receipt"
          element={cookies.isAuthenticated ? <Receipt /> : <Navigate to="/" />}
        />
        <Route
          path="/TransactionPage"
          element={
            cookies.isAuthenticated ? (
              <TransactionPage />
            ) : (
              <Navigate to="/SalesPage" />
            )
          }
        />
        <Route path="/Menu" element={<Home />} />
        <Route path="/Reservation" element={<ReservationPage />} />
        <Route
          path="/SalesPage"
          element={
            cookies.isAuthenticated ? <SalesPage /> : <Navigate to="/" />
          }
        />
        <Route
          path="/KitchenPage"
          element={
            cookies.isAuthenticated ? <KitchenPage /> : <Navigate to="/" />
          }
        />
        <Route
          path="/BarPage"
          element={cookies.isAuthenticated ? <BarPage /> : <Navigate to="/" />}
        />
        <Route path="/Dashboard" element={<DashboardPage />} />
      </Routes>

      <ToastContainer />
    </Suspense>
  );
}

export default App;
