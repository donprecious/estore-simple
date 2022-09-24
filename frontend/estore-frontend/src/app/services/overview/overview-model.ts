import { APIResponseModel } from './../shared-model.model';
export interface GetOverviewModel {
  uniqueUser: number;
  sales: number;
  orders: number;
}

export interface GetOverViewResponse
  extends APIResponseModel<GetOverviewModel> {}
