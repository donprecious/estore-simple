import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { APIResponseModel } from '../shared-model.model';
import {
  CreateOrderModel,
  GetOrderListResponse,
  ShippingAddress,
} from './order-model';

@Injectable({
  providedIn: 'root',
})
export class OrderService {
  baseUrl = environment.estoreApiUrl;
  constructor(private httpClient: HttpClient) {}

  getOrders(page = 1, pageSize = 20): Observable<GetOrderListResponse> {
    return this.httpClient.get<GetOrderListResponse>(
      `${this.baseUrl}/order?page=${page}&pageSize=${pageSize}`
    );
  }

  createOrder(order: CreateOrderModel): Observable<APIResponseModel<any>> {
    return this.httpClient.post<APIResponseModel<any>>(
      `${this.baseUrl}/order`,
      order
    );
  }

  persistShippingDetail(shippingAddress: ShippingAddress) {
    window.localStorage.setItem(
      'shippingAddress',
      JSON.stringify(shippingAddress)
    );
  }

  getShippingAddress(): ShippingAddress {
    const shipping = window.localStorage.getItem('shippingAddress');
    if (shipping) {
      const shippingAddress = JSON.parse(shipping as string) as ShippingAddress;
      return shippingAddress;
    }
    return {
      city: '',
      country: '',
      state: '',
      street: '',
      zipCode: '',
    } as ShippingAddress;
  }
}
