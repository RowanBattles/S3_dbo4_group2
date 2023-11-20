import { useEffect, useState } from "react";
import Tab from "../../components/Tab";
import { getOrdersSales } from "../../utils/api";
import { OrderSales } from "../../types/types";

function SalesPage() {
  const [orderData, setOrderData] = useState<OrderSales[]>([]);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const data = await getOrdersSales();
        setOrderData(data);
        console.log(data);
      } catch (error) {
        console.error("Error fetching orders:", error);
      }
    };

    fetchData();
  }, []);

  return (
    <div className="gray h-min-screen p-10">
      <div className="columns-3">
        {orderData
          .sort((a, b) => a.tableNumber - b.tableNumber)
          .map((order) => (
            <Tab key={order.orderId} order={order} />
          ))}
      </div>
    </div>
  );
}

export default SalesPage;
