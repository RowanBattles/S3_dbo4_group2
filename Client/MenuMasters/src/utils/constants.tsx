const URL_MENU = "https://localhost:7266";
const URL_STAFF = "http://localhost:7244";

const ENDPOINTS = {
  GetAllItems: `${URL_MENU}/api/Menu`,
  GetAllTabs: `${URL_STAFF}/api/tab/sales`,
  GetAllOrdersKitchen: `${URL_STAFF}/api/order/kitchen`,
  GetAllOrdersBar: `${URL_STAFF}/api/order/bar`,
  GetAllCategories: `${URL_MENU}/api/Category`,
  GetItemById: (id: number) => `${URL_MENU}/api/Menu/${id}`,
  GetCategoryById: (id: number) => `${URL_MENU}/api/Category/${id}`,
  CreateOrder: `${URL_MENU}/api/Order`,
  PayTab: `${URL_STAFF}/api/Tab/Pay`,
};

export default ENDPOINTS;
