import { Component } from '@angular/core';
import { Order } from '../models/model/Order';
import { Router } from '@angular/router';

@Component({
  selector: 'app-checkout-payment',
  templateUrl: './checkout-payment.component.html',
  styleUrls: ['./checkout-payment.component.css']
})
export class CheckoutPaymentComponent {

  constructor(private router: Router,
    public order: Order) {
      if (order.customerName == null || order.address == null) {
      router.navigateByUrl("/checkout/step1");
      }
    }


}
