import axios from "axios";
import EndPoints from "./constants";

export async function getItems() {
  const url = EndPoints.GetAllItems;

  const response = await axios.get(url);
  return response.data;
}

export async function getCategories() {
  const url = EndPoints.GetAllCategories;

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

export async function getTabs() {
  const url = EndPoints.GetAllTabs;

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

export async function PayTab(tabId: number, paidCash: number, paidPIN: number) {
  const url = EndPoints.PayTab;
  const response = await axios.patch(url, {
    tabId,
    paidCash,
    paidPIN,
  });
  return response.data;
}

export async function createOrder(orderData: any) {
  const url = EndPoints.CreateOrder;
  const response = await axios.post(url, orderData);
  return response.data;
}
