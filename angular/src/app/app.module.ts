import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { CatalogComponent } from './catalog/catalog.component';
import { RoomsComponent } from './rooms/rooms.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatIconModule } from '@angular/material/icon'

@NgModule({
  declarations: [
    AppComponent,
    CatalogComponent,
    RoomsComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    MatSlideToggleModule,
    MatCheckboxModule,
    ReactiveFormsModule,
    MatIconModule,
    RouterModule.forRoot([
      { path: 'rooms', component: RoomsComponent },
      { path: 'catalog', component: CatalogComponent },
      //{ path: 'display', component: DisplayComponent },
      { path: '', redirectTo: 'catalog', pathMatch: 'full' },
      { path: '*', redirectTo: 'catalog', pathMatch: 'full' },
    ]),
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
