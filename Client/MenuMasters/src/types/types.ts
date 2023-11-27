// accountTypes.ts
interface Account {
  account_id: number;
  name: string;
  password: string;
  email: string | null;
  role_id: number;
}

// categoryTypes.ts
interface Category {
  category_id: number;
  category_name: string;
  type: number;
}

// menuItemTypes.ts
interface MenuItem {
  menuItemId: number;
  itemName: string;
  itemDescription_Short: string;
  itemDescription_Long: string;
  itemPrice: number;
  itemStock: number;
  categoryId: string;
  imageURL: string;
  dietaryInfo: string;
  ingredients: string;
  price: number;
}

interface CartItem {
  price: number;
  id: string;
  food: MenuItem;
  quantity: number;
  notes?: string; // Optional
}

// orderStaff
interface OrderSales {
  orderId: number;
  tabId: number;
  tableNumber: number;
  tabTotal: number;
  dateTime: string;
  orderItems: OrderItemSales[];
}

// orderStaff
interface OrderItemSales {
  menuItemId: number;
  itemName: string;
  itemPrice: number;
  quantity: number;
}

// orderStaff
interface OrderStaff {
  orderId: number;
  tabId: number;
  tableNumber: number;
  status: string;
  dateTime: string;
  orderItems: OrderItemStaff[];
}

// orderStaff
interface OrderItemStaff {
  menuItemId: number;
  itemName: string;
  notes: string;
  quantity: number;
}

// orderTypes.ts
interface Order {
  order_id: number;
  tab_id: number;
  status: string;
  notes: string | null;
  datetime: string; // You may want to use a Date type, but this depends on how your data is formatted.
}

// orderItemTypes.ts
interface OrderItem {
  orderitem_id: number;
  order_id: number;
  item_id: number;
  quantity: number;
}

// roleTypes.ts
interface Role {
  role_id: number;
  name: string | null;
  description: string | null;
}

// tabTypes.ts
interface Tab {
  tab_id: number;
  table_number: number;
  tab_total: number | null;
}

export type {
  Account,
  Category,
  MenuItem,
  OrderItem,
  Order,
  OrderStaff,
  OrderSales,
  Role,
  Tab,
  CartItem,
};
