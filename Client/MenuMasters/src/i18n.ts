import i18n from "i18next";
import { initReactI18next } from "react-i18next";

i18n.use(initReactI18next).init({
  fallbackLng: "en",
  lng: "en",
  interpolation: {
    escapeValue: false,
  },
  resources: {
    en: {
      translation: {
        table: "Table 1",
        cart: "Cart",
      },
    },
    nl: {
      translation: {
        table: "Tafel 1",
        cart: "Winkelmandje",
      },
    },
  },
});

export default i18n;
