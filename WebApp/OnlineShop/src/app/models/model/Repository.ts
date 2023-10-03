import { Product } from "./Product";
import { Injectable } from "@angular/core";
import { HttpClient, HttpParams } from "@angular/common/http";
import { Observable } from "rxjs";
import { environment } from "src/app/environment";
import { ProductsListModel } from "./ProductList";
import { Order, OrderConfirmation } from "./Order";
import { OrderDetail } from "./orderdetail";

@Injectable()
export class Repository {
    product!: Product;
    products!: Product[];
    orders: Order[] = [];
    constructor(private http: HttpClient) {

    }

     //todo: move this to product repo
    getProducts(itemsToTake:number, currentPage:number): Observable<ProductsListModel<Product[]>> {
      let params = new HttpParams();
      params = params.append('itemsToTake', itemsToTake);
      params = params.append('currentPage', currentPage);
      return this.http.get<ProductsListModel<Product[]>>(`${environment.apiUrl}products`, {params: params});
    }

    //todo: move this to orders repo
    getOrders(): Observable<OrderDetail[]> {
      return this.http.get<OrderDetail[]>(`${environment.apiUrl}getordershistory`);
    }

    //todo: move this to orders repo
    createOrder(order: Order) {
      this.http.post<OrderConfirmation>(`${environment.apiUrl}createorder`, {
          customerName: order.customerName,
          address: order.address,
          products: order.products,
      }).subscribe(data => {
          order.orderConfirmation = data
          order.cart.clear();
          order.clear();
      });
    }

}
