import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { ModelModule } from './models/model/model.module';
import { HttpClientModule } from '@angular/common/http';
// import { ProductListComponent } from './product-list/product-list.component';
// import { PaginationComponent } from './pagination/pagination.component';
// import { CartSummaryComponent } from './cart-summary/cart-summary.component';
import { AppRoutingModule } from './app-routing.module';
import { StoreModule } from './store.module';
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { DatePipe } from '@angular/common';
// import { ProductSelectionComponent } from './product-selection/product-selection.component';

@NgModule({
  declarations: [
    AppComponent,
    // ProductListComponent,
    // PaginationComponent,
    // CartSummaryComponent,
    // ProductSelectionComponent
  ],
  imports: [
    BrowserModule, ModelModule,  HttpClientModule, AppRoutingModule, StoreModule,
  ],
  providers: [DatePipe],
  bootstrap: [AppComponent]
})
export class AppModule { }
