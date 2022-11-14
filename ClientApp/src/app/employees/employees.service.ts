import {Inject, Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Employee} from './employee';
import {BehaviorSubject, lastValueFrom, Observable} from 'rxjs';
import applyChanges from 'devextreme/data/apply_changes';


export class Change<T> {
  type!: 'insert' | 'update' | 'remove';

  key: any;

  data!: T;
}

class Response<T> {
  data!: T[];
}

@Injectable({
  providedIn: 'root'
})
export class EmployeesService {
  private employees$ = new BehaviorSubject<Employee[]>([]);
  private readonly baseUrl: string;

  constructor(private http: HttpClient,
              @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = `${baseUrl}api/employees`;
  }

  public getEmployees(): Observable<Employee[]> {
    return this.http.get<Employee[]>(`${this.baseUrl}`);
  }

  updateEmployees(change: Change<Employee>, data: Employee) {
    change.data = data ?? {};
    const employees = applyChanges(this.employees$.getValue(), [change], { keyExpr: 'id' });
    console.log('employees after changed applied ', employees);
    this.employees$.next(employees);
  }

  getOrders(): Observable<Employee[]> {
    /*this.http.get<Employee[]>(`${this.baseUrl}api/employees`).subscribe(this.employees$.next)

    return this.employees$.asObservable();*/
    lastValueFrom(this.http.get(`${this.baseUrl}`))
      .then((data: any) => {
        console.log('data ', data);
        this.employees$.next(data);
      });

    return this.employees$.asObservable();
  }

  async insert(change: Change<Employee>): Promise<Employee> {
    const data = await lastValueFrom(this.http.post<Employee>(`${this.baseUrl}`, change.data));

    this.updateEmployees(change, data);

    return data;
  }

  async update(change: Change<Employee>): Promise<Employee> {
    const data = await lastValueFrom(this.http.put<Employee>(`${this.baseUrl}/${change.data.id}`, change.data));

    this.updateEmployees(change, change.data);

    return data;
  }

  async remove(change: Change<Employee>): Promise<Employee> {
    // const httpParams = new HttpParams({ fromObject: { key: change.key } });
    // const httpOptions = { withCredentials: true, body: httpParams };
    const data = await lastValueFrom(this.http.delete<Employee>(`${this.baseUrl}/${change.data.id}`));

    this.updateEmployees(change, data);

    return data;
  }

  async saveChange(change: Change<Employee>): Promise<Employee> {
    console.log('change ', change)
    switch (change.type) {
      case 'insert':
        return this.insert(change);
      case 'update':
        return this.update(change);
      case 'remove':
        return this.remove(change);
    }
  }
}
