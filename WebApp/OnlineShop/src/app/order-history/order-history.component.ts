import { Component, OnInit, ViewChild } from '@angular/core';
import { Repository } from '../models/model/Repository';
import { OrderDetail } from '../models/model/orderdetail';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { NumberInput } from '@angular/cdk/coercion';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-order-history',
  templateUrl: './order-history.component.html',
  styleUrls: ['./order-history.component.css']
})


export class OrderHistoryComponent implements OnInit {
  constructor(private repo: Repository,private datePipe: DatePipe) { }
  @ViewChild(MatPaginator)
  paginator!: MatPaginator;
  public isLoading: boolean = true;
  public totalItemsCount: NumberInput;
  public pageSizeOptions = [5, 10, 25];
  public hidePageSize = false;
  public showPageSizeOptions = true;
  public showFirstLastButtons = true;
  pageEvent: PageEvent = new PageEvent;


  displayedColumns: string[] = ['OrderId', 'CustomerName', 'ProductName', 'Quantity', 'OrderedDate'];
  dataSource = new MatTableDataSource<OrderDetail>()

  ngOnInit(): void {

    this.getOrders();
  }


  getOrders(){
    this.repo.getOrders().subscribe(
      (orders) => {
        console.log(orders)
        this.dataSource.data = orders;
        this.totalItemsCount = orders.length;
        this.paginator.length = this.totalItemsCount;
        this.isLoading = false;
      },
      (error) => {
        console.error(error);
      }
    );
  }
}
