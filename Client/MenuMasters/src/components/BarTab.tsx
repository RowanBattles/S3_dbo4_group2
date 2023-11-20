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
    <div className="select-none">
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
        className={`white p-5 border-x border-slate-300 ${
          headerColor() === "green" ? "pb-0" : "pb-8"
        } border-b rounded-b-3xl rounded`}
      >
        <div>
          <div className="mb-2 ml-7">
            <div className="text-xs">Itemcount: {order.orderItems.length}</div>
          </div>
          <ul>
            {order.orderItems.map((item, index) => (
              <li className="mb-2" key={index}>
                <div className="flex justify-between">
                  <div
                    className="flex items-center cursor-pointer"
                    onClick={() => handleItemClick(index)}
                  >
                    <hr
                      className={`w-2 mr-5 ${selectedItems[index]} border-0 h-8`}
                    />
                    <p>
                      {item.quantity} x {item.itemName}
                    </p>
                  </div>
                  <div
                    className="flex items-center cursor-pointer"
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
          <div>
            <div className="ml-7 text-red-500 italic text-xs">
              {order.notes}
            </div>
          </div>
        </div>
        {headerColor() === "green" && (
          <div className="white p-5 flex justify-end text-white gap-4">
            <button className="green px-5 py-1 rounded-full">Confirm</button>
          </div>
        )}
      </div>
    </div>
  );
}

export default BarTab;
