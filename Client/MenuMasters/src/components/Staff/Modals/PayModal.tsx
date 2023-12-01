import { useState } from "react";
import { OrderSales } from "../../../types/types";
import Select from "react-select";

const options = [
  {
    value: "cash",
    label: (
      <div className="flex items-center pl-5 w-20">
        <img
          className="w-10 mr-2"
          src="https://cdn-icons-png.flaticon.com/512/4470/4470504.png"
          alt="Cash"
        />
        <span>Cash</span>
      </div>
    ),
  },
  {
    value: "pin",
    label: (
      <div className="flex items-center pl-5">
        <img
          className="w-10 mr-2"
          src="https://static.thenounproject.com/png/2272416-200.png"
          alt="Pin"
        />
        <span>Cash</span>
      </div>
    ),
  },
];

interface PayModalProps {
  tab: OrderSales;
  onClose: () => void;
}

const PayModal: React.FC<PayModalProps> = ({ tab, onClose }) => {
  const [inputValue, setInputValue] = useState("");

  const handleDigitClick = (digit: string) => {
    setInputValue((prevValue) => prevValue + digit);
  };

  const handleDotClick = () => {
    // Ensure there's only one dot in the input
    if (!inputValue.includes(".")) {
      setInputValue((prevValue) => prevValue + ".");
    }
  };

  const handleClearClick = () => {
    setInputValue("");
  };

  return (
    <>
      <div className="absolute left-1/4 w-1/2 h-4/5 z-50 bg-yellow-500 rounded-3xl p-5">
        <div
          className="flex justify-end text-white text-3xl font-bold cursor-pointer mb-5"
          onClick={onClose}
        >
          x
        </div>
        <div className="flex justify-between items-center font-bold text-lg mb-1">
          <div className="text-white">Amount to pay</div>
          <div className="text-blue-500">{tab.tabTotal}</div>
        </div>
        <hr />
        <div className="mt-5 text-xs">payment method:</div>
        <Select
          id="PaymentMethod"
          options={options}
          defaultValue={options.find((option) => option.value === "cash")}
          className="py-2 text-xs font-bold"
          isSearchable={false}
        />
        <div className="grid grid-cols-2 gap-2 text-s">
          <div className="">
            <p>Tendered</p>
            <input
              type="number"
              className="w-full rounded-md p-2"
              value={inputValue === "" ? "" : parseFloat(inputValue).toFixed(2)}
              step="0.01"
              pattern="\d+(\.\d{2})?"
              readOnly
            />
          </div>
          <div>
            <p>Change</p>
            <input
              className="w-full rounded-md p-2 cursor-default outline:none"
              readOnly
              value={124.23}
            />
          </div>
        </div>
        <div className="grid grid-cols-3 gap-2 mt-5">
          {[1, 2, 3, 4, 5, 6, 7, 8, 9, 0].map((digit) => (
            <button
              key={digit}
              onClick={() => handleDigitClick(digit.toString())}
              className="py-2 text-xs font-bold bg-white rounded-md"
            >
              {digit}
            </button>
          ))}
          <button
            className="py-2 text-xs font-bold bg-white rounded-md"
            onClick={handleDotClick}
          >
            .
          </button>
          <button
            onClick={handleClearClick}
            className="py-2 text-xs font-bold bg-white rounded-md"
          >
            C
          </button>
        </div>
      </div>
    </>
  );
};

export default PayModal;
