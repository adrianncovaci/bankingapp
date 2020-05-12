import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BankaccountCardComponent } from './bankaccount-card/bankaccount-card.component';
import { BankaccountCreateComponent } from './bankaccount-create/bankaccount-create.component';
import { BankaccountDetailComponent } from './bankaccount-detail/bankaccount-detail.component';
import { BankaccountListComponent } from './bankaccount-list/bankaccount-list.component';
import { MaterialModule } from '../material/material.module';
import { ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from '../app-routing.module';



@NgModule({
  declarations: [
    BankaccountCardComponent,
    BankaccountCreateComponent,
    BankaccountDetailComponent,
    BankaccountListComponent,
  ],
  imports: [
    CommonModule,
    MaterialModule,
    ReactiveFormsModule,
    AppRoutingModule,
  ],
  providers: [
  ],
  exports: [
    BankaccountCardComponent,
    BankaccountCreateComponent,
    BankaccountDetailComponent,
    BankaccountListComponent,
  ]
})
export class BankAccountsModule { }
