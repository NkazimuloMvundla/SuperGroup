import { Product } from "./Product";


// Define the CartLine class
export class CartLine {
  CartLineId!: number;
  ProductId!: number;
  Quantity!: number;
}

// Define the Orders class
export class Orders {
  OrderId!: number;
  CustomerName!: string;
  Products!: Product[]; // Array of Product objects
  Address!: string;
  Shipped!: boolean;
  OrderedDate!: Date;
}

// Define the main data structure that matches JSON structure
export class OrderDetail {
  Orders!: Orders;
  CartLines!: CartLine;
  Products!: Product;
}
