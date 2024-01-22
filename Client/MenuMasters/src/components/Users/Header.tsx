import Select from "react-select";
import Logo from "../../assets/Menu_Masters_Logo.png";
import { Link } from "react-router-dom";
import { useTranslation } from "react-i18next";
import { LANGUAGES } from "../../utils/constants/Languages";
import { IonIcon } from "@ionic/react";
import { cartOutline, cart } from "ionicons/icons";
import { useEffect, useState } from "react";
import { useRecoilState } from "recoil";
import { cartItemCountState } from "../../atoms/recoilAtoms.ts";

interface HeaderProps {
  onWaiterRequest: () => void;
}

const Header: React.FC<HeaderProps> = ({ onWaiterRequest }) => {
  const { i18n } = useTranslation();
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
        <img src={imageSrc} alt={label} className="h-8 w-full" />
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
        // Update the state with the length of the cart items array
        setCartItemCount({ cartItemCount: storedCartItems.length });
      } catch (error) {
        console.error("Error parsing cart items:", error);
      }
    }
  }, [setCartItemCount]);

  return (
    <>
      <nav className="max-w-screen-xl mx-auto">
        <div
          className="flex justify-between items-center cursor-pointer"
          onClick={onWaiterRequest}
        >
          <Link to="/Menu">
            <img src={Logo} className="w-40 h-auto" />
          </Link>

          <div className="flex flex-row gap-x-5 pr-6 items-center">
            <img src="/src/assets/waiter.png" className="w-7" />

            <Link to="/Receipt">
              <svg
                xmlns="http://www.w3.org/2000/svg"
                width="24"
                height="24"
                fill="currentColor"
                className="bi bi-receipt"
                viewBox="0 0 16 16"
              >
                <path d="M1.92.506a.5.5 0 0 1 .434.14L3 1.293l.646-.647a.5.5 0 0 1 .708 0L5 1.293l.646-.647a.5.5 0 0 1 .708 0L7 1.293l.646-.647a.5.5 0 0 1 .708 0L9 1.293l.646-.647a.5.5 0 0 1 .708 0l.646.647.646-.647a.5.5 0 0 1 .708 0l.646.647.646-.647a.5.5 0 0 1 .801.13l.5 1A.5.5 0 0 1 15 2v12a.5.5 0 0 1-.053.224l-.5 1a.5.5 0 0 1-.8.13L13 14.707l-.646.647a.5.5 0 0 1-.708 0L11 14.707l-.646.647a.5.5 0 0 1-.708 0L9 14.707l-.646.647a.5.5 0 0 1-.708 0L7 14.707l-.646.647a.5.5 0 0 1-.708 0L5 14.707l-.646.647a.5.5 0 0 1-.708 0L3 14.707l-.646.647a.5.5 0 0 1-.801-.13l-.5-1A.5.5 0 0 1 1 14V2a.5.5 0 0 1 .053-.224l.5-1a.5.5 0 0 1 .367-.27m.217 1.338L2 2.118v11.764l.137.274.51-.51a.5.5 0 0 1 .707 0l.646.647.646-.646a.5.5 0 0 1 .708 0l.646.646.646-.646a.5.5 0 0 1 .708 0l.646.646.646-.646a.5.5 0 0 1 .708 0l.646.646.646-.646a.5.5 0 0 1 .708 0l.646.646.646-.646a.5.5 0 0 1 .708 0l.509.509.137-.274V2.118l-.137-.274-.51.51a.5.5 0 0 1-.707 0L12 1.707l-.646.647a.5.5 0 0 1-.708 0L10 1.707l-.646.647a.5.5 0 0 1-.708 0L8 1.707l-.646.647a.5.5 0 0 1-.708 0L6 1.707l-.646.647a.5.5 0 0 1-.708 0L4 1.707l-.646.647a.5.5 0 0 1-.708 0z" />
                <path d="M3 4.5a.5.5 0 0 1 .5-.5h6a.5.5 0 1 1 0 1h-6a.5.5 0 0 1-.5-.5m0 2a.5.5 0 0 1 .5-.5h6a.5.5 0 1 1 0 1h-6a.5.5 0 0 1-.5-.5m0 2a.5.5 0 0 1 .5-.5h6a.5.5 0 1 1 0 1h-6a.5.5 0 0 1-.5-.5m0 2a.5.5 0 0 1 .5-.5h6a.5.5 0 0 1 0 1h-6a.5.5 0 0 1-.5-.5m8-6a.5.5 0 0 1 .5-.5h1a.5.5 0 0 1 0 1h-1a.5.5 0 0 1-.5-.5m0 2a.5.5 0 0 1 .5-.5h1a.5.5 0 0 1 0 1h-1a.5.5 0 0 1-.5-.5m0 2a.5.5 0 0 1 .5-.5h1a.5.5 0 0 1 0 1h-1a.5.5 0 0 1-.5-.5m0 2a.5.5 0 0 1 .5-.5h1a.5.5 0 0 1 0 1h-1a.5.5 0 0 1-.5-.5" />
              </svg>
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
                  size="large"
                  style={{ fill: getCartIcon().fill }}
                />
                {cartItemCount.cartItemCount > 0 && (
                  <div className="bg-red-500 rounded-full w-5 h-5 text-white flex items-center justify-center absolute -top-4 -right-4">
                    {cartItemCount.cartItemCount}
                  </div>
                )}
              </div>
            </Link>

            <div>
              <Select
                components={{
                  DropdownIndicator: () => null,
                  IndicatorSeparator: () => null,
                }}
                defaultValue={options.find(
                  (option) => option.value === i18n.language
                )}
                options={options}
                isSearchable={false}
                className="w-16 shrink-0"
                onChange={onChangeLang}
              />
            </div>
          </div>
        </div>
      </nav>
    </>
  );
};

export default Header;
