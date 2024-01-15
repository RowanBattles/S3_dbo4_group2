import Select from "react-select";
import Logo from "../../assets/Menu_Masters_Logo.png";
import { Link } from "react-router-dom";
import { useTranslation } from "react-i18next";
import { LANGUAGES } from "../../utils/constants/Languages";

const Header = () => {
  const { i18n, t } = useTranslation();

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

  return (
    <nav className="max-w-screen-xl mx-auto">
      <div className="flex justify-between items-center">
        <Link to="/Menu">
          <img src={Logo} className="w-56 h-auto" />
        </Link>

        <div className="flex flex-row gap-x-5 px-6 items-center">
          <h1>Tafel 1</h1>

          <Link to="/Receipt">
            <div>{t("common:translation:receipt")}</div>
          </Link>

          <Link to="/TransactionPage">
            <div>{t("common:translation:shoppingcart")}</div>
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
