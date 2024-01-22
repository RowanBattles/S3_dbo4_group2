import { useState, useEffect, useMemo } from "react";
import Transaction from "../../components/Users/Transaction";
import Header from "../../components/Users/Header";
import React from "react";
import { useTranslation } from "react-i18next";
import { CartItem } from "../../types/types";
import { createOrder } from "../../utils/api";
import useCustomToast from "../../utils/useToast";
import LoadingSpinner from "../../utils/useLoadingSpinner";
import { useCookies } from "react-cookie";

const TransactionPage = () => {
  const [cookie] = useCookies(["tafelNummer"]);
  const [cartItems, setCartItems] = useState<CartItem[]>([]);
  const { showSuccessToast, showErrorToast } = useCustomToast();
  const [loading, setLoading] = useState(false);
  const { t } = useTranslation();
  const [rerenderHeader, setRerenderHeader] = useState(false);

  useEffect(() => {
    const storedCartItemsString = localStorage.getItem("cartItems");
    if (storedCartItemsString) {
      try {
        const storedCartItems = JSON.parse(storedCartItemsString);
        setCartItems(storedCartItems);
      } catch (error) {
        console.error("Error parsing cart items:", error);
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
        notes: item.notes || "",
        quantity: item.quantity,
      }));

      const response = await createOrder({
        orderItems: orderItems,
        tableNumber: cookie.tafelNummer,
      });

      const tabId = response.tabId;
      localStorage.setItem("TabId", tabId);

      setCartItems([]);
      localStorage.removeItem("cartItems");
      showSuccessToast("Order created successfully");
    } catch (error) {
      setLoading(false);
      console.error("Error creating order:", error);
      showErrorToast("Something went wrong while creating your order");
    } finally {
      setLoading(false);
    }
  };

  const handleRemoveItem = (itemToRemove: CartItem) => {
    const updatedCartItems = cartItems.filter((item) => item !== itemToRemove);
    setCartItems(updatedCartItems);
    localStorage.setItem("cartItems", JSON.stringify(updatedCartItems));

    // Trigger the rerender of the Header component
    setRerenderHeader((prev) => !prev);
  };

  const totalPrice = useMemo(() => {
    return cartItems.reduce((total, item) => {
      return total + item.price * item.quantity;
    }, 0);
  }, [cartItems]);

  return (
    <>
      <Header key={rerenderHeader} />
      <div className="flex justify-center items-center my-10">
        <hr className="w-28 h-1 bg-primary border-0 rounded mx-4"></hr>
        <h1 className="text-4xl font-medium uppercase">Order</h1>
        <hr className="w-28 h-1 bg-primary border-0 rounded mx-4"></hr>
      </div>
      <section className="my-20 max-w-screen-lg mx-auto px-6">
        {cartItems.map((item, index) => (
          <Transaction
            key={index}
            item={item}
            onRemove={handleRemoveItem}
            onQuantityChange={handleQuantityChange(index)}
          />
        ))}

        <div className="flex flex-col  my-8">
          <h2 className="text-gray-900 poppins text-4xl font-medium mb-4 mx-auto">
            {t("common:translation:total")}: €{totalPrice.toFixed(2)}
          </h2>
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
      </section>
    </>
  );
};

export default TransactionPage;
