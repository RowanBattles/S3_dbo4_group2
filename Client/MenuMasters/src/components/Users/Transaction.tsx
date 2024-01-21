import { useState } from "react";
import Plus_Min_Button from "../Plus_Min_Button";

interface TransactionProps {
  item: any;
  onQuantityChange: any;
  onRemove: any;
}

const Transaction: React.FC<TransactionProps> = ({
  item,
  onQuantityChange,
  onRemove,
}) => {
  const [quantity, setQuantity] = useState(item.quantity);

  const handleQuantityChange = (newQuantity: any) => {
    setQuantity(newQuantity);
    onQuantityChange(newQuantity);
  };
  return (
    <>
      <div className="flex items-center border-b border-red-500 p-4">
        <img
          src={item.image}
          className="h-24 w-24 rounded"
          alt={item.itemName}
        />
        <div className="flex-grow ml-4">
          <h1 className="text-lg font-bold mb-2">{item.itemName}</h1>
          <div className="flex items-center">
            <Plus_Min_Button
              quantity={quantity}
              setQuantity={handleQuantityChange}
            />
          </div>
        </div>

        <span className="text-black ml-2">
          €{(item.price * quantity).toFixed(2)}
        </span>

        <button
          className="text-xl font-medium text-red-500 ml-4"
          onClick={() => onRemove(item)}
        >
          X
        </button>
      </div>
    </>
  );
};

export default Transaction;
