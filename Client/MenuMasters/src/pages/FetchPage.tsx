import { useEffect, useState } from "react";
import { getItems } from "../utils/api";

const FetchPage = () => {
  const [items, setItems] = useState<any[]>([]);

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

  return (
    <div>
      {items.map((item) => (
        <div key={item.menuItemId}>
          <h2>{item.itemName}</h2>
          <p>{item.itemDescription}</p>
          <p>Price: {item.itemPrice}</p>
        </div>
      ))}
    </div>
  );
};

export default FetchPage;
