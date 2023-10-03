import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Order } from '../models/model/Order';

@Component({
  selector: 'app-order-confirmation',
  templateUrl: './order-confirmation.component.html',
  styleUrls: ['./order-confirmation.component.css']
})
export class OrderConfirmationComponent {

  constructor(private router: Router,
    public order: Order) {
    if (!order.submitted) {
    router.navigateByUrl("/checkout/step3");
    }
  }
}
