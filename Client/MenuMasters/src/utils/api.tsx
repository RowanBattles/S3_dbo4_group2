import axios from "axios";
import { ENDPOINTS } from "./constants";

export async function getItems() {
  const url = ENDPOINTS.GetAllItems;

  const response = await axios.get(url);
  return response.data;
}

export async function getCategories() {
  const url = ENDPOINTS.GetAllCategories;

  const response = await axios.get(url);
  return response.data;
}

export async function getItembyId(id: number) {
  const url = ENDPOINTS.GetItemById(id);
  const response = await axios.get(url);
  return response.data;
}

export async function getCategoryById(id: number) {
  const url = ENDPOINTS.GetCategoryById(id);
  const response = await axios.get(url);
  return response.data;
}

export async function getTabs() {
  const url = ENDPOINTS.GetAllTabs;

  const response = await axios.get(url);
  return response.data;
}

export async function getOrdersKitchen() {
  const url = ENDPOINTS.GetAllOrdersKitchen;

  const response = await axios.get(url);
  return response.data;
}

export async function getOrdersBar() {
  const url = ENDPOINTS.GetAllOrdersBar;

  const response = await axios.get(url);
  return response.data;
}

export async function PayTab(tabId: number, paidCash: number, paidPIN: number) {
  const url = ENDPOINTS.PayTab;
  const response = await axios.patch(url, {
    tabId,
    paidCash,
    paidPIN,
  });
  return response.data;
}

export async function DeleteProducts(
  items: { orderItemId: number; quantity: number }[]
) {
  const url = ENDPOINTS.DeleteProducts;
  const response = await axios.patch(url, items);
  console.log(response);
  return response.data;
}

export async function createOrder(orderData: any) {
  const url = ENDPOINTS.CreateOrder;
  const response = await axios.post(url, orderData);
  return response.data;
}

export async function StatusKitchen(id: number) {
  const url = ENDPOINTS.StatusKitchen(id);
  const response = await axios.patch(url);
  return response.data;
}

export async function StatusBar(id: number) {
  const url = ENDPOINTS.StatusBar(id);
  const response = await axios.patch(url);
  return response.data;
}

export async function GetAccessCode() {
  const url = ENDPOINTS.GetAccessCode;
  const response = await axios.get(url);
  return response.data;
}

export async function GenerateAccesCode() {
  const url = ENDPOINTS.GenerateAccessCode;
  const response = await axios.get(url);
  return response.data;
}
