import { IOwnedPlant } from "./ownedPlant";

export interface IResponse<T>  {
  result: string;
  value: T;
}
