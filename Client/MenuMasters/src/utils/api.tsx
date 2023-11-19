import axios from "axios";
import EndPoints from "./constants";

export async function getItems() {
  const url = EndPoints.GetAllItems;

  const response = await axios.get(url);
  return response.data;
}

export async function getItembyId(id: number) {
  const url = EndPoints.GetItemById(id); // Call the function to get the complete URL
  const response = await axios.get(url);
  return response.data;
}

export async function getCategoryById(id: number) {
  const url = EndPoints.GetCategoryById(id);
  const response = await axios.get(url);
  return response.data;
}
