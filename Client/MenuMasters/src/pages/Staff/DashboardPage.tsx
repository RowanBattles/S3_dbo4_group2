import { useEffect, useState } from "react";
import { GenerateAccesCode, GetAccessCode } from "../../utils/api";

function DashboardPage() {
  const [accessCode, setAccesCode] = useState("");

  const ReceiveAccessCode = async () => {
    try {
      const data = await GetAccessCode();
      setAccesCode(data.code);
    } catch (error) {
      console.error(error);
    }
  };

  const handleGenerateCode = async () => {
    try {
      await GenerateAccesCode();
      ReceiveAccessCode();
    } catch (error) {
      console.log(error);
    }
  };

  useEffect(() => {
    console.log("hit");
    ReceiveAccessCode();
  }, [accessCode]);

  return (
    <div className="flex">
      <div className="bg-red-400 h-screen w-1/6">
        <div className="px-20 py-5">
          <img className="w-full" src="/src/assets/Menu_Masters_Logo3.png" />
        </div>
        <ul className="grid grid-flow-row gap-1 overflow-hidden">
          <li className="flex items-center p-5 border-y-2 gap-4 text-white red cursor-pointer">
            <img
              className="h-14 w-14 invert"
              src="https://cdn1.iconfinder.com/data/icons/social-productivity-line-art-4/128/password-512.png"
            />
            <span className="">Authorization code</span>
          </li>
        </ul>
      </div>
      <div className="w-5/6 bg-gray-100 flex items-center justify-center">
        <div className="bg-white p-12 rounded-lg shadow-md w-full max-w-xl">
          <p className="text-4xl font-bold mb-8 text-center">Access Code</p>
          <div className="flex flex-col space-y-4">
            <input
              className="text-center text-2xl border border-gray-300 rounded-md py-4 focus-visible:outline-none cursor-default font-mono font-semi-bold tracking-widest"
              id="accessCode"
              readOnly
              placeholder="loading..."
              value={accessCode}
            />
            <button
              className="w-full bg-neutral-950 rounded-md text-white text-2xl py-4 flex items-center justify-center gap-4 active:bg-neutral-700"
              onClick={handleGenerateCode}
            >
              <span>Generate code</span>
              <img
                src="https://cdn-icons-png.flaticon.com/512/37/37913.png"
                className="h-6 invert"
              />
            </button>
          </div>
        </div>
      </div>
    </div>
  );
}

export default DashboardPage;
