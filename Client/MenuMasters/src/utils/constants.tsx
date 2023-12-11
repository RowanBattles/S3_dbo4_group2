const URL = "https://localhost:7266";

const ENDPOINTS = {
  GetAllItems: `${URL}/api/Menu`,
  GetAllTabs: `${URL}/api/tab/sales`,
  GetAllOrdersKitchen: `${URL}/api/order/kitchen`,
  GetAllOrdersBar: `${URL}/api/order/bar`,
  GetAllCategories: `${URL}/api/Category`,
  GetItemById: (id: number) => `${URL}/api/Menu/${id}`,
  GetCategoryById: (id: number) => `${URL}/api/Category/${id}`,
  CreateOrder: `${URL}/api/Order`,
  PayTab: `${URL}/api/Tab/Pay`,
};

export default ENDPOINTS;
