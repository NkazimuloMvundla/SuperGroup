import { Cart } from "./cart";

 export class ProductSelection {
  constructor(
    public cart: Cart,
    public productId?: number,
    public name?: string,
    public price?: number,
    private quantityValue: number = 0 // Initialize to a default value (e.g., 0)
  ) {}

  get quantity() {
    return this.quantityValue;
  }

  set quantity(newQuantity: number) {
    this.quantityValue = newQuantity;
    this.cart.update();
  }
}

