import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { CatalogService } from './catalog.service';
import { IOwnedPlant } from './models/ownedPlant';
import { IPlant } from './models/plant';

@Component({
  selector: 'hp-catalog',
  templateUrl: './catalog.component.html',
  styleUrls: ['./catalog.component.scss']
})
export class CatalogComponent implements OnInit {
  catalog: IOwnedPlant[] = [];
  plants: IPlant[] = [];
  sub!: Subscription;
  errorMessage: string = '';
  toggleClass: boolean = false;

  constructor(private catalogService: CatalogService) { }

  ngOnInit(): void {
    this.sub = this.catalogService.getPlantList().subscribe({
      next: plants => this.plants = plants,
      error: err => this.errorMessage = err
    });
    this.sub = this.catalogService.getCatalog().subscribe({
      next: catalog => this.catalog = catalog,
      error: err => this.errorMessage = err
    });
  }

  flipCard(): void{
    this.toggleClass = !this.toggleClass;
  }
  getRoomAddress(): string{
    return ""
  }

}
