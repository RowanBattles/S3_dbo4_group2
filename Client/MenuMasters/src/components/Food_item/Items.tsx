import { useState, useEffect } from "react";
import Item from "./Item";
import { getItems } from "../../utils/api";

interface Item {
  menuItemId: number;
  itemName: string;
  itemDescription: string;
  itemPrice: number;
}

const Items = () => {
  const [items, setItems] = useState([]);
  const [menuTab, setMenuTab] = useState("Breakfast");
  // const [loading, setLoading] = useState(false);
  // const [foods] = useFetch();

  useEffect(() => {
    const fetchData = async () => {
      try {
        const data = await getItems();
        setItems(data);
      } catch (error) {
        console.error("Error fetching items:", error);
      }
    };

    fetchData();
  }, []);

  const handleMenuTabs = (type: any) => {
    setMenuTab(type);
  };

  return (
    <section className="my-12 max-w-screen-xl mx-auto px-6">
      <div className="flex items-center justify-center space-x-6">
        <p
          className={
            menuTab === "Breakfast"
              ? "active_menu_tab poppins bg-primary"
              : "menu_tab poppins"
          }
          onClick={() => handleMenuTabs("Breakfast")}
        >
          Breakfast
        </p>
        <p
          className={
            menuTab === "Lunch"
              ? "active_menu_tab poppins bg-primary"
              : "menu_tab poppins"
          }
          onClick={() => handleMenuTabs("Lunch")}
        >
          Lunch
        </p>
        <p
          className={
            menuTab === "Dinner"
              ? "active_menu_tab poppins bg-primary"
              : "menu_tab poppins"
          }
          onClick={() => handleMenuTabs("Dinner")}
        >
          Dinner
        </p>
      </div>
      <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-10 mt-12">
        {items.map((item: Item) => (
          <Item
            key={item.menuItemId}
            image="https://joflow.nl/cdn/shop/products/Voorfoto_3bc2c4c8-01a8-4565-98f9-dadbbbea9e41_1200x1200.jpg?v=1657801731"
            title={item.itemName}
            description={item.itemDescription}
            price={item.itemPrice}
            foodType="Lunch"
          />
        ))}
      </div>
    </section>
  );
};

export default Items;
