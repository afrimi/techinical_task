import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { EmployeesComponent } from './employees/employees.component';
import {DxDataGridModule, DxLoadPanelModule} from 'devextreme-angular';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    EmployeesComponent
  ],
    imports: [
        DxDataGridModule,
        BrowserModule.withServerTransition({appId: 'ng-cli-universal'}),
        HttpClientModule,
        FormsModule,
        RouterModule.forRoot([
            {path: '', component: EmployeesComponent, pathMatch: 'full'},
        ]),
        DxLoadPanelModule
    ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
