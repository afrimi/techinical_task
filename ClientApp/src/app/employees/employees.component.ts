import {Component, OnInit} from '@angular/core';
import {Change, EmployeesService} from './employees.service';
import {Employee} from './employee';
import {AddressesService} from '../addresses/addresses.service';
import {PositionsService} from '../positions/positions.service';
import {Observable} from 'rxjs';
import {Address} from '../addresses/address.model';
import {Position} from '../positions/position.model';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
})
export class EmployeesComponent implements OnInit {
  public isLoading = false;
  public changes: Change<Employee>[] = [];
  public editRowKey?: number | null = null;
  public employees$!: Observable<Employee[]>;

  public addresses$!: Observable<Address[]>;
  public positions$!: Observable<Position[]>;
  private currentRowData: Employee | {} = {};
  public loadPanelPosition = { of: '#gridContainer' };

  constructor(private employeesService: EmployeesService,
              private addressesService: AddressesService,
              private positionsService: PositionsService) {
  }

  public onEditorPreparing(e: any): void {
    this.currentRowData = e.row.data;
  }

  public onSaving(e: any): void {
    const [change] = e.changes;

    if (change) {
      e.cancel = true;
      change.data = {...this.currentRowData, ...change.data}
      e.promise = this.processSaving(change);
    }
  }

  async processSaving(change: Change<Employee>) {
    this.isLoading = true;

    try {
      await this.employeesService.saveChange(change);
      this.editRowKey = null;
      this.changes = [];
    } finally {
      this.isLoading = false;
    }
  }

  public ngOnInit(): void {
    this.employees$ = this.employeesService.getOrders();
    this.addresses$ = this.addressesService.getAddresses();
    this.positions$ = this.positionsService.getPositions();
  }

}
