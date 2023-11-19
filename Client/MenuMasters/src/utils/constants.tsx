const URL = "https://localhost:7244";

const ENDPOINTS = {
  GetAllItems: `${URL}/api/menuitem`,
  GetItemById: (id: number) => `${URL}/api/menuitem/${id}`,
  GetCategoryById: (id: number) => `${URL}/api/Category/${id}`,
};

export default ENDPOINTS;
