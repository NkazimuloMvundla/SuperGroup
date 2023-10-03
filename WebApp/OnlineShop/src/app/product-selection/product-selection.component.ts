import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Order } from '../models/model/Order';

@Component({
  selector: 'app-product-selection',
  templateUrl: './product-selection.component.html',
  styleUrls: ['./product-selection.component.css']
})
export class ProductSelectionComponent {
  constructor(private router: Router) {}

    ViewOrders() {
      this.router.navigate(['/orders']);
    }

}
