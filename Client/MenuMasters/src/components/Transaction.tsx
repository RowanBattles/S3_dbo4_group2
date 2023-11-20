import { useEffect, useState } from "react";
import Plus_Min_Button from "./Plus_Min_Button";

// ... (import statements)

const Transaction = ({ item, onQuantityChange, onRemove }) => {
  const [quantity, setQuantity] = useState(item.quantity);

  // Notify the parent component when the quantity changes
  useEffect(() => {
    onQuantityChange(quantity);
  }, [quantity, onQuantityChange]);
  return (
    <div className="grid grid-cols-3 md:grid-cols-4 lg:grid-cols-5 gap-4 items-center">
      <img
        src={item.image}
        className="col-span-1 h-auto w-full "
        alt={item.itemName}
      />
      <h1 className="col-span-1 text-3xl text-center hidden md:hidden lg:inline">
        {item.itemName}
      </h1>
      <div className="col-span-1 flex justify-center items-center ">
        <Plus_Min_Button quantity={quantity} setQuantity={setQuantity} />
      </div>

      <h2 className="col-span-1 text-gray-900 poppins text-3xl font-medium text-center hidden md:inline lg:inline">
        ${(item.price * quantity).toFixed(2)}
      </h2>

      <button
        className="col-span-1 text-3xl font-medium transform transition duration-300 hover:scale-105 text-center"
        onClick={() => onRemove(item)}
      >
        X
      </button>

      <hr className="col-span-5 h-px bg-[#F3F4F6] border-0 my-8"></hr>
    </div>
  );
};

export default Transaction;
