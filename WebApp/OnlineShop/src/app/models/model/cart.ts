import { Injectable } from "@angular/core";
import { Product } from "./Product";
import { ProductSelection } from "./ProductSelection";
import { BehaviorSubject } from "rxjs/internal/BehaviorSubject";

@Injectable()
export class Cart {
  private cartKey = 'cart'; // Key for storing cart data in localStorage

selections: ProductSelection[] = [];
itemCount: number = 0;
totalPrice: number = 0;
private cartUpdatedSubject = new BehaviorSubject<any | null>(null);

get cartUpdated$() {
  return this.cartUpdatedSubject.asObservable();
}
constructor() {
  // Initialize the cart from localStorage when the Cart class is constructed
 // this.loadCartFromLocalStorage();
}


loadCartFromLocalStorage() {
  const cartData = localStorage.getItem(this.cartKey);
  if (cartData) {
    const parsedCartData = JSON.parse(cartData);
    this.selections = parsedCartData.selections;
    this.update();
  }
}

private saveCartToLocalStorage() {
  const cartData = JSON.stringify({ selections: this.selections });
  localStorage.setItem(this.cartKey, cartData);
}


addProduct(product: Product) {
  let selection = this.selections.find(ps => ps.productId == product.Id);
  if (selection) {
    selection.quantity++;
  } else {
    this.selections.push(new ProductSelection(this,
    product.Id, product.Name,
    product.Price, 1));
  }
  this.update();
    // Save the cart to localStorage whenever a product is added
  localStorage.setItem('cart', JSON.stringify(this.toJSON()));
}

toJSON(): any {
  return {
    selections: this.selections.map((selection) => ({
      productId: selection.productId,
      name: selection.name,
      price: selection.price,
      quantity: selection.quantity,
    })),
    itemCount: this.itemCount,
    totalPrice: this.totalPrice,
  };
}

updateQuantity(productId: number, quantity: number) {
  console.log(quantity)

  if (quantity > 0) {
    let selection = this.selections.find(ps => ps.productId == productId);
  if (selection) {
     selection.quantity = quantity;
  }
  } else {
    let index = this.selections.findIndex(ps => ps.productId == productId);
  if (index != -1) {
    this.selections.splice(index, 1);
  }

  }
  this.update();
     // Save the updated cart data to localStorage
  this.saveCartToLocalStorage();

}

  clear() {
    this.selections = [];
    this.update();
      // Clear cart data from localStorage
      localStorage.removeItem(this.cartKey);
  }

  update() {

    this.itemCount = this.selections.map(ps => ps.quantity).reduce((prev, curr) => prev + curr, 0);
    this.totalPrice = this.selections
    .map(ps => (ps.price ? ps.price * ps.quantity : 0)) // Use optional chaining
    .reduce((prev, curr) => prev + curr, 0);

      // Notify subscribers that the cart has been updated with specific data
    this.cartUpdatedSubject.next(this.selections);

  }



}
