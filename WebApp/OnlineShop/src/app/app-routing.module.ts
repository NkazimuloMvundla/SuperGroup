import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { ProductListComponent } from './product-list/product-list.component';
import { ProductSelectionComponent } from './product-selection/product-selection.component';
import { MatTableModule } from '@angular/material/table';
import { CartDetailComponent } from './cart-detail/cart-detail.component';
import { CheckoutComponent } from './checkout/checkout.component';
import { CheckoutPaymentComponent } from './checkout-payment/checkout-payment.component';
import { CheckoutSummaryComponent } from './checkout-summary/checkout-summary.component';
import { OrderConfirmationComponent } from './order-confirmation/order-confirmation.component';
import { OrderHistoryComponent } from './order-history/order-history.component';


const routes: Routes = [
  { path: "cart", component: CartDetailComponent },
  { path: "checkout/step1", component: CheckoutComponent },
//  { path: "checkout/step2", component: CheckoutPaymentComponent },
 { path: "checkout/step3", component: CheckoutSummaryComponent },
 { path: "checkout/confirmation", component: OrderConfirmationComponent },
 { path: "orders", component: OrderHistoryComponent },
 { path: "checkout", redirectTo: "/checkout/step1", pathMatch: "full" },

  { path: '', component: ProductSelectionComponent, },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
