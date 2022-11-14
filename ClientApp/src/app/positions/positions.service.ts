import {Inject, Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {Position} from './position.model';

@Injectable({
  providedIn: 'root'
})
export class PositionsService {

  constructor(private http: HttpClient,
              @Inject('BASE_URL') private baseUrl: string) { }

  public getPositions(): Observable<Position[]> {
    return this.http.get<Position[]>(`${this.baseUrl}api/positions`);
  }
}
