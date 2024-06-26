import { Category, MenuItem } from "../../../types/types";
import { useEffect, useState } from "react";
import { getCategories, getItems, createOrder } from "../../../utils/api";

interface PayModalProps {
  tableNumber: number;
  onClose: () => void;
}

interface OrderItems {
  itemName: string;
  itemPrice: number;
  menuItemId: number;
  quantity: number;
}

const AddModal: React.FC<PayModalProps> = ({ onClose, tableNumber }) => {
  const [visible, setVisible] = useState(true);
  const [categories, setCategories] = useState<Category[]>([]);
  const [items, setItems] = useState<MenuItem[]>([]);
  const [activeCategory, setActiveCategory] = useState(1);
  const [orderItems, setOrderItems] = useState<OrderItems[]>([]);
  const [Totalprice, setTotalPrice] = useState(0);

  const handleItemClick = (clickedItem: MenuItem) => {
    const existingItemIndex = orderItems.findIndex(
      (item) => item.menuItemId === clickedItem.menuItemId
    );

    if (existingItemIndex !== -1) {
      const updatedOrderItems = [...orderItems];
      updatedOrderItems[existingItemIndex].quantity += 1;
      setOrderItems(updatedOrderItems);
    } else {
      setOrderItems((prevOrderItems) => [
        ...prevOrderItems,
        {
          menuItemId: clickedItem.menuItemId,
          quantity: 1,
          itemName: clickedItem.itemName,
          itemPrice: clickedItem.itemPrice,
        },
      ]);
    }
  };

  useEffect(() => {
    const totalPrice = orderItems.reduce((accumulator, selectedItem) => {
      return (
        accumulator + (selectedItem.itemPrice * selectedItem.quantity || 0)
      );
    }, 0);

    setTotalPrice(totalPrice);
  }, [orderItems]);

  const handleCloseClick = () => {
    setVisible(false);
    setTimeout(() => {
      onClose();
    }, 350);
  };

  useEffect(() => {
    const fetchData = async () => {
      try {
        const data = await getCategories();
        setCategories(data);
      } catch (error) {
        console.error("Error fetching orders:", error);
      }
    };

    fetchData();
  }, []);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const data = await getItems();
        setItems(data);
      } catch (error) {
        console.error("Error fetching orders:", error);
      }
    };

    fetchData();
  }, [activeCategory]);

  const handleCategoryClick = (Id: number) => {
    setActiveCategory(Id);
  };

  const filteredItems = activeCategory
    ? items.filter((item) => item.categoryId === activeCategory)
    : items;

  const CreateOrder = async () => {
    try {
      await createOrder({
        tableNumber: tableNumber,
        orderItems: orderItems,
      });
      handleCloseClick();
    } catch (error) {
      console.log(error);
    }
  };

  return (
    <>
      <div
        className={`fixed left-[12.5%] top-[10%] w-3/4 z-50 green rounded-3xl p-5 h-3/4 min-w-[1130px] flex flex-col animate-swoop-in mb-10 pt-16 ${
          visible ? "animate-swoop-in" : "animate-swoop-out"
        }`}
      >
        <button
          className="absolute top-5 right-5 text-3xl text-white font-bold"
          onClick={handleCloseClick}
        >
          X
        </button>
        <div className="flex h-full">
          <div className="bg-gray-800 w-1/6 rounded-l-2xl p-5">
            <ul className="max-h-full overflow-y-auto">
              {categories.map((c) => (
                <li className="mb-1 relative" key={c.categoryId}>
                  <button
                    onClick={() => handleCategoryClick(c.categoryId)}
                    className={`w-full rounded-3xl py-8 text-2xl font-semibold  ${
                      activeCategory === c.categoryId
                        ? "bg-white text-red-500"
                        : "red text-white"
                    }`}
                  >
                    {c.categoryName}
                  </button>
                </li>
              ))}
            </ul>
          </div>
          <div className="bg-gray-800 w-3/6 p-5">
            <ul className="grid-cols-3 max-h-full overflow-y-auto grid gap-5">
              {filteredItems.map((i) => (
                <li key={i.menuItemId}>
                  <div
                    className="w-full py-24 yellow relative rounded-2xl text-2xl text-white cursor-pointer"
                    onClick={() => handleItemClick(i)}
                  >
                    <div
                      className={`absolute top-1/2 left-1/2 -translate-x-1/2 w-full px-2 -translate-y-1/2 text-center break-keep line-clamp-2 ${
                        i.itemName.length > 20 ? "text-lg" : ""
                      }`}
                    >
                      {i.itemName}
                    </div>
                    <div className="absolute bottom-5 left-1/2 -translate-x-1/2">
                      {i.itemPrice.toFixed(2)}
                    </div>
                  </div>
                </li>
              ))}
            </ul>
          </div>
          <div className="bg-gray-800 h-full w-2/6 p-5 rounded-r-2xl">
            <div className="bg-white h-5/6 w-full ">
              <ul className="h-5/6 p-5 text-xl">
                {orderItems.map((i) => (
                  <li className="flex justify-between" key={i.menuItemId}>
                    <div>
                      {i.quantity} x {i.itemName}
                    </div>
                    <div>€{(i.itemPrice * i.quantity).toFixed(2)}</div>
                  </li>
                ))}
              </ul>
              <hr
                style={{
                  width: "90%",
                  margin: "0 auto",
                  border: "none",
                  borderBottom: "3px dashed",
                }}
              />
              <div className="h-1/6 px-6 flex justify-between items-center text-2xl font-semibold">
                <div>Total</div>
                <div>{Totalprice.toFixed(2)}</div>
              </div>
            </div>
            <div className="h-1/6 px-2 pt-2">
              <button
                className="h-full w-full green rounded-full text-4xl font-bold flex justify-center items-center"
                onClick={CreateOrder}
              >
                <span>Add to cart</span>
                <img
                  className="h-12"
                  src="https://static.vecteezy.com/system/resources/previews/019/787/018/original/shopping-cart-icon-shopping-basket-on-transparent-background-free-png.png"
                />
              </button>
            </div>
          </div>
        </div>
      </div>
    </>
  );
};

export default AddModal;
