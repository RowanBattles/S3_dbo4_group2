import { useEffect, useState } from "react";
import Tab from "../../components/BarTab";
import { getOrdersBar } from "../../utils/api";
import { OrderStaff } from "../../types/types";

function BarPage() {
  const [orderData, setOrderData] = useState<OrderStaff[]>([]);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const data = await getOrdersBar();
        setOrderData(data);
        console.log(data);
      } catch (error) {
        console.error("Error fetching orders:", error);
      }
    };

    fetchData();
  }, []);

  return (
    <div className="gray h-screen p-10">
      <div className="grid gray gap-10 grid-cols-3">
        {orderData.map((order) => (
          <Tab key={order.orderId} order={order} />
        ))}
      </div>
    </div>
  );
}

export default BarPage;
