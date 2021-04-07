import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { CatalogService } from './catalog.service';
import { IOwnedPlant } from './models/ownedPlant';

@Component({
  selector: 'hp-catalog',
  templateUrl: './catalog.component.html',
  styleUrls: ['./catalog.component.css']
})
export class CatalogComponent implements OnInit {
  plantCatalog: IOwnedPlant[] = [
    {
      "id": 1,
      "nickName": "Plant 1",
      "plant": {
          "id": 1,
          "name": "Pothos",
          "sun": "https://github.com/mcclaineabigail/PlantCatalog/blob/main/HousePlantz.Data/Images/light/low-medium.png?raw=true",
          "image": "https://github.com/mcclaineabigail/PlantCatalog/blob/main/HousePlantz.Data/Images/light/low-medium.png?raw=true",
          "water": "Keep Evenly Moist",
          "notes": "Plant 1 Notes"
          },
      "room": {
          "id":  1,
          "roomName": "Kitchen", 
          "color": "Red"
              }
      },
      {
      "id": 2,
      "nickName": "Plant 2",
      "plant": {
          "id": 1,
          "name": "Pothos",
          "sun": "https://github.com/mcclaineabigail/PlantCatalog/blob/main/HousePlantz.Data/Images/light/low-medium.png?raw=true",
          "image": "https://github.com/mcclaineabigail/PlantCatalog/blob/main/HousePlantz.Data/Images/light/low-medium.png?raw=true",
          "water": "Keep Evenly Moist",
          "notes": "Plant 2 Notes"
          },
      "room": {
          "id":  1,
          "roomName": "Kitchen", 
          "color": "Red"
              }
      },
      {
      "id": 3,
      "nickName": "Plant 3",
      "plant": {
          "id": 1,
          "name": "Pothos",
          "sun": "https://github.com/mcclaineabigail/PlantCatalog/blob/main/HousePlantz.Data/Images/light/low-medium.png?raw=true",
          "image": "https://github.com/mcclaineabigail/PlantCatalog/blob/main/HousePlantz.Data/Images/light/low-medium.png?raw=true",
          "water": "Keep Evenly Moist",
          "notes": "Plant 3 Notes"
          },
      "room": {
          "id":  1,
          "roomName": "Kitchen", 
          "color": "Red"
              }
      }
  ]
  sub!: Subscription;
  errorMessage: string = '';

  constructor(private catalogService: CatalogService) { }

  ngOnInit(): void {
    // this.sub = this.catalogService.getPlants().subscribe({
    //   next: plantCatalog => this.plantCatalog = plantCatalog,
    //   error: err => this.errorMessage = err
    //})
  }

}
