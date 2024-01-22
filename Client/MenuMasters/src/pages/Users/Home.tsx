import { useState } from "react";
import Items from "../../components/Users/Skeletons/Food_item/Items";
import Header from "../../components/Users/Header";
import useCustomToast from "../../utils/useToast";
import { RequestSales } from "../../utils/api";

const Home = () => {
  const [isConfirmationOpen, setIsConfirmationOpen] = useState(false);
  const { showSuccessToast, showErrorToast } = useCustomToast();

  const handleWaiter = () => {
    setIsConfirmationOpen(true);
  };

  const confirmRequestWaiter = async () => {
    try {
      await RequestSales(localStorage.TabId, 2);
      setIsConfirmationOpen(false);
      showSuccessToast("Waiter requested succesfully");
    } catch (error) {
      console.error(error);
      showErrorToast("Something went wrong while requesting the waiter");
    }
  };

  const cancelRequestWaiter = () => {
    setIsConfirmationOpen(false);
  };

  return (
    <div>
      <Header onWaiterRequest={handleWaiter} />
      <Items />

      {isConfirmationOpen && (
        <div className="fixed top-0 left-0 w-full h-full flex items-center justify-center bg-black bg-opacity-50">
          <div className="bg-white p-4 rounded shadow">
            <p>Are you sure you want to request the waiter?</p>
            <div className="flex justify-end mt-4">
              <button
                className="mr-2 font-semibold border-black border-2 rounded px-4 py-1"
                onClick={cancelRequestWaiter}
              >
                Cancel
              </button>
              <button
                className="ml-2 text-white bg-black rounded py-1 px-4"
                onClick={confirmRequestWaiter}
              >
                Yes
              </button>
            </div>
          </div>
        </div>
      )}
    </div>
  );
};

export default Home;
