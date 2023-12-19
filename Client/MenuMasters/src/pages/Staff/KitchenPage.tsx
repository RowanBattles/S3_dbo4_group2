import { useEffect, useState } from "react";
import Tab from "../../components/Staff/Tabs/KitchenTab";
import { getOrdersKitchen } from "../../utils/api";
import { OrderStaff } from "../../types/types";

function KitchenPage() {
  const [orderData, setOrderData] = useState<OrderStaff[]>([]);
  const [errorMessage, setErrorMessage] = useState("");

  const fetchData = async () => {
    try {
      console.log("hit");
      const data = await getOrdersKitchen();
      setOrderData(data);
      console.log(data);
    } catch (error) {
      console.error("Error fetching orders:", error);
      setErrorMessage("Error with server");
    }
  };

  useEffect(() => {
    fetchData();
  }, []);

  return (
    <div className="gray h-screen p-10">
      {errorMessage != "" ? (
        <>{errorMessage}</>
      ) : (
        <>
          {orderData.length == 0 ? (
            <>No orders</>
          ) : (
            <div className="grid gray gap-10 grid-cols-3">
              {orderData
                .sort((a, b) => a.tableNumber - b.tableNumber)
                .map((order) => (
                  <Tab key={order.orderId} order={order} update={fetchData} />
                ))}
            </div>
          )}
        </>
      )}
    </div>
  );
}

export default KitchenPage;
