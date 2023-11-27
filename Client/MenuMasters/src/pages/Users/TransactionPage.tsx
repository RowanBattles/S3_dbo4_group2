import React, { useState, useEffect, useMemo } from "react";
import Transaction from "../../components/Transaction";
import Header from "../../components/Header";

import { CartItem } from "../../types/types";
import { createOrder } from "../../utils/api";

const TransactionPage = () => {
  const [cartItems, setCartItems] = useState<CartItem[]>([]);

  useEffect(() => {
    const storedCartItemsString = localStorage.getItem("cartItems");
    if (storedCartItemsString) {
      try {
        const storedCartItems = JSON.parse(storedCartItemsString);
        setCartItems(storedCartItems);
      } catch (error) {
        console.error("Error parsing cart items:", error);
        // Handle the error gracefully, e.g. show an error message to the user or provide a fallback
      }
    }
  }, []);

  const handleQuantityChange = (index) => (newQuantity) => {
    setCartItems((prevCartItems) => {
      const updatedCartItems = [...prevCartItems];
      updatedCartItems[index].quantity = newQuantity;
      localStorage.setItem("cartItems", JSON.stringify(updatedCartItems));
      return updatedCartItems;
    });
  };

  const handleOrderNow = async () => {
    // Create an order using the /api/Order endpoint
    try {
      await createOrder({
        tabId: 0,
        orderItems: cartItems.map((item) => ({
          menuItemId: item.id, // Assuming your CartItem has an 'id' property
          notes: "", // Add any notes if needed
          quantity: item.quantity,
        })),
      });

      // Clear the cart after successfully placing the order
      setCartItems([]);
      localStorage.removeItem("cartItems");
    } catch (error) {
      console.error("Error creating order:", error);
      // Handle the error gracefully
    }
  };

  const handleRemoveItem = (itemToRemove: CartItem) => {
    const updatedCartItems = cartItems.filter((item) => item !== itemToRemove);
    setCartItems(updatedCartItems);
    localStorage.setItem("cartItems", JSON.stringify(updatedCartItems));
  };

  const totalPrice = useMemo(() => {
    return cartItems.reduce((total, item) => {
      return total + item.price * item.quantity;
    }, 0);
  }, [cartItems]);

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
            onQuantityChange={handleQuantityChange(index)}
          />
        ))}

        <div className="flex flex-row justify-between items-center">
          <button
            onClick={handleOrderNow}
            className="bg-primary text-white px-9 py-3 text-xl focus:outline-none poppins rounded-full transform transition duration-300 hover:scale-105"
          >
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
