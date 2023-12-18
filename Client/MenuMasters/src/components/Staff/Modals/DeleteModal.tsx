import { useState } from "react";
import { OrderItemSales, TabEntity } from "../../../types/types";
import { DeleteProducts } from "../../../utils/api";

interface PayModalProps {
  tab: TabEntity;
  onClose: () => void;
}

const PayModal: React.FC<PayModalProps> = ({ tab, onClose }) => {
  const [visible, setVisible] = useState(true);
  const [OrderedItems, setOrderedItems] = useState(tab.orderItems);
  const [CorrectionItems, setCorrectionItems] = useState<OrderItemSales[]>([]);

  const handleCloseClick = () => {
    setVisible(false);
    setTimeout(() => {
      onClose();
    }, 350);
  };

  const handleOrderItemClick = (clickedItem: OrderItemSales) => {
    if (clickedItem.quantity > 0) {
      const updatedOrderedItems = OrderedItems.map((item) =>
        item.orderItemId === clickedItem.orderItemId
          ? { ...item, quantity: Math.max(0, item.quantity - 1) }
          : item
      );

      const existingCorrectionItemIndex = CorrectionItems.findIndex(
        (item) => item.orderItemId === clickedItem.orderItemId
      );

      if (existingCorrectionItemIndex !== -1) {
        const updatedCorrectionItems = [...CorrectionItems];
        updatedCorrectionItems[existingCorrectionItemIndex].quantity += 1;
        setCorrectionItems(updatedCorrectionItems);
      } else {
        setCorrectionItems((prevCorrectionItems) => [
          ...prevCorrectionItems,
          { ...clickedItem, quantity: 1 },
        ]);
      }

      setOrderedItems(updatedOrderedItems);
    }
  };

  const handleCorrectionItemClick = (clickedItem: OrderItemSales) => {
    const existingCorrectionItem = CorrectionItems.find(
      (item) => item.orderItemId === clickedItem.orderItemId
    );

    if (existingCorrectionItem?.quantity && clickedItem.quantity >= 0) {
      const updatedCorrectionItems = CorrectionItems.map((item) =>
        item.orderItemId === clickedItem.orderItemId
          ? { ...item, quantity: Math.max(0, item.quantity - 1) }
          : item
      );

      const updatedOrderedItems = [...OrderedItems];
      const existingOrderedItemIndex = OrderedItems.findIndex(
        (item) => item.orderItemId === clickedItem.orderItemId
      );
      updatedOrderedItems[existingOrderedItemIndex].quantity += 1;

      setCorrectionItems(updatedCorrectionItems);
      setOrderedItems(updatedOrderedItems);
    }
  };

  const handleCorrectionClick = async () => {
    const itemsToUpdate = OrderedItems.map(({ orderItemId, quantity }) => ({
      orderItemId,
      quantity,
    }));

    try {
      await DeleteProducts(itemsToUpdate);
      handleCloseClick();
    } catch (error) {
      console.error("error proceeding deleting products: ", error);
    }
  };

  return (
    <>
      <div
        className={`fixed left-[12.5%] top-[10%] w-3/4 z-50 red rounded-3xl p-5 h-3/4 min-w-[1130px] flex flex-col animate-swoop-in mb-10 pt-16 ${
          visible ? "animate-swoop-in" : "animate-swoop-out"
        }`}
      >
        <button
          className="absolute top-5 right-5 text-3xl text-white font-bold"
          onClick={handleCloseClick}
        >
          X
        </button>
        <div className="flex h-full gap-5">
          <div className="bg-gray-800 w-1/2 rounded-xl p-4">
            <ul className="grid-cols-3 max-h-full overflow-y-auto grid gap-5">
              {OrderedItems.map((item) => (
                <li
                  key={item.orderItemId}
                  onClick={() => handleOrderItemClick(item)}
                  className={`yellow relative rounded-2xl text-2xl h-[200px] text-white cursor-pointer ${
                    item.quantity == 0 ? "hidden" : ""
                  }`}
                >
                  <div className="absolute top-1/2 left-1/2 -translate-x-1/2 w-full px-2 -translate-y-1/2 text-center break-keep line-clamp-2">
                    {item.itemName}
                  </div>
                  <div className="absolute bottom-5 left-1/2 -translate-x-1/2">
                    {item.quantity}
                  </div>
                </li>
              ))}
            </ul>
          </div>
          <div className="bg-gray-800 w-1/2 rounded-xl p-4">
            <div className="h-5/6 pb-2">
              <ul className="grid-cols-3 max-h-full overflow-y-auto grid gap-5">
                {CorrectionItems.map((item) => (
                  <li
                    onClick={() => handleCorrectionItemClick(item)}
                    key={item.orderItemId}
                    className={`yellow relative rounded-2xl text-2xl h-[200px] text-white cursor-pointer ${
                      item.quantity == 0 ? "hidden" : ""
                    }`}
                  >
                    <div className="absolute top-1/2 left-1/2 -translate-x-1/2 w-full px-2 -translate-y-1/2 text-center break-keep line-clamp-2">
                      {item.itemName}
                    </div>
                    <div className="absolute bottom-5 left-1/2 -translate-x-1/2">
                      {item.quantity}
                    </div>
                  </li>
                ))}
              </ul>
            </div>
            <div className="h-1/6 pt-2">
              <button
                className="h-full w-full red rounded-full text-4xl font-bold flex justify-center items-center gap-5"
                onClick={handleCorrectionClick}
              >
                <span>Correction</span>
                <img
                  src="https://cdn-icons-png.flaticon.com/512/0/340.png"
                  className="h-1/2"
                />
              </button>
            </div>
          </div>
        </div>
      </div>
    </>
  );
};

export default PayModal;
