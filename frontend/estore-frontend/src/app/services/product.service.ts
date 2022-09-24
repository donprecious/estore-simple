import {
  CreateProductModel,
  GetProductListResponse,
} from './product/product.model';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { APIResponseModel } from './shared-model.model';

@Injectable({
  providedIn: 'root',
})
export class ProductService {
  baseUrl = environment.estoreApiUrl;
  constructor(private httpClient: HttpClient) {}

  getProducts(page = 1, pageSize = 20): Observable<GetProductListResponse> {
    return this.httpClient.get<GetProductListResponse>(
      `${this.baseUrl}/product?page=${page}&pageSize=${pageSize}`
    );
  }

  createProduct(
    createProduct: CreateProductModel
  ): Observable<APIResponseModel<any>> {
    return this.httpClient.post<APIResponseModel<any>>(
      `${this.baseUrl}/product`,
      createProduct
    );
  }
}
