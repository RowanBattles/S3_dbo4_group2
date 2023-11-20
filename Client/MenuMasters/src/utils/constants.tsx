const URL = "https://localhost:7244";

const ENDPOINTS = {
  GetAllItems: `${URL}/api/menuitem`,
  GetAllOrdersSales: `${URL}/api/order/sales`,
  GetAllOrdersKitchen: `${URL}/api/order/kitchen`,
  GetAllOrdersBar: `${URL}/api/order/bar`,
  GetItemById: (id: number) => `${URL}/api/menuitem/${id}`,
  GetCategoryById: (id: number) => `${URL}/api/Category/${id}`,
};

export default ENDPOINTS;
