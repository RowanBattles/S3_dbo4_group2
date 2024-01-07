import { useState, useEffect, useMemo } from "react";
import Transaction from "../../components/Users/Transaction";
import Header from "../../components/Users/Header";
import React from "react";
import { useTranslation } from "react-i18next";
import { CartItem } from "../../types/types";
import { createOrder } from "../../utils/api";
import useCustomToast from "../../utils/useToast";
import LoadingSpinner from "../../utils/useLoadingSpinner";

const TransactionPage = () => {
  const [cartItems, setCartItems] = useState<CartItem[]>([]);
  const { showSuccessToast, showErrorToast } = useCustomToast();
  const [loading, setLoading] = useState(false);
  const { t } = useTranslation();

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

  const handleQuantityChange = React.useCallback(
    (index: any) => (newQuantity: any) => {
      setCartItems((prevCartItems) => {
        const updatedCartItems = [...prevCartItems];
        updatedCartItems[index].quantity = newQuantity;
        localStorage.setItem("cartItems", JSON.stringify(updatedCartItems));
        return updatedCartItems;
      });
    },
    []
  );

  const handleOrderNow = async () => {
    try {
      setLoading(true);
      const orderItems = cartItems.map((item: CartItem) => ({
        menuItemId: item.itemId,
        notes: item.notes || "", // You might want to update this based on where notes are stored
        quantity: item.quantity,
      }));

      await createOrder({
        tabId: 1,
        orderItems: orderItems,
      });

      // Clear the cart after successfully placing the order
      setCartItems([]);
      localStorage.removeItem("cartItems");
      showSuccessToast("Order created successfully");
    } catch (error) {
      setLoading(false);
      console.error("Error creating order:", error);
      showErrorToast("Something went wrong while creating your order");
      // Handle the error gracefully
    } finally {
      setLoading(false);
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
      <section className="my-12 max-w-screen-xl mx-auto px-6">
        {cartItems.map((item, index) => (
          <Transaction
            key={index}
            item={item}
            onRemove={handleRemoveItem}
            onQuantityChange={handleQuantityChange(index)}
          />
        ))}

        <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-2 gap-10 ">
          <div className="order-2 md:order-1 lg:order-1 text-center md:text-left lg:text-left">
            <button
              onClick={handleOrderNow}
              disabled={loading || cartItems.length === 0} // Disable if the cart is empty
              className="bg-primary text-white px-9 py-3 text-xl focus:outline-none poppins rounded-full transform transition duration-300 hover:scale-105"
            >
              {loading ? (
                <LoadingSpinner size={20} color="#ffffff" />
              ) : (
                t("common:translation:orderNow")
              )}
            </button>
          </div>

          <h2 className="text-gray-900 poppins text-4xl font-medium order-1 md:order-2 lg:order-2 text-center md:text-right lg:text-right">
            {t("common:translation:total")}: €{totalPrice.toFixed(2)}
          </h2>
        </div>
      </section>
    </>
  );
};

export default TransactionPage;
