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

  try {
    const response = await axios.get(url);
    return response.data;
  } catch (error) {
    throw error;
  }
}

export async function getOrdersKitchen() {
  const url = EndPoints.GetAllOrdersKitchen;

  try {
    const response = await axios.get(url);
    return response.data;
  } catch (error) {
    throw error;
  }
}

export async function getOrdersBar() {
  const url = EndPoints.GetAllOrdersKitchen;

  try {
    const response = await axios.get(url);
    return response.data;
  } catch (error) {
    throw error;
  }
}
