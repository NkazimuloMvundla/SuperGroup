import { Component } from '@angular/core';
import { Order } from '../models/model/Order';
import { Router } from '@angular/router';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent {
  constructor(private router: Router,
    public order: Order) {
    if (order.products.length == 0) {
    this.router.navigateByUrl("/cart");
    }
  }

  navigateToStep3() {
    this.router.navigate(['/checkout/step3']);
  }

  navigateToCart() {
    this.router.navigate(['/cart']);
  }


}
