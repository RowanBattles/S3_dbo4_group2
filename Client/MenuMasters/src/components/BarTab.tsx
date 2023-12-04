import { useState } from "react";
import { OrderStaff } from "../types/types";

function BarTab({ order }: { order: OrderStaff }) {
  const [selectedItems, setSelectedItems] = useState<Array<string>>(
    new Array(order.orderItems.length).fill("red")
  );

  const handleItemClick = (index: number) => {
    const updatedSelectedItems = [...selectedItems];
    updatedSelectedItems[index] = "green";
    setSelectedItems(updatedSelectedItems);
  };

  const handleItemClickReverse = (index: number) => {
    const updatedSelectedItems = [...selectedItems];
    updatedSelectedItems[index] = "red";
    setSelectedItems(updatedSelectedItems);
  };

  const headerColor = () => {
    if (selectedItems.every((color) => color === "red")) {
      return "red";
    } else if (selectedItems.every((color) => color === "green")) {
      return "green";
    } else {
      return "yellow";
    }
  };

  return (
    <div className="select-none relative flex flex-col h-full">
      <div
        className={`${headerColor()} rounded-t-3xl p-4 border-x border-t border-slate-300`}
      >
        <div className="flex text-white justify-between">
          <div className="flex items-center gap-4">
            <img src="/src/assets/Table.png" className="h-8 invert" />
            <p>{order.tableNumber}</p>
          </div>
          <div className="flex items-center gap-3">
            <img src="/src/assets/Hourglass.png" className="h-8 invert" />
            <p>
              {new Date(order.dateTime).toLocaleTimeString([], {
                hour: "2-digit",
                minute: "2-digit",
              })}
            </p>
          </div>
        </div>
      </div>
      <div
        className={`flex-1 white p-5 border-x border-slate-300 border-b rounded-b-3xl rounded pb-12`}
      >
        <div>
          <div className="mb-2 ml-7">
            <div className="text-xs">Itemcount: {order.orderItems.length}</div>
          </div>
          <ul>
            {order.orderItems.map((item, index) => (
              <li className="mb-2" key={index}>
                <div className="flex justify-between items-center">
                  <div
                    className="flex items-center cursor-pointer"
                    onClick={() => handleItemClick(index)}
                  >
                    <hr
                      className={`w-2 ${selectedItems[index]} border-0 h-8 mr-5 min-w-fit`}
                    />
                    <div className="w-full break-word">
                      <p>
                        {item.quantity} x {item.itemName}
                      </p>
                      <span className="text-red-500 text-xs italic">
                        {item.notes}
                      </span>
                    </div>
                  </div>
                  <div
                    className="flex items-center cursor-pointer min-w-fit"
                    onClick={() => handleItemClickReverse(index)}
                  >
                    <img
                      src="https://static.thenounproject.com/png/3547811-200.png"
                      className="h-8"
                    />
                  </div>
                </div>
              </li>
            ))}
          </ul>
          <div></div>
        </div>
        {headerColor() === "green" && (
          <div className="absolute bottom-0 right-0 p-5 text-white">
            <button className="green px-5 py-1 rounded-full">Confirm</button>
          </div>
        )}
      </div>
    </div>
  );
}

export default BarTab;
