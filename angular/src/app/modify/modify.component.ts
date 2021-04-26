import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { CatalogService } from '../catalog/catalog.service';
import { IOwnedPlant } from '../catalog/models/ownedPlant';

@Component({
  selector: 'hp-modify',
  templateUrl: './modify.component.html',
  styleUrls: ['./modify.component.scss'],
})
export class ModifyComponent implements OnInit {
  sub!: Subscription;
  catalog: IOwnedPlant[] = [];
  errorMessage: string = '';

  constructor(private catalogService: CatalogService) {}

  ngOnInit(): void {
    this.sub = this.catalogService.getCatalog().subscribe({
      next: catalog => this.catalog = catalog,
      error: err => this.errorMessage = err
    })
  }
}



