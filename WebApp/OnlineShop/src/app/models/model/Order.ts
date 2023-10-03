import { Injectable } from "@angular/core";
import { Cart } from "./cart";
import { Repository } from "./Repository";

@Injectable()
export class Order {
  public id: number | null = null;

  public customerName: string | null = null;
  public address: string | null = null;
  public city: string | null = null;
  public state: string | null = null;
  public zip: string | null = null;
  public country: string | null = null;
  public shipped: boolean = false;
  public orderDate!: Date;
  payment: any;
  orderConfirmation!: OrderConfirmation;
  orderId: any;
  submitted: boolean = false;

  constructor(private repo: Repository, public cart: Cart) { }


  clear() {
    this.id = null;
    this.customerName = this.address = this.city = null;
    this.state = this.zip = this.country = null;
    this.shipped = false;
    this.cart.clear();
  }

  get products(): CartLine[] {
    return this.cart.selections
        .filter(p => p.productId !== undefined && p.quantity !== undefined) // Filter out undefined values
        .map(p => new CartLine(p.productId as number, p.quantity as number)); // Use "as number" to assert non-undefined types

  }

    submit() {
    this.submitted = true;
    this.repo.createOrder(this);
    }

}

export class Payment {
  cardNumber!: string;
  cardExpiry!: string;
  cardSecurityCode!: string;
 }

 export class CartLine {
  constructor(private productId: number,
  private quantity: number) { }
 }

 export class OrderConfirmation {
  constructor(public orderId: number,
  public authCode: string,
  public amount: number) { }
 }
