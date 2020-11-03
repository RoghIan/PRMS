import { IPublisher } from './publisher';

export interface IPagination {
  pageIndex: number;
  pageSize: number;
  count: number;
  data: IPublisher[];
}
