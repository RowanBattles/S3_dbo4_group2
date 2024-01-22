import Select from "react-select";
import Logo from "../../assets/Menu_Masters_Logo.png";
import { Link } from "react-router-dom";
import { useTranslation } from "react-i18next";
import { LANGUAGES } from "../../utils/constants/Languages";
import { useCookies } from "react-cookie";
import { IonIcon } from "@ionic/react";
import { cartOutline, cart } from "ionicons/icons";
import { useEffect, useState } from "react";

import { useRecoilState } from "recoil";
import { cartItemCountState } from "../../atoms/recoilAtoms.ts";

const Header = () => {
  const [cookie] = useCookies(["tafelNummer"]);
  const { i18n, t } = useTranslation();
  const [cartItemCount, setCartItemCount] = useRecoilState(cartItemCountState);
  const [isCartHovered, setIsCartHovered] = useState(false);

  const onChangeLang = (selectedOption: any) => {
    if (selectedOption && selectedOption.value) {
      i18n.changeLanguage(selectedOption.value);
    }
  };

  const options = LANGUAGES.map(({ code, label, imageSrc }) => ({
    value: code,
    label: (
      <div className="">
        <img src={imageSrc} alt={label} className="h-6 w-10" />
      </div>
    ),
  }));

  const getCartIcon = () => {
    if (isCartHovered) {
      return {
        icon: cart,
        fill: "red",
      };
    } else {
      return {
        icon: cartOutline,
        fill: "",
      };
    }
  };

  useEffect(() => {
    const storedCartItemsString = localStorage.getItem("cartItems");
    if (storedCartItemsString) {
      try {
        const storedCartItems = JSON.parse(storedCartItemsString);
        setCartItemCount(storedCartItems.length);
      } catch (error) {
        console.error("Error parsing cart items:", error);
      }
    }
  }, [setCartItemCount]);

  return (
    <nav className="max-w-screen-xl mx-auto">
      <div className="flex justify-between items-center">
        <Link to="/Menu">
          <img src={Logo} className="w-56 h-auto" />
        </Link>

        <div className="flex flex-row gap-x-5 px-6 items-center">
          <h1>Tafel {cookie.tafelNummer}</h1>

          <Link to="/Receipt">
            <div>{t("common:translation:receipt")}</div>
          </Link>

          <Link
            to="/TransactionPage"
            className="relative cart-link"
            onMouseEnter={() => setIsCartHovered(true)}
            onMouseLeave={() => setIsCartHovered(false)}
          >
            <div className="flex items-center mt-0.5">
              <IonIcon
                icon={getCartIcon().icon}
                size="small"
                style={{ fill: getCartIcon().fill }}
              />
              {cartItemCount > 0 && (
                <div className="bg-red-500 rounded-full w-5 h-5 text-white flex items-center justify-center absolute -top-4 -right-4">
                  {cartItemCount}
                </div>
              )}
            </div>
          </Link>

          <Select
            defaultValue={options.find(
              (option) => option.value === i18n.language
            )}
            options={options}
            onChange={onChangeLang}
          />
        </div>
      </div>
    </nav>
  );
};

export default Header;
