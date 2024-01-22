import { useEffect, useState } from "react";
import { RequestSales, getTabById } from "../../utils/api";
import { OrderItemSales } from "../../types/types";
import useCustomToast from "../../utils/useToast";
import { Link } from "react-router-dom";
import { useTranslation } from "react-i18next";

function Receipt() {
  const { t } = useTranslation();
  const { showSuccessToast, showErrorToast } = useCustomToast();
  const [items, setItems] = useState<OrderItemSales[]>([]);
  const [total, setTotal] = useState(0);
  const [paid, setPaid] = useState(false);
  const [tab, setTab] = useState(false);

  const fetchTab = async () => {
    try {
      const response = await getTabById(localStorage.TabId);
      mergeItemsByMenuItemId(response.orderItems);
      setTotal(response.tabTotal);
      setPaid(response.paid);
    } catch (error) {
      showErrorToast("error while retrieving tab");
    }
  };

  const mergeItemsByMenuItemId = (orderItems: OrderItemSales[]) => {
    const reducedItems: OrderItemSales[] = [];

    orderItems.forEach((currentItem) => {
      const existingItemIndex = reducedItems.findIndex(
        (item) => item.menuItemId === currentItem.menuItemId
      );

      if (existingItemIndex !== -1) {
        reducedItems[existingItemIndex].quantity += currentItem.quantity;
      } else {
        reducedItems.push({ ...currentItem });
      }
    });

    setItems(reducedItems);
  };

  const handleReceipt = async () => {
    try {
      await RequestSales(localStorage.TabId, 1);
      showSuccessToast("Requested bill succesfully");
    } catch (error) {
      console.error(error);
      showErrorToast("Error requesting the bill");
    }
  };

  useEffect(() => {
    if (localStorage.TabId) {
      setTab(true);
      fetchTab();
    } else {
      setTab(false);
    }
  }, []);

  return (
    <div className="bg-gray-100 h-screen p-10 min-w-[200px] min-h-screen">
      <div className="select-none relative flex flex-col h-full">
        <Link to="/menu">
          <div className="absolute top-4 text-black right-6 z-50 font-semibold text-2xl cursor-pointer">
            X
          </div>
        </Link>
        <div
          className="red py-3 px-6 rounded-full absolute bottom-4 text-white right-4 z-50 font-semibold text-xl cursor-pointer"
          onClick={handleReceipt}
        >
          {t("common:translation:requestBill")}
        </div>

        <div className="white p-5 py-16 border rounded-3xl border-slate-300 h-full relative">
          {tab ? (
            <>
              {paid ? (
                <div className="h-full w-full flex flex-col items-center justify-center">
                  <div className="w-1/2 h-1/2 flex justify-center">
                    <img
                      src="https://uxwing.com/wp-content/themes/uxwing/download/checkmark-cross/success-green-check-mark-icon.png"
                      className="object-contain h-full mb-4"
                      alt="Centered Image"
                    />
                  </div>
                  <div className="mt-4 text-center">
                    <p className="font-semibold text-green-500 text-xs min-[320px]:text-xl sm:text-2xl md:text-4xl">
                      {t("common:translation:payed")}
                    </p>
                  </div>
                </div>
              ) : (
                <>
                  <ul className="h-[90%]">
                    {items.map((item) => (
                      <li key={item.orderItemId}>
                        <div className="flex justify-between items-center mb-2 gap-5">
                          <p>
                            {item.quantity} x{" "}
                            {t(
                              `menu:${item.itemName.replace(
                                /\s/g,
                                "_"
                              )}.item_name`
                            ).replace(/_/g, " ")}
                          </p>
                          <p>
                            {item.quantity > 1 && (
                              <span className="mr-2">
                                (€{item.itemPrice.toFixed(2)})
                              </span>
                            )}
                            {(
                              parseFloat(item.itemPrice.toFixed(2)) *
                              item.quantity
                            ).toFixed(2)}
                          </p>
                        </div>
                      </li>
                    ))}
                  </ul>
                  <div className="flex justify-between items-center border-t-2 border-black border-dashed pt-2">
                    <p>{t("common:translation:total")}</p>
                    <p>{total}</p>
                  </div>
                </>
              )}
            </>
          ) : (
            <div className="h-full w-full flex flex-col items-center justify-center">
              <div className="w-1/2 h-1/2 flex justify-center">
                <img
                  src="https://cdn-icons-png.flaticon.com/512/0/697.png"
                  className="object-contain h-full mb-4"
                  alt="Centered Image"
                />
              </div>
              <div className="mt-4 text-center">
                <p className="font-semibold text-xs min-[320px]:text-xl sm:text-2xl md:text-4xl">
                  {t("common:translation:noOrderYet")}
                </p>
              </div>
            </div>
          )}
        </div>
      </div>
    </div>
  );
}

export default Receipt;
