import { OrderService } from './../services/order/order.service';
import { Component, OnInit } from '@angular/core';
import { ProductService } from '../services/product.service';
import { GetProductModel } from '../services/product/product.model';
import { GetOrderModel } from '../services/order/order-model';
import { GetOverviewModel } from '../services/overview/overview-model';
import { OverviewService } from '../services/overview/overview.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  constructor(
    private productService: ProductService,
    private orderService: OrderService,
    private overviewService: OverviewService
  ) {}

  products: GetProductModel[] = [];
  orders: GetOrderModel[] = [];
  overview: GetOverviewModel = {
    uniqueUser: 0,
    sales: 0,
    orders: 0,
  };
  ngOnInit(): void {
    this.productService.getProducts().subscribe((a) => {
      this.products = a.data.items;
    });

    this.orderService.getOrders().subscribe((a) => {
      this.orders = a.data.items;
    });

    this.overviewService.getOverview().subscribe((a) => {
      this.overview = a.data;
    });
  }
}
