import { Component } from '@angular/core';
import { Cart } from '../models/model/cart';
import { Router } from '@angular/router';

@Component({
  selector: 'app-cart-summary',
  templateUrl: './cart-summary.component.html',
  styleUrls: ['./cart-summary.component.css']
})
export class CartSummaryComponent {

    constructor(private cart: Cart,private router: Router) {

}

 get itemCount(): number {
    return this.cart.itemCount;
 }
 get totalPrice(): number {
    return this.cart.totalPrice;
 }


  navigateToCart() {
    this.router.navigate(['/cart']);
  }


}
