import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Items } from '../Models/items';
import { catchError } from 'rxjs/operators';
import { throwError, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ItemService {
  myAppUrl = '';
  constructor(private _http: HttpClient, @Inject('BASE_URL')baseUrl: string) {
    this.myAppUrl = baseUrl;
}

 CreateItem(items: Items) {
  return this._http.post(this.myAppUrl + 'api/items', items).pipe(
    catchError((error: any) => this.errorHandler(error)));
}

errorHandler(errorResponse: any) {
  return throwError(errorResponse.error.messages);
}

}
