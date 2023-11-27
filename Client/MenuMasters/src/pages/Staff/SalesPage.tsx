import { useEffect, useState } from "react";
import Tab from "../../components/Tab";
import { getOrdersSales } from "../../utils/api";
import { OrderSales } from "../../types/types";

function SalesPage() {
  const [orderData, setOrderData] = useState<OrderSales[]>([]);
  const [errorMessage, setErrorMessage] = useState("");

  useEffect(() => {
    const fetchData = async () => {
      try {
        const data = await getOrdersSales();
        setOrderData(data);
        console.log(data);
      } catch (error) {
        console.error("Error fetching orders:", error);
        setErrorMessage("Error with server");
      }
    };

    fetchData();
  }, []);

  return (
    <div className="gray h-screen p-10">
      {errorMessage != "" ? (
        <>{errorMessage}</>
      ) : (
        <>
          {orderData.length == null ? (
            <>No orders</>
          ) : (
            <div className="grid gray gap-10 grid-cols-3">
              {orderData
                .sort((a, b) => a.tableNumber - b.tableNumber)
                .map((order) => (
                  <Tab key={order.orderId} order={order} />
                ))}
            </div>
          )}
        </>
      )}
    </div>
  );
}

export default SalesPage;
