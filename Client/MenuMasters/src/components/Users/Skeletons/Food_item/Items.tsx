import { useState, useEffect } from "react";
import Item from "./Item";
import { getItems, getCategoryById } from "../../../../utils/api.tsx";
import { useTranslation } from "react-i18next";
import { MenuItem } from "../../../../types/types";
import Item_Skeleton from "./Item_Skeleton";
import IngredientFilter from "./IngredientFilter";

const Items = () => {
  const [items, setItems] = useState<MenuItem[]>([]);
  const [categories, setCategories] = useState<string[]>([]);
  const [menuTab, setMenuTab] = useState<string>("Appetizers");
  const [loading, setLoading] = useState<boolean>(true);
  const { t } = useTranslation();
  const [selectedIngredients, setSelectedIngredients] = useState<string[]>([]);
  const allIngredients = [
    ...new Set(
      items
        .flatMap((item) => item.ingredients || [])
        .join(",")
        .split(",")
        .map((ingredient) => ingredient.trim())
    ),
  ].sort();
  useEffect(() => {
    const fetchData = async () => {
      try {
        const itemsData = await getItems();
        setItems(itemsData as MenuItem[]);

        // Fetch categories for each item
        const categoryPromises = itemsData.map(async (item: MenuItem) => {
          const categoryData = await getCategoryById(item.categoryId);
          setCategories((prevCategories) => ({
            ...prevCategories,
            [item.categoryId]: categoryData.categoryName,
          }));
        });

        await Promise.all(categoryPromises);
      } catch (error) {
        if (error instanceof Error) {
          console.error("Error fetching data:", error.message);
        } else {
          console.error("Error fetching data:", error);
        }
      } finally {
        setLoading(false);
      }
    };

    fetchData();
  }, []);

  const handleMenuTabs = (type: string) => {
    setMenuTab(type);
  };

  const filteredItems = items.filter((item) => {
    const category = categories[item.categoryId];
    return (
      category === menuTab &&
      !selectedIngredients.some((ingredient) =>
        item.ingredients.includes(ingredient)
      )
    );
  });

  return (
    <section className="my-12 max-w-screen-xl mx-auto px-6">
      <div className="flex justify-center items-center mb-20">
        <hr className="w-28 h-1 bg-primary border-0 rounded mx-4"></hr>
        <h1 className="text-4xl font-medium uppercase">Menu</h1>
        <hr className="w-28 h-1 bg-primary border-0 rounded mx-4"></hr>
      </div>
      <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-5 gap-10 text-center">
        <p
          className={
            menuTab === "Appetizers"
              ? "active_menu_tab poppins bg-primary px-10"
              : "menu_tab poppins border px-10 border-gray-100 rounded-full py-2"
          }
          onClick={() => handleMenuTabs("Appetizers")}
        >
          {t("common:translation.categories:appetizers")}
        </p>
        <p
          className={
            menuTab === "Main courses"
              ? "active_menu_tab poppins bg-primary px-10"
              : "menu_tab poppins border px-10 border-gray-100 rounded-full py-2"
          }
          onClick={() => handleMenuTabs("Main courses")}
        >
          {t("common:translation.categories:main_courses")}
        </p>
        <p
          className={
            menuTab === "Desserts"
              ? "active_menu_tab poppins bg-primary px-10"
              : "menu_tab poppins border px-10 border-gray-100 rounded-full py-2"
          }
          onClick={() => handleMenuTabs("Desserts")}
        >
          {t("common:translation.categories:desserts")}
        </p>
        <select
          value={menuTab}
          onChange={(e) => handleMenuTabs(e.target.value)}
          className={
            menuTab === "Cold drinks" ||
            menuTab === "Warm drinks" ||
            menuTab === "Alcohol" ||
            menuTab === "Cocktails"
              ? "active_menu_tab poppins border px-10 border-primary rounded-full py-2 outline-none bg-red-500 text-white text-center"
              : "menu_tab poppins border px-10 border-gray-100 rounded-full py-2 bg-white text-center"
          }
        >
          <option value="Cold drinks" className="bg-white text-black text-left">
            {t("common:translation.categories:cold_drinks")}
          </option>
          <option value="Warm drinks" className="bg-white text-black text-left">
            {t("common:translation.categories:warm_drinks")}
          </option>
          <option value="Alcohol" className="bg-white text-black text-left">
            {t("common:translation.categories:alcohol")}
          </option>
          <option value="Cocktails" className="bg-white text-black text-left">
            {t("common:translation.categories:cocktails")}
          </option>
        </select>
        <IngredientFilter
          allIngredients={allIngredients}
          selectedIngredients={selectedIngredients}
          onSelectIngredient={(ingredient) => {
            // Implement logic to handle ingredient selection
            // For example, update the selectedIngredients state
            setSelectedIngredients((prevSelected) => {
              if (prevSelected.includes(ingredient)) {
                return prevSelected.filter((item) => item !== ingredient);
              } else {
                return [...prevSelected, ingredient];
              }
            });
          }}
        />
      </div>
      <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-10 mt-12">
        {loading ? (
          // Display skeleton component while loading
          Array.from({ length: 3 }).map((_, index) => (
            <Item_Skeleton key={index} />
          ))
        ) : filteredItems.length === 0 ? (
          // Display message when no items are available
          <p>No items available in this category.</p>
        ) : (
          // Display actual item components when data is loaded
          filteredItems.map((item) => (
            <Item
              key={item.menuItemId}
              id={item.menuItemId}
              image={item.imageURL}
              title={item.itemName}
              description={item.itemDescription_Short}
              price={item.itemPrice}
              foodType={categories[item.categoryId]}
              dietaryInfo={item.dietaryInfo}
            />
          ))
        )}
      </div>
    </section>
  );
};

export default Items;
