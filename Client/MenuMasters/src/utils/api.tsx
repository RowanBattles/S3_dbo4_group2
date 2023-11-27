import axios from "axios";
import EndPoints from "./constants";

export async function getItems() {
  const url = EndPoints.GetAllItems;

  const response = await axios.get(url);
  return response.data;
}

export async function getItembyId(id: number) {
  const url = EndPoints.GetItemById(id);
  const response = await axios.get(url);
  return response.data;
}

export async function getCategoryById(id: number) {
  const url = EndPoints.GetCategoryById(id);
  const response = await axios.get(url);
  return response.data;
}

export async function getOrdersSales() {
  const url = EndPoints.GetAllOrdersSales;

  const response = await axios.get(url);
  return response.data;
}

export async function getOrdersKitchen() {
  const url = EndPoints.GetAllOrdersKitchen;

  const response = await axios.get(url);
  return response.data;
}

export async function getOrdersBar() {
  const url = EndPoints.GetAllOrdersBar;

  const response = await axios.get(url);
  return response.data;
}

export async function createOrder(orderData) {
  const url = EndPoints.CreateOrder; // Assuming you have a CreateOrder endpoint in your ENDPOINTS file
  const response = await axios.post(url, orderData);
  return response.data;
}
