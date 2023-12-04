import { TabEntity } from "../../../types/types";
import { useState } from "react";

interface PayModalProps {
  tab: TabEntity;
  onClose: () => void;
}

const AddModal: React.FC<PayModalProps> = ({ tab, onClose }) => {
  const [visible, setVisible] = useState(true);

  const handleCloseClick = () => {
    setVisible(false);
    setTimeout(() => {
      onClose();
    }, 350);
  };

  return (
    <>
      <div
        className={`absolute left-[12.5%] top-[10%] w-3/4 z-50 green rounded-3xl p-5 h-3/4 min-w-[1130px] flex flex-col animate-swoop-in ${
          visible ? "animate-swoop-in" : "animate-swoop-out"
        }`}
      >
        <div className="flex justify-end text-white text-3xl font-bold mb-2">
          <button onClick={handleCloseClick}>x</button>
        </div>
        <div className="flex h-full">
          <div className="bg-gray-800 w-1/6 rounded-l-2xl p-5 shrink-0">
            <ul className="max-h-full overflow-y-auto">
              <li className="mb-1 relative">
                <button className="red w-full rounded-3xl py-8 text-2xl font-semibold text-white">
                  Category
                </button>
              </li>
            </ul>
          </div>
          <div className="bg-gray-800 w-3/6 p-5">
            <ul className="h-full w-full grid grid-cols-4 gap-4 overflow-y-auto">
              <li>
                <div className="w-full py-24 yellow flex justify-center items-center relative rounded-2xl text-2xl text-white cursor-pointer">
                  <span>itemnaam</span>
                  <div className="absolute bottom-5"> prijs</div>
                </div>
              </li>
            </ul>
          </div>
          <div className="bg-gray-800 h-full w-2/6 p-5 rounded-r-2xl">
            <div className="bg-white h-5/6 w-full ">
              <ul className="h-5/6 p-5 text-xl">
                <li className="flex justify-between">
                  <div>1x itemnaam</div>
                  <div>prijs</div>
                </li>
              </ul>
              <hr
                style={{
                  width: "90%",
                  margin: "0 auto", // Center the <hr /> horizontally
                  border: "none",
                  borderBottom: "3px dashed", // Replace #000 with your desired color
                }}
              />
              <div className="h-1/6 px-6 flex justify-between items-center text-2xl font-semibold">
                <div>Totaal</div>
                <div>prijs</div>
              </div>
            </div>
            <div className="h-1/6 px-2 pt-2">
              <button className="h-full w-full green rounded-full text-4xl font-bold flex justify-center items-center">
                <span>Add to cart</span>
                <img
                  className="h-12"
                  src="https://static.vecteezy.com/system/resources/previews/019/787/018/original/shopping-cart-icon-shopping-basket-on-transparent-background-free-png.png"
                />
              </button>
            </div>
          </div>
        </div>
      </div>
    </>
  );
};

export default AddModal;
