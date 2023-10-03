import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Order } from '../models/model/Order';

@Component({
  selector: 'app-checkout-summary',
  templateUrl: './checkout-summary.component.html',
  styleUrls: ['./checkout-summary.component.css']
})
export class CheckoutSummaryComponent {

  constructor(private router: Router,
    public order: Order) {
      {

      }
  }
    submitOrder() {
      this.order.submit();
      this.router.navigateByUrl("/checkout/confirmation");
    }

    navigateToStep1() {
      this.router.navigate(['/checkout/step1']);
    }

}
