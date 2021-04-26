import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Subscription } from 'rxjs';
import { CatalogService } from './catalog.service';
import { IOwnedPlant } from './models/ownedPlant';

import { IPlant } from './models/plant';
import { IResponse } from './models/response';

@Component({
  selector: 'hp-catalog',
  templateUrl: './catalog.component.html',
  styleUrls: ['./catalog.component.scss'],
})
export class CatalogComponent implements OnInit {
  catalog: IOwnedPlant[] = [];
  plants: IPlant[] = [];
  sub!: Subscription;
  errorMessage: string = '';
  toggleClass: boolean = false;
  card: string = '';

  constructor(private catalogService: CatalogService) {}

  ngOnInit(): void {
    this.sub = this.catalogService.getPlantList().subscribe({
      next: plants => this.plants = plants,
      error: err => this.errorMessage = err,
    });
    this.sub = this.catalogService.getCatalog().subscribe({
      next: catalog => this.catalog = catalog,
      error: err => this.errorMessage = err,
    });
  }

  flipCard(): void {
    this.toggleClass = !this.toggleClass;
  }
  getRoomAddress(): string {
    return '';
  }

  addOwnedPlant(formValues: any): void {
    let newOwnedPlant: IOwnedPlant = <IOwnedPlant>formValues;
    newOwnedPlant.roomId = 16;

    this.catalogService.addPlantToCatalog(newOwnedPlant).subscribe(
      (data: IResponse<IOwnedPlant>) => {
        console.log(data);
        this.catalog.push(data.value);
      },
      (err: any) => console.log(err)
    );
  }

  deleteOwnedPlant(formValue: any): void {
    this.catalogService.deletePlant(formValue.id).subscribe(
      () => {
        let OPIndex = this.catalog.findIndex((OP) => OP.id === formValue.id);
        this.catalog.splice(OPIndex, 1);
      },
      (err: any) => console.log(err)
    );
  }
}
