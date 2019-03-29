import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Items } from '../Models/items';
import { catchError } from 'rxjs/operators';
import { throwError, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class OptionsService {
  myAppUrl = '';
  constructor(private _http: HttpClient, @Inject('BASE_URL')baseUrl: string) {
    this.myAppUrl = baseUrl;
}
 
private isNullOrUndefined(value: any): boolean {
  return value != null && value !== '' && value !== undefined ? true : false;
}

GetOptions(name: string): Observable<Object> {

  if (!this.isNullOrUndefined(name)){
    name = 'None';
  }
  const apiUrl: string = this.myAppUrl + 'api/options?name=' + name + '';
  return this._http.get(apiUrl).pipe(
    catchError((error: any) => this.errorHandler(error))
  );
}
  
errorHandler(errorResponse: any) {
  return throwError(errorResponse.error.messages);
}
}
