import { useEffect, useState } from "react";
import Tab from "../../components/Staff/Tabs/Tab";
import { getTabs } from "../../utils/api";
import { TabEntity } from "../../types/types";
import PayModal from "../../components/Staff/Modals/PayModal";
import DeleteModal from "../../components/Staff/Modals/DeleteModal";
import AddModal from "../../components/Staff/Modals/AddModal";

function SalesPage() {
  const [orderData, setOrderData] = useState<TabEntity[]>([]);
  const [errorMessage, setErrorMessage] = useState("");
  const [selectedTab, setSelectedTab] = useState<TabEntity | null>(null);
  const [isPayModalOpen, setIsPayModalOpen] = useState(false);
  const [isDeleteModalOpen, setIsDeleteModalOpen] = useState(false);
  const [isAddModalOpen, setIsAddModalOpen] = useState(false);

  const fetchTabs = async () => {
    try {
      const data = await getTabs();
      filterTabsPaid(data);
    } catch (error) {
      console.error("Error fetching orders:", error);
      setErrorMessage("Error with server");
    }
  };

  const filterTabsPaid = (data: TabEntity[]) => {
    const filteredTabs = data.filter((tab) => !tab.paid);
    console.log("Filtered Tabs:", filteredTabs);
    setOrderData(filteredTabs);
  };

  const openPayModal = (tab: TabEntity) => {
    setSelectedTab(tab);
    setIsPayModalOpen(true);
  };

  const openDeleteModal = (tab: TabEntity) => {
    setSelectedTab(tab);
    setIsDeleteModalOpen(true);
  };

  const openAddModal = (tab: TabEntity) => {
    setSelectedTab(tab);
    setIsAddModalOpen(true);
  };

  const closeModal = () => {
    fetchTabs();
    setSelectedTab(null);
    setIsPayModalOpen(false);
    setIsDeleteModalOpen(false);
    setIsAddModalOpen(false);
  };

  useEffect(() => {
    fetchTabs();
  }, []);

  return (
    <div className="gray min-h-screen p-10 select-none">
      {errorMessage != "" ? (
        <>{errorMessage}</>
      ) : (
        <>
          {isPayModalOpen && selectedTab && (
            <PayModal tab={selectedTab} onClose={closeModal} />
          )}
          {isDeleteModalOpen && selectedTab && (
            <DeleteModal tab={selectedTab} onClose={closeModal} />
          )}
          {isAddModalOpen && selectedTab && (
            <AddModal
              tableNumber={selectedTab.tableNumber}
              onClose={closeModal}
            />
          )}
          {orderData.length == 0 ? (
            <div>No tabs</div>
          ) : (
            <div
              className={`grid gray gap-10 sm:grid-cols-1 max-w-full sm:max-w-[75%] lg:grid-cols-2 lg:max-w-full 2xl:grid-cols-3 min-[2000px]:grid-cols-4 ${
                isPayModalOpen || isDeleteModalOpen || isAddModalOpen
                  ? "opacity-50 pointer-events-none"
                  : ""
              } `}
            >
              {orderData
                .sort((a, b) => a.tableNumber - b.tableNumber)
                .map((tab) => (
                  <Tab
                    key={tab.tabId}
                    tab={tab}
                    openPayModal={() => openPayModal(tab)}
                    openDeleteModal={() => openDeleteModal(tab)}
                    openAddModal={() => openAddModal(tab)}
                  />
                ))}
            </div>
          )}
        </>
      )}
    </div>
  );
}

export default SalesPage;
