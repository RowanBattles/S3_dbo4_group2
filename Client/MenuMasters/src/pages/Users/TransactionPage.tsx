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
import { RequestSales } from "../../utils/api";

const TransactionPage = () => {
  const [isConfirmationOpen, setIsConfirmationOpen] = useState(false);
  const [cookie] = useCookies(["tafelNummer"]);
  const [cartItems, setCartItems] = useState<CartItem[]>([]);
  const { showSuccessToast, showErrorToast } = useCustomToast();
  const [loading, setLoading] = useState(false);
  const { t } = useTranslation();
  const [headerKey, setHeaderKey] = useState(0);

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

  const handleClearCart = () => {
    setCartItems([]);
    localStorage.removeItem("cartItems");
    // Optionally, you can trigger a rerender of the Header component
    setHeaderKey((prevKey) => prevKey + 1);
  };

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
    setHeaderKey((prevKey) => prevKey + 1);
  };

  const totalPrice = useMemo(() => {
    return cartItems.reduce((total, item) => {
      return total + item.price * item.quantity;
    }, 0);
  }, [cartItems]);

  const handleWaiter = () => {
    setIsConfirmationOpen(true);
  };

  const confirmRequestWaiter = async () => {
    try {
      await RequestSales(localStorage.TabId, 2);
      setIsConfirmationOpen(false);
      showSuccessToast("Waiter requested succesfully");
    } catch (error) {
      console.error(error);
      showErrorToast("Something went wrong while requesting the waiter");
    }
  };

  const cancelRequestWaiter = () => {
    setIsConfirmationOpen(false);
  };

  return (
    <>
      <Header key={headerKey} onWaiterRequest={handleWaiter} />

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

        <div className="flex flex-col my-8">
          <h2 className="text-gray-900 poppins text-4xl font-medium mb-4 mx-auto">
            {t("common:translation:total")}: €{totalPrice.toFixed(2)}
          </h2>
          <div className="flex flex-row gap-x-6">
            <button
              onClick={handleClearCart}
              disabled={cartItems.length === 0} // Disable if the cart is already empty
              className="flex-grow bg-red-500 text-white px-4 py-2 text-xl focus:outline-none poppins rounded-full transform transition duration-300 hover:scale-105"
            >
              {t("common:translation:clearCart")}
            </button>
            <button
              onClick={handleOrderNow}
              disabled={loading || cartItems.length === 0} // Disable if the cart is empty
              className="flex-grow bg-primary text-white px-9 py-3 text-xl focus:outline-none poppins rounded-full transform transition duration-300 hover:scale-105"
            >
              {loading ? (
                <LoadingSpinner size={20} color="#ffffff" />
              ) : (
                t("common:translation:orderNow")
              )}
            </button>
          </div>
        </div>
      </section>

      {isConfirmationOpen && (
        <div className="fixed top-0 left-0 w-full h-full flex items-center justify-center bg-black bg-opacity-50">
          <div className="bg-white p-4 rounded shadow">
            <p>Are you sure you want to request the waiter?</p>
            <div className="flex justify-end mt-4">
              <button
                className="mr-2 font-semibold border-black border-2 rounded px-4 py-1"
                onClick={cancelRequestWaiter}
              >
                Cancel
              </button>
              <button
                className="ml-2 text-white bg-black rounded py-1 px-4"
                onClick={confirmRequestWaiter}
              >
                Yes
              </button>
            </div>
          </div>
        </div>
      )}
    </>
  );
};

export default TransactionPage;
