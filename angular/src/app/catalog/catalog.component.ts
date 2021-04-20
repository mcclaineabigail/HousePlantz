import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Subscription } from 'rxjs';
import { CatalogService } from './catalog.service';
import { IOwnedPlant } from './models/ownedPlant';
import { IPlant } from './models/plant';

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
  @ViewChild('delete') deleteform: ElementRef;

  constructor(private catalogService: CatalogService) {}

  ngOnInit(): void {
    this.sub = this.catalogService.getPlantList().subscribe({
      next: (plants) => (this.plants = plants),
      error: (err) => (this.errorMessage = err),
    });
    this.sub = this.catalogService.getCatalog().subscribe({
      next: (catalog) => (this.catalog = catalog),
      error: (err) => (this.errorMessage = err),
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
    newOwnedPlant.roomId = 7;
    console.log(newOwnedPlant);

    this.catalogService.addPlantToCatalog(newOwnedPlant).subscribe(
      //(data: IOwnedPlant) => console.log(data),
      (err: any) => console.log(err)
    );
  }

  deleteOwnedPlant(formValues: number): void {
    var plantId = this.deleteform.nativeElement.value;
    this.catalogService
      .deletePlant(plantId)
      .subscribe((err: any) => console.log(err));
  }
}
