import React from "react";
import Logo from "../../assets/Menu_Masters_Logo.png";
import { Link } from "react-router-dom";
import { useTranslation } from "react-i18next";
import { LANGUAGES } from "../../utils/constants/Languages";

const Header = () => {
  const { i18n, t } = useTranslation();

  const onChangeLang = (e: React.ChangeEvent<HTMLSelectElement>) => {
    const langCode = e.target.value;

    // Make sure that the language code is valid
    if (LANGUAGES.some((language) => language.code === langCode)) {
      i18n.changeLanguage(langCode);
    }
  };

  return (
    <nav className="max-w-screen-xl mx-auto">
      <div className="flex justify-between items-center">
        <Link to="/Menu">
          <img src={Logo} className="w-56 h-auto" />
        </Link>

        <div className="flex flex-row gap-x-5 px-6 ">
          <h1>Tafel 1</h1>

          <Link to="/Cart">
            <div>{t("common:translation:shoppingcart")}</div>
          </Link>

          <select
            defaultValue={i18n.language}
            onChange={onChangeLang}
            className="bg-white"
          >
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
