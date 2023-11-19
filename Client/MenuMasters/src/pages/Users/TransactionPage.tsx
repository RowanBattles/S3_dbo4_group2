import React, { useState, useEffect } from "react";
import Transaction from "../../components/Transaction";
import Header from "../../components/Header";

const TransactionPage = () => {
  const [cartItems, setCartItems] = useState([]);

  // Get the cart items from localStorage on component mount
  useEffect(() => {
    const storedCartItems = JSON.parse(localStorage.getItem("cartItems")) || [];
    setCartItems(storedCartItems);
  }, []);

  // Update the quantity of an item in the cart
  const handleQuantityChange = (index, newQuantity) => {
    const updatedCartItems = [...cartItems];
    updatedCartItems[index].quantity = newQuantity;
    setCartItems(updatedCartItems);
  };

  // Calculate total based on cart items
  const totalPrice = cartItems.reduce((total, item) => {
    return total + item.price * item.quantity;
  }, 0);

  return (
    <>
      <Header />
      <section className="my-20 max-w-screen-xl mx-auto px-6">
        {cartItems.map((item, index) => (
          <Transaction
            key={index}
            item={item}
            onQuantityChange={(newQuantity) =>
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
