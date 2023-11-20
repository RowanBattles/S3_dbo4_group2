import axios from "axios";
import EndPoints from "./contstants";

export async function getItems() {
  const url = EndPoints.GetAllItems;

  try {
    const response = await axios.get(url);
    return response.data;
  } catch (error) {
    throw error;
  }
}

export async function getOrdersKichen() {
  const url = EndPoints.GetAllItems;

  try {
    const response = await axios.get(url);
    return response.data;
  } catch (error) {
    throw error;
  }
}
