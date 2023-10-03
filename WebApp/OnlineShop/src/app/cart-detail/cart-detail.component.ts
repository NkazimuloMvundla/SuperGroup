import { ChangeDetectionStrategy, Component, OnInit, ViewChild } from '@angular/core';
import { Cart } from '../models/model/cart';
import { MatTable, MatTableDataSource } from '@angular/material/table';
import {Router } from '@angular/router';
import { Subscription } from 'rxjs/internal/Subscription';

@Component({
  selector: 'app-cart-detail',
  templateUrl: './cart-detail.component.html',
  styleUrls: ['./cart-detail.component.css'],
  changeDetection: ChangeDetectionStrategy.Default,
})
export class CartDetailComponent implements OnInit {
  @ViewChild(MatTable) table!: MatTable<any>;
  constructor(public cart: Cart,private router: Router) {
  }

  public dataSource = new MatTableDataSource<any>();

  private cartSubscription: Subscription = new Subscription;

  ngOnInit(): void {
    this.dataSource.data = this.cart.selections;

    this.cartSubscription = this.cart.cartUpdated$.subscribe((x) => {
      this.dataSource.data = this.cart.selections;
    });

  }

  updateQuantity(index: number, productId: number, quantity: number) {

    // if (index >= 0 && index < this.dataSource.data.length) {
    //   this.dataSource.data.splice(index, 1); // Remove the row from the data source
    //   this.table.renderRows(); // Refresh the table view
    // }
    this.cart.updateQuantity(productId, quantity);
  }


  ngOnDestroy(): void {
    // Unsubscribe from the cart updates to avoid memory leaks
    this.cartSubscription.unsubscribe();
  }

  onCheckoutButtonClick() {
    this.router.navigate(['/checkout']);
  }

  navigateToHome() {
    this.router.navigate(['/']);
  }

}
