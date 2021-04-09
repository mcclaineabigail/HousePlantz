import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { IOwnedPlant } from './models/ownedPlant';
import { IPlant } from './models/plant';

@Injectable({
  providedIn: 'root',
})
export class CatalogService {
   private catalogUrl = 'https://localhost:44313/api/ownedplants';
   private plantUrl = 'https://localhost:44313/api/plants'
    constructor(private http: HttpClient) {}


  getCatalog(): Observable<IOwnedPlant[]> {
      return this.http.get<IOwnedPlant[]>(this.catalogUrl);
      tap(data => console.log('All', JSON.stringify(data))),
      catchError(this.handleError)
  }

  getPlantList(): Observable<IPlant[]>{
    return this.http.get<IPlant[]>(this.plantUrl);
    tap(data => console.log('All', JSON.stringify(data))),
    catchError(this.handleError)
  }
  private handleError(err: HttpErrorResponse): Observable<never> {
      let errorMessage = '';
      if (err.error instanceof ErrorEvent) {
        errorMessage = `An error occurred: ${err.error.message}`;
      } else {
        errorMessage = `Server returned code: ${err.status}, error message is: ${err.message}`;
      }
      console.error(errorMessage);
      return throwError(errorMessage);
    }
}
