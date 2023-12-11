import { TabEntity } from "../../../types/types";

interface TabProps {
  tab: TabEntity;
  openPayModal: () => void;
  openDeleteModal: () => void;
  openAddModal: () => void;
}

const Tab: React.FC<TabProps> = ({
  tab,
  openPayModal,
  openDeleteModal,
  openAddModal,
}) => {
  return (
    <div className="select-none relative flex flex-col h-full">
      <div className="red rounded-t-3xl p-4 border-x border-t border-slate-300">
        <div className="flex text-white justify-between">
          <div className="flex items-center gap-4">
            <img src="/src/assets/Table.png" className="h-8 invert" />
            <p>{tab.tableNumber}</p>
          </div>
          <div className="flex items-center gap-3">
            <img src="/src/assets/Hourglass.png" className="h-8 invert" />
            <p>
              {new Date(tab.date).toLocaleTimeString([], {
                hour: "2-digit",
                minute: "2-digit",
              })}
            </p>
          </div>
        </div>
      </div>
      <div className="white p-5 border-x border-slate-300 h-full">
        <ul>
          {tab.orderItems.map((item) => (
            <li key={item.orderItemId}>
              <div className="flex justify-between items-center mb-2">
                <p>
                  {item.quantity} x {item.itemName}
                </p>
                <p>
                  {item.quantity > 1 && (
                    <span className="mr-2">(€{item.itemPrice.toFixed(2)})</span>
                  )}
                  {(
                    parseFloat(item.itemPrice.toFixed(2)) * item.quantity
                  ).toFixed(2)}
                </p>
              </div>
            </li>
          ))}
          <li>
            <div className="flex justify-between items-center border-t-2 border-black border-dashed pt-2">
              <p>Total</p>
              <p>{tab.tabTotal.toFixed(2)}</p>
            </div>
          </li>
        </ul>
      </div>
      <div className="white rounded-b-3xl p-5 flex justify-between text-white border-x border-b border-slate-300">
        <div className="gap-4 flex">
          <button
            className="red px-5 py-1 rounded-full"
            onClick={openDeleteModal}
          >
            Delete
          </button>
          <button className="red px-5 py-1 rounded-full" onClick={openAddModal}>
            Add
          </button>
        </div>
        <div>
          <button className="red px-5 py-1 rounded-full" onClick={openPayModal}>
            Pay
          </button>
        </div>
      </div>
    </div>
  );
};

export default Tab;
