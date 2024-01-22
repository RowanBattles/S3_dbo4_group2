const URL_MENU = "https://localhost:7266";
const URL_STAFF = "https://localhost:7244";

export const ENDPOINTS = {
  GetAllItems: `${URL_MENU}/api/Menu`,
  GetAllTabs: `${URL_STAFF}/api/tab/sales`,
  GetAllOrdersKitchen: `${URL_STAFF}/api/order/kitchen`,
  GetAllOrdersBar: `${URL_STAFF}/api/order/bar`,
  GetAllCategories: `${URL_MENU}/api/Category`,
  GetItemById: (id: number) => `${URL_MENU}/api/Menu/${id}`,
  GetTabById: (id: number) => `${URL_STAFF}/api/Tab/Sales/${id}`,
  GetCategoryById: (id: number) => `${URL_MENU}/api/Category/${id}`,
  CreateOrder: `${URL_STAFF}/api/Order`,
  PayTab: `${URL_STAFF}/api/Tab/Pay`,
  DeleteProducts: `${URL_STAFF}/api/Order/Item`,
  RequestSales: `${URL_STAFF}/api/Tab/Request`,
  StatusKitchen: (id: number) =>
    `${URL_STAFF}/api/Order/Status/Kitchen?id=${id}`,
  StatusBar: (id: number) => `${URL_STAFF}/api/Order/Status/Bar?id=${id}`,

  GetAccessCode: `${URL_MENU}/api/GETAccesscode`,
  GenerateAccessCode: `${URL_MENU}/api/generate`,
};
