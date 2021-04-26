import {
  HttpClient,
  HttpErrorResponse,
  HttpHeaders,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { IOwnedPlant } from './models/ownedPlant';
import { IPlant } from './models/plant';
import { IResponse } from './models/response';

@Injectable({
  providedIn: 'root',
})
export class CatalogService {
  private getOwnedPlantUrl = 'https://localhost:44313/api/ownedplants';
  private getPlantUrl = 'https://localhost:44313/api/plants';
  constructor(private http: HttpClient) {}

  getCatalog(): Observable<IOwnedPlant[]> {
    return this.http.get<IOwnedPlant[]>(this.getOwnedPlantUrl);
    tap((data) => console.log('All', JSON.stringify(data))),
      catchError(this.handleError);
  }

  getPlantList(): Observable<IPlant[]> {
    return this.http.get<IPlant[]>(this.getPlantUrl);
    tap((data) => console.log('All', JSON.stringify(data))),
      catchError(this.handleError);
  }

  addPlantToCatalog(
    plantToAdd: IOwnedPlant
  ): Observable<IResponse<IOwnedPlant>> {
    return this.http.post<IResponse<IOwnedPlant>>(
      this.getOwnedPlantUrl,
      plantToAdd,
      {
        headers: new HttpHeaders({
          'Content-Type': 'application/json',
        }),
      }
    );
  }

  deletePlant(id: number): Observable<void> {
    return this.http.delete<void>(this.getOwnedPlantUrl + '/' + id);
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
} //MSSQL::/_localdb__MSSQLLocalDB/PlantCatalog/True/SqlView/dbo.DummyView.sql
