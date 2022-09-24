// Generated by https://quicktype.io

import { APIResponseModel, PaginatedData } from '../shared-model.model';

export interface CreateProductModel {
  name: string;
  description: string;
  amount: number;
  imageUrl: string;
} // Generated by https://quicktype.io

export interface GetProductModel {
  name: string;
  description: string;
  imageUrl: string;
  amount: number;
  id: number;
  createdAt: string;
}

export interface ProductPagedList extends PaginatedData<GetProductModel> {}

export interface GetProductListResponse
  extends APIResponseModel<ProductPagedList> {}