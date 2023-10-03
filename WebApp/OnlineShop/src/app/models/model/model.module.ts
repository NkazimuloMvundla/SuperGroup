import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Repository } from './Repository';
import { Cart } from './cart';
import { Order } from './Order';



@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ],
  providers: [Repository,Cart,Order]
})
export class ModelModule { }
