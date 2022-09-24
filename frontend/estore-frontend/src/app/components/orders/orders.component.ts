import { Component, Input, OnInit } from '@angular/core';
import { GetOrderModel } from 'src/app/services/order/order-model';
import { OrderService } from 'src/app/services/order/order.service';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.css'],
})
export class OrdersComponent implements OnInit {
  constructor(private orderService: OrderService) {}

  @Input()
  orders: GetOrderModel[] = [];
  ngOnInit(): void {}

  formatDate(date: string) {
    const d = new Date(date);
    return d;
  }
}
