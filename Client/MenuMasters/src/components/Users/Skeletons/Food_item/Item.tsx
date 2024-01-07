import { Link } from "react-router-dom";
import { useTranslation } from "react-i18next";

interface ItemProps {
  image: string;
  title: string;
  description: string;
  price: number;
  foodType: string;
  id: number;
  dietaryInfo: string;
}

const Item = ({
  image,
  title,
  description,
  price,
  foodType,
  id,
  dietaryInfo,
}: ItemProps) => {
  const { t } = useTranslation();

  return (
    <Link to={`/details/${id}`}>
      <div className="bg-white border border-gray-100 transition transform duration-700 hover:shadow-xl hover:scale-105 p-4 rounded-lg relative">
        <div className="flex justify-between">
          <span className="bg-red-100 border border-red-500 rounded-full text-primary text-sm poppins px-4 py-1 inline-block mb-4 ">
            {foodType}
          </span>
          {dietaryInfo && ( // This line checks if dietaryInfo is not an empty string
            <span className="bg-green-100 border border-[#18BD63] rounded-full text-[#18BD63] text-sm poppins px-4 py-1 inline-block mb-4 ">
              {t(`menu:${title.replace(/\s/g, "_")}.dietary_info`).replace(
                /_/g,
                " "
              )}
            </span>
          )}
        </div>

        <img
          className="w-64 h-48 mx-auto transform transition duration-300 hover:scale-105"
          src={image}
          alt=""
        />
        <div className="flex flex-col items-center my-3 space-y-4">
          <h1 className="text-gray-900 poppins text-lg">
            {t(`menu:${title.replace(/\s/g, "_")}.item_name`).replace(
              /_/g,
              " "
            )}
          </h1>
          <p className="text-gray-500 poppins text-sm text-center h-14">
            {t(
              `menu:${title.replace(/\s/g, "_")}.item_description_short`
            ).replace(/_/g, " ")}
          </p>
          <h2 className="text-gray-900 poppins text-2xl font-medium pt-5">
            €{price}
          </h2>

          <button className="bg-primary text-white px-8 py-2 focus:outline-none poppins rounded-full transform transition duration-300 hover:scale-105 mt-10">
            {t("common:translation:orderNow")}
          </button>
        </div>
      </div>
    </Link>
  );
};

export default Item;
