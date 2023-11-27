import Logo from "../assets/Menu_Masters_Logo.png";
import { Link } from "react-router-dom";
import { LANGUAGES } from "../constants/Languages";

const Header = () => {
  return (
    <nav className="max-w-screen-xl mx-auto">
      <div className="flex justify-between items-center">
        <Link to="/Menu">
          <img src={Logo} className="w-56 h-auto" />
        </Link>

        <div className="flex flex-row gap-x-5 px-6 ">
          <h1>Tafel 1</h1>

          <Link to="/TransactionPage">
            <div>ShoppingCart</div>
          </Link>

          <select defaultValue={"en"} className="bg-white">
            {LANGUAGES.map(({ code, label }) => (
              <option key={code} value={code}>
                {label}
              </option>
            ))}
          </select>
        </div>
      </div>
    </nav>
  );
};

export default Header;
