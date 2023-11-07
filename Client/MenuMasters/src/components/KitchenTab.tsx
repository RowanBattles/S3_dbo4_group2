import { useState } from "react";

const KitchenTab = () => {
  const [selectedItems, setSelectedItems] = useState(["red", "red", "red"]);

  const handleItemClick = (index: number) => {
    const updatedSelectedItems = [...selectedItems];
    if (updatedSelectedItems[index] === "red") {
      updatedSelectedItems[index] = "yellow";
    } else if (updatedSelectedItems[index] === "yellow") {
      updatedSelectedItems[index] = "green";
    }
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
    <div>
      <div
        className={`${headerColor()} rounded-t-3xl p-4 border-x border-t border-slate-300`}
      >
        <div className="flex text-white justify-between">
          <div className="flex items-center gap-4">
            <img src="/src/assets/Table.png" className="h-8 invert" />
            <p>Table 1</p>
          </div>
          <div className="flex items-center gap-3">
            <img src="/src/assets/Hourglass.png" className="h-8 invert" />
            <p>17:46</p>
          </div>
        </div>
      </div>
      <div
        className={`white p-5 border-x border-slate-300 ${
          headerColor() === "green" ? "pb-0" : "pb-8"
        } border-b rounded-b-3xl rounded`}
      >
        <ul>
          <li
            className="mb-2 cursor-pointer"
            onClick={() => handleItemClick(0)}
          >
            <div className="flex items-center">
              <hr className={`w-2 mr-5 ${selectedItems[0]} border-0 h-8`} />
              <p>1 x Borrelplank</p>
            </div>
          </li>
          <li
            className="mb-2 cursor-pointer"
            onClick={() => handleItemClick(1)}
          >
            <div className="flex items-center">
              <hr className={`w-2 mr-5 ${selectedItems[1]} border-0 h-8`} />
              <p>1 x Soep</p>
            </div>
          </li>
          <li
            className="flex items-center mb-2 cursor-pointer"
            onClick={() => handleItemClick(2)}
          >
            <hr className={`w-2 mr-5 ${selectedItems[2]} border-0 h-8`} />
            <div className="">
              <p>2 x Nachos</p>
              <p className="italic text-xs text-red-500">Zonder Jalapeños</p>
            </div>
          </li>
        </ul>
        {headerColor() === "green" && (
          <div className="white p-5 flex justify-end text-white gap-4">
            <button className="green px-5 py-1 rounded-full">Confirm</button>
          </div>
        )}
      </div>
    </div>
  );
};

export default KitchenTab;
