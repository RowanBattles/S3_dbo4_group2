import Plus_Min_Button from "../../components/Plus_Min_Button";
import { useState, useEffect } from "react";
import { useParams, Link } from "react-router-dom";
import Header from "../../components/Users/Header";
import { getItembyId } from "../../utils/api";
import { useTranslation } from "react-i18next";
import { RequestSales } from "../../utils/api";
import { MenuItem } from "../../types/types";
import useCustomToast from "../../utils/useToast";
import ItemDetails_Skeleton from "../../components/Users/Skeletons/ItemDetails_Skeleton";

const ItemDetails = () => {
  const [isConfirmationOpen, setIsConfirmationOpen] = useState(false);
  const [Item, setItem] = useState<MenuItem | null>(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);
  const [quantity, setQuantity] = useState(1); // Default quantity is 1
  const [totalPrice, setTotalPrice] = useState<number | null>(null);
  const { id } = useParams<{ id: string }>();
  const [showNotes, setShowNotes] = useState(false);
  const [notes, setNotes] = useState<string>("");
  const { showSuccessToast, showErrorToast } = useCustomToast();
  const { t } = useTranslation();

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

  useEffect(() => {
    const fetchFoodInfo = async () => {
      try {
        const itemId = parseInt(id as string, 10);

        if (isNaN(itemId)) {
          setError("Invalid item ID");
          console.log(error);
          setLoading(false);
          return;
        }

        const data = await getItembyId(itemId);
        setItem(data);
        setLoading(false);
      } catch (e) {
        showErrorToast("error");
        if (e instanceof Error) {
          setError(e.message);
        } else {
          setError("An error occurred");
        }
        setLoading(false);
      }
    };

    fetchFoodInfo();
  }, [id, error, showErrorToast]);

  useEffect(() => {
    const calculateTotalPrice = () => {
      if (Item) {
        const newTotalPrice = quantity * Item.itemPrice;
        setTotalPrice(newTotalPrice);
      }
    };

    calculateTotalPrice();
  }, [Item, quantity]);

  const addToCart = () => {
    // Check if Item is not null and quantity is greater than 0
    if (Item && quantity > 0) {
      // Get the existing cart items from localStorage or initialize an empty array
      const existingCartItems = JSON.parse(
        localStorage.getItem("cartItems") || "[]"
      ) as MenuItem[];

      // Create a new cart item object
      const newCartItem = {
        itemId: Item.menuItemId,
        itemName: Item.itemName,
        quantity: quantity,
        price: Item.itemPrice,
        image: Item.imageURL,
        notes: notes,

        // Add any other properties you want to store in the cart item
      };

      // Add the new cart item to the existing cart items
      const updatedCartItems = [...existingCartItems, newCartItem];

      // Update the localStorage with the updated cart items
      localStorage.setItem("cartItems", JSON.stringify(updatedCartItems));
      showSuccessToast("Item added to the cart successfully.");
    }
  };

  if (loading) {
    return (
      <>
        <Header onWaiterRequest={handleWaiter} />
        <ItemDetails_Skeleton />

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
  }
  return (
    <>
      <Header onWaiterRequest={handleWaiter} />
      <section className="max-w-screen-xl mx-auto px-6">
        <div className="flex flex-col justify-center items-center h-screen">
          <div
            className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-2 gap-10"
            key={Item?.menuItemId}
          >
            <div className="order-2 md:order-1 lg:order-1 flex flex-col justify-center">
              <h1 className="text-center md:text-left lg:text-left text-3xl lg:text-4xl font-semibold poppins pb-4 text-gray-700 select-none">
                {t(
                  `menu:${Item?.itemName.replace(/\s/g, "_")}.item_name`
                ).replace(/_/g, " ")}
              </h1>
              <div className="flex justify-center md:justify-normal lg:justify-normal">
                {Item?.dietaryInfo && ( // This line checks if dietaryInfo is not an empty string
                  <span className="bg-green-100 border border-[#18BD63] rounded-full text-[#18BD63] text-sm poppins px-4 py-1 inline-block mb-4 text-center md:text-left lg:text-left">
                    {t(
                      `menu:${Item?.itemName.replace(/\s/g, "_")}.dietary_info`
                    ).replace(/_/g, " ")}
                  </span>
                )}
              </div>

              <p className="text-center md:text-left lg:text-left text-sm poppins text-gray-500 leading-relaxed select-none">
                {t(
                  `menu:${Item?.itemName.replace(
                    /\s/g,
                    "_"
                  )}.item_description_long`
                ).replace(/_/g, " ")}
              </p>

              {Item?.ingredients && Item.ingredients.length > 0 && (
                <p className="text-center md:text-left lg:text-left text-sm poppins text-gray-500 leading-relaxed select-none mt-5">
                  <strong className="leading-relaxed select-none">
                    Ingredients:{" "}
                  </strong>
                  {t(
                    `menu:${Item?.itemName.replace(/\s/g, "_")}.ingredients`
                  ).replace(/_/g, " ")}
                </p>
              )}

              {showNotes && (
                <textarea
                  id="message"
                  rows={4}
                  className="block p-2.5 mt-6 w-full text-sm poppins text-gray-500 leading-relaxed  rounded-lg border border-gray-300 outline-none"
                  placeholder={t("common:translation:addKitchenInformation")}
                  value={notes} // Set the value of the textarea to the 'notes' state
                  onChange={(e) => setNotes(e.target.value)} // Update the 'notes' state on change
                ></textarea>
              )}
              <div className="flex ml-10 md:ml-0 lg:ml-0 items-center justify-center md:justify-start lg:justify-start space-x-6 pt-8">
                <h2 className="text-3xl w-20 font-medium text-black poppins select-none">
                  €{totalPrice} {/* Display the calculated total price */}
                </h2>
                <Plus_Min_Button
                  quantity={quantity}
                  setQuantity={setQuantity}
                />

                <button
                  onClick={() => setShowNotes(!showNotes)}
                  className="bg-primary text-white px-5 py-3 focus:outline-none poppins rounded-full transform transition duration-300 hover:scale-105 text-center"
                >
                  <h1>{t("common:translation:addNotes")}</h1>
                </button>
              </div>

              <Link to="/Menu">
                <div className="mt-8 flex items-center justify-center md:justify-start lg:justify-start gap-x-4">
                  <button
                    onClick={addToCart}
                    className="bg-primary text-white px-8 py-3 focus:outline-none poppins rounded-full transform transition duration-300 hover:scale-105 flex flex-row"
                  >
                    <div className="mr-2">
                      <svg
                        xmlns="http://www.w3.org/2000/svg"
                        height="24"
                        viewBox="0 -960 960 960"
                        width="24"
                        fill="#ffffff"
                      >
                        <path d="M280-80q-33 0-56.5-23.5T200-160q0-33 23.5-56.5T280-240q33 0 56.5 23.5T360-160q0 33-23.5 56.5T280-80Zm400 0q-33 0-56.5-23.5T600-160q0-33 23.5-56.5T680-240q33 0 56.5 23.5T760-160q0 33-23.5 56.5T680-80ZM246-720l96 200h280l110-200H246Zm-38-80h590q23 0 35 20.5t1 41.5L692-482q-11 20-29.5 31T622-440H324l-44 80h480v80H280q-45 0-68-39.5t-2-78.5l54-98-144-304H40v-80h130l38 80Zm134 280h280-280Z" />
                      </svg>
                    </div>
                    <h1>{t("common:translation:orderNow")}</h1>
                  </button>
                </div>
              </Link>
            </div>
            <div className="order-1 md:order-2 lg:order-2">
              <img
                src={Item?.imageURL}
                alt={Item?.itemName}
                className="w-3/4 md:w-3/4 lg:w-full mx-auto"
              />
            </div>
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

export default ItemDetails;
