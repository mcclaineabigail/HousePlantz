import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { CatalogComponent } from './catalog/catalog.component';
import { RoomsComponent } from './rooms/rooms.component';
import { DisplayComponent } from './display/display.component';

@NgModule({
  declarations: [
    AppComponent,
    CatalogComponent,
    RoomsComponent,
    DisplayComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot([
      { path: 'rooms', component: RoomsComponent },
      { path: 'catalog', component: CatalogComponent},
      { path: 'display', component: DisplayComponent},
      { path: '', redirectTo: 'catalog', pathMatch: 'full' },
      { path: '*', redirectTo: 'catalog', pathMatch: 'full' }
    ]),
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
