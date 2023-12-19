import { useState } from "react";
import { TabEntity } from "../../../types/types";
import Select from "react-select";
import { PayTab } from "../../../utils/api";

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
        <span>Pin</span>
      </div>
    ),
  },
];

interface PayModalProps {
  tab: TabEntity;
  onClose: () => void;
}

const PayModal: React.FC<PayModalProps> = ({ tab, onClose }) => {
  const [changeValue, setChangeValue] = useState(tab.moneyRemaining);
  const [visible, setVisible] = useState(true);
  const [inputValue, setInputValue] = useState("");
  const [selectedPaymentMethod, setSelectedPaymentMethod] = useState(
    options.find((option) => option.value === "cash")
  );

  const handleCloseClick = () => {
    setVisible(false);
    setTimeout(() => {
      onClose();
    }, 350);
  };

  const handleDigitClick = (digit: string) => {
    setInputValue((prevValue) => prevValue + digit);
  };

  const handleDotClick = () => {
    if (!inputValue.includes(".")) {
      setInputValue((prevValue) => prevValue + ".");
    }
  };

  const handleBackClick = () => {
    setInputValue((prevValue) => prevValue.slice(0, -1));
  };

  const handleClearClick = () => {
    setInputValue("");
  };

  const handlePayClick = async () => {
    if (inputValue != "") {
      const paidCash =
        selectedPaymentMethod?.value === "cash" ? parseFloat(inputValue) : 0;
      const paidPIN =
        selectedPaymentMethod?.value === "pin" ? parseFloat(inputValue) : 0;

      try {
        await PayTab(tab.tabId, paidCash, paidPIN);
        setChangeValue(
          parseFloat((changeValue - parseFloat(inputValue)).toFixed(2))
        );
        setInputValue("");
        console.log("Payment successful!");
      } catch (error) {
        console.error("Error processing payment:", error);
      }
    }
  };

  return (
    <>
      <div
        className={`fixed left-1/4 top-[10%] w-1/2 z-50 white rounded-3xl p-5 animate-swoop-in border border-gray-300 shadow-md ${
          visible ? "animate-swoop-in" : "animate-swoop-out"
        }`}
      >
        <div className="flex justify-end text-black text-3xl font-bold mb-5">
          <button onClick={handleCloseClick}>x</button>
        </div>
        <div className="flex justify-between items-center font-bold text-3xl mb-1">
          <div>Total</div>
          <div>{tab.tabTotal.toFixed(2)}</div>
        </div>
        <hr />
        <div className="mt-5 text-xl">payment method:</div>
        <Select
          id="PaymentMethod"
          options={options}
          value={selectedPaymentMethod}
          onChange={(selectedOption) =>
            setSelectedPaymentMethod(selectedOption!)
          }
          className="py-2 text-xl font-bold"
          isSearchable={false}
        />
        <div className="grid grid-cols-2 gap-2 text-xl">
          <div>
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
              value={changeValue}
            />
          </div>
        </div>
        <div className="flex py-4 font-bold text-6xl">
          <div className="grid grid-cols-3 gap-2 bg-gray-700 p-2 w-2/3 rounded-l-lg">
            {[1, 2, 3, 4, 5, 6, 7, 8, 9, 0].map((digit) => (
              <button
                key={digit}
                onClick={() => handleDigitClick(digit.toString())}
                className="py-5 font-bold bg-white rounded-md"
              >
                {digit}
              </button>
            ))}
            <button className=" bg-white rounded-md" onClick={handleDotClick}>
              .
            </button>
            <button onClick={handleClearClick} className="bg-white rounded-md">
              C
            </button>
          </div>
          <div className="w-1/3">
            <div className="h-full bg-gray-700 p-2 rounded-r-lg">
              <div className="h-1/2 pb-1">
                <button
                  className="bg-white rounded-md flex items-center justify-center h-full w-full p-2"
                  onClick={handleBackClick}
                >
                  <img
                    src="https://cdn-icons-png.flaticon.com/512/0/340.png"
                    className="object-contain max-h-full"
                    alt="Icon"
                  />
                </button>
              </div>
              <div className="h-1/2 pt-1">
                <button
                  onClick={handlePayClick}
                  className="green rounded-md flex items-center justify-center h-full w-full"
                >
                  PAY
                </button>
              </div>
            </div>
          </div>
        </div>
      </div>
    </>
  );
};

export default PayModal;
