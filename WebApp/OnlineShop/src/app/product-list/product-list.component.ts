import { Component, OnInit, ViewChild } from '@angular/core';
import { Product } from '../models/model/Product';
import { Repository } from '../models/model/Repository';
import { MatTableDataSource } from '@angular/material/table';
import { MatTableModule } from '@angular/material/table';
import { MatPaginator, MatPaginatorModule, PageEvent } from '@angular/material/paginator';
import { NumberInput } from '@angular/cdk/coercion';
import { Cart } from '../models/model/cart';


@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {


  displayedColumns: string[] = ['Name', 'Description', 'Price', 'Actions'];
  public dataSource = new MatTableDataSource<any>();


  constructor(private repo: Repository, private cart: Cart) { }
  @ViewChild(MatPaginator)
  paginator!: MatPaginator;
  public isLoading: boolean = true;
  public totalItemsCount: NumberInput;
  public itemsToTake = 3;
  public currentPage = 0;
  public pageSizeOptions = [5, 10, 25];
  public hidePageSize = false;
  public showPageSizeOptions = true;
  public showFirstLastButtons = true;
  pageEvent: PageEvent = new PageEvent;

  ngAfterViewInit() {
    this.paginator.pageIndex = this.currentPage;
  }

  handlePageEvent(e: PageEvent) {
    this.pageEvent = e;
    this.currentPage = e.pageIndex;
    this.getProducts();
  }

  ngOnInit(): void {

    this.getProducts();
  }

  getProducts(){
    this.repo.getProducts(this.itemsToTake, this.currentPage).subscribe(
      (products) => {
        this.dataSource.data = products.Products
        this.totalItemsCount = products.TotalRowCount;
        this.paginator.length = this.totalItemsCount;
        this.isLoading = false;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  addToCart(product: Product) {
    this.cart.addProduct(product);
  }


  ngOnDestroy() {
   //destroy repo subscription
  }




}
