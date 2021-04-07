import { ICatalog } from './catalog';
import { IPlant } from './plant';
import { IRoom } from './room';

export interface IOwnedPlant {
  id: number;
  nickName: string;
  plant: IPlant;
  room: IRoom;
}
