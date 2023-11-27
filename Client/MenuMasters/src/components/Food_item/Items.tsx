import { useState, useEffect } from "react";
import Item from "./Item";
import { getItems, getCategoryById } from "../../utils/api";

import { MenuItem } from "../../types/types";
import Item_Skeleton from "./Item_Skeleton";

interface CategoryData {
  [key: string]: string;
}

const Items = () => {
  const [items, setItems] = useState<MenuItem[]>([]);
  const [categories, setCategories] = useState<CategoryData>({});
  const [menuTab, setMenuTab] = useState<string>("Appetizers");
  const [loading, setLoading] = useState<boolean>(true);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const itemsData = await getItems();
        setItems(itemsData as MenuItem[]);

        // Fetch categories for each item
        const categoryPromises = itemsData.map(async (item) => {
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
    return category === menuTab;
  });

  return (
    <section className="my-12 max-w-screen-xl mx-auto px-6">
      <div className="flex justify-center items-center mb-20">
        <hr className="w-28 h-1 bg-primary border-0 rounded mx-4"></hr>
        <h1 className="text-4xl font-medium uppercase">Menu</h1>
        <hr className="w-28 h-1 bg-primary border-0 rounded mx-4"></hr>
      </div>
      <div className="flex items-center justify-center space-x-6 mr-6">
        <p
          className={
            menuTab === "Appetizers"
              ? "active_menu_tab poppins bg-primary px-10"
              : "menu_tab poppins border px-10 border-gray-100 rounded-full py-2"
          }
          onClick={() => handleMenuTabs("Appetizers")}
        >
          Appetizers
        </p>
        <p
          className={
            menuTab === "Main courses"
              ? "active_menu_tab poppins bg-primary px-10"
              : "menu_tab poppins border px-10 border-gray-100 rounded-full py-2"
          }
          onClick={() => handleMenuTabs("Main courses")}
        >
          Main courses
        </p>
        <p
          className={
            menuTab === "Desserts"
              ? "active_menu_tab poppins bg-primary px-10"
              : "menu_tab poppins border px-10 border-gray-100 rounded-full py-2"
          }
          onClick={() => handleMenuTabs("Desserts")}
        >
          Desserts
        </p>
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
              foodType={item.categoryId}
              dietaryInfo="Vegan"
            />
          ))
        )}
      </div>
    </section>
  );
};

export default Items;
