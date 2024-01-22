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
  categoryId: number;
  categoryName: string;
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
  categoryId: number;
  categoryName: string;
  imageURL: string;
  dietaryInfo: string;
  ingredients: string;
  price: number;
  quantity: number;
  image: string;
}

interface CartItem {
  itemId: number;
  price: number;
  id: string;
  food: MenuItem;
  quantity: number;
  notes?: string; // Optional
}

interface OrderItemSales {
  orderItemId: number;
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

// roleTypes.ts
interface Role {
  role_id: number;
  name: string | null;
  description: string | null;
}

// tabTypes.ts
interface TabEntity {
  tabId: number;
  tableNumber: number;
  tabTotal: number;
  date: string;
  moneyRemaining: number;
  paid: boolean;
  orderItems: OrderItemSales[];
  request: number;
}

export type {
  Account,
  Category,
  MenuItem,
  OrderItemSales,
  OrderStaff,
  Role,
  TabEntity,
  CartItem,
};
