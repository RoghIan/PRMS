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
