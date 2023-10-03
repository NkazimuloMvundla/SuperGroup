import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CartSummaryComponent } from './cart-summary/cart-summary.component';
import { PaginationComponent } from './pagination/pagination.component';
import { BrowserModule } from '@angular/platform-browser';
import { ProductListComponent } from './product-list/product-list.component';
import { ProductSelectionComponent } from './product-selection/product-selection.component';
import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { MatPaginatorModule } from '@angular/material/paginator';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatIconModule } from '@angular/material/icon';
import { CartDetailComponent } from './cart-detail/cart-detail.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { CheckoutComponent } from './checkout/checkout.component';
import { MatButtonModule } from '@angular/material/button';
import { CheckoutPaymentComponent } from './checkout-payment/checkout-payment.component';
import { CheckoutSummaryComponent } from './checkout-summary/checkout-summary.component';
import { OrderConfirmationComponent } from './order-confirmation/order-confirmation.component';
import { OrderHistoryComponent } from './order-history/order-history.component';
import { MatToolbarModule } from '@angular/material/toolbar';

@NgModule({
  declarations: [CartSummaryComponent,
  PaginationComponent, ProductListComponent,
  ProductSelectionComponent,CartDetailComponent, CheckoutComponent, CheckoutPaymentComponent, CheckoutSummaryComponent, OrderConfirmationComponent, OrderHistoryComponent],
  imports: [BrowserModule, MatTableModule,MatSortModule,
    MatTableModule,MatPaginatorModule, BrowserAnimationsModule,MatProgressBarModule, MatIconModule,MatFormFieldModule,MatInputModule,FormsModule,MatButtonModule,MatToolbarModule],
  exports: [ProductSelectionComponent]
 })
 export class StoreModule { }

