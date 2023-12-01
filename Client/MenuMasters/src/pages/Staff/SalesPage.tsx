import { useEffect, useState } from "react";
import Tab from "../../components/Staff/Tabs/Tab";
import { getOrdersSales } from "../../utils/api";
import { OrderSales } from "../../types/types";
import PayModal from "../../components/Staff/Modals/PayModal";

function SalesPage() {
  const [orderData, setOrderData] = useState<OrderSales[]>([]);
  const [errorMessage, setErrorMessage] = useState("");
  const [selectedTab, setSelectedTab] = useState<OrderSales | null>(null);
  const [isModalOpen, setIsModalOpen] = useState(false);

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

  const openModal = (tab: OrderSales) => {
    setSelectedTab(tab);
    setIsModalOpen(true);
  };

  const closeModal = () => {
    setSelectedTab(null);
    setIsModalOpen(false);
  };

  return (
    <div className="gray h-min-screen p-10">
      {errorMessage != "" ? (
        <>{errorMessage}</>
      ) : (
        <>
          {isModalOpen && selectedTab && (
            <PayModal tab={selectedTab} onClose={closeModal} />
          )}
          {orderData.length == null ? (
            <>No tabs</>
          ) : (
            <div
              className={`grid gray gap-10 grid-cols-3 ${
                isModalOpen ? "opacity-50 pointer-events-none" : ""
              } `}
            >
              {orderData
                .sort((a, b) => a.tableNumber - b.tableNumber)
                .map((tab) => (
                  <Tab key={tab.tabId} tab={tab} openModal={openModal} />
                ))}
            </div>
          )}
        </>
      )}
    </div>
  );
}

export default SalesPage;
