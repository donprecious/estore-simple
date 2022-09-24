// Generated by https://quicktype.io

export interface APIResponseModel<T> {
  data: T;
  message: string;
  status: string;
  errorCode: null;
}

export interface PaginatedData<T> {
  items: T[];
  pageNumber: number;
  totalPages: number;
  totalCount: number;
  hasPreviousPage: boolean;
  hasNextPage: boolean;
}
