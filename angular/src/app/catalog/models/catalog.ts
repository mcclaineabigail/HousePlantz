import { IOwnedPlant } from "./ownedPlant";

export interface ICatalog{
    "id": number;
    "user": string;
    "plants": IOwnedPlant[];
}