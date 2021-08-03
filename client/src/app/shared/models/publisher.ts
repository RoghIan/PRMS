import { IDictionary } from './dictionary';

export interface IPublisher {
  id: number;
  firstName: string;
  middleName: string;
  lastName: string;
  age: number;
  baptismDate: Date;
  birthDate: Date;
  photoUrl: string;
  gender: string;
  status: IDictionary;
  group: string;
}

export interface IPostPublisher {
  id:number;
  firstName?: any;
  middleName?: any;
  lastName?: any;
  baptismDate: string;
  birthDate: string;
  photoUrl?: any;
  gender?: any;
  groupId: number;
}
