import React, { useState, useEffect } from "react";
import Transaction from "../../components/Transaction";
import Header from "../../components/Header";

import { CartItem } from "../../types/types";

const TransactionPage = () => {
  const [cartItems, setCartItems] = useState<CartItem[]>([]);

  // Get the cart items from localStorage on component mount
  useEffect(() => {
    const storedCartItemsString = localStorage.getItem("cartItems");
    if (storedCartItemsString) {
      const storedCartItems = JSON.parse(storedCartItemsString);
      setCartItems(storedCartItems);
    }
  }, []);

  // Update the quantity of an item in the cart
  const handleQuantityChange = (index: number, newQuantity: number) => {
    const updatedCartItems = [...cartItems];
    updatedCartItems[index].quantity = newQuantity;
    setCartItems(updatedCartItems);
  };

  const handleRemoveItem = (itemToRemove: CartItem) => {
    const updatedCartItems = cartItems.filter((item) => item !== itemToRemove);
    setCartItems(updatedCartItems);
    localStorage.setItem("cartItems", JSON.stringify(updatedCartItems));
  };

  // Calculate total based on cart items
  const totalPrice = cartItems.reduce((total, item) => {
    return total + item.price * item.quantity;
  }, 0);

  return (
    <>
      <Header />
      <div className="flex justify-center items-center my-10">
        <hr className="w-28 h-1 bg-primary border-0 rounded mx-4"></hr>
        <h1 className="text-4xl font-medium uppercase">Order</h1>
        <hr className="w-28 h-1 bg-primary border-0 rounded mx-4"></hr>
      </div>
      <section className="my-20 max-w-screen-xl mx-auto px-6">
        {cartItems.map((item, index) => (
          <Transaction
            key={index}
            item={item}
            onRemove={handleRemoveItem}
            onQuantityChange={(newQuantity: number) =>
              handleQuantityChange(index, newQuantity)
            }
          />
        ))}

        <div className="flex flex-row justify-between items-center">
          <button className="bg-primary text-white px-9 py-3 text-xl focus:outline-none poppins rounded-full transform transition duration-300 hover:scale-105">
            Order Now
          </button>
          <h2 className="text-gray-900 poppins text-4xl font-medium">
            Total: ${totalPrice.toFixed(2)}
          </h2>
        </div>
      </section>
    </>
  );
};

export default TransactionPage;
