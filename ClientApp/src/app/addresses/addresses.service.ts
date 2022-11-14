import {Inject, Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {Address} from './address.model';

@Injectable({
  providedIn: 'root'
})
export class AddressesService {

  constructor(private http: HttpClient,
              @Inject('BASE_URL') private baseUrl: string) { }

  public getAddresses(): Observable<Address[]> {
    return this.http.get<Address[]>(`${this.baseUrl}api/addresses`);
  }
}
