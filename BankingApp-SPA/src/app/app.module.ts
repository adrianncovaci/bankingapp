import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule} from '@angular/common/http';
import { NgModule } from '@angular/core';

import { LoginComponent } from './login/login.component';
import { AppComponent } from './app.component';
import { TransferComponent } from './transfer/transfer.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavbarComponent } from './navbar/navbar.component';
import { MaterialModule } from './material/material.module';

import { ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { FooterComponent } from './footer/footer.component';
import { AuthService } from './_services/auth.service';
import { RegisterComponent } from './register/register.component';
import { BankaccountListComponent } from './BankAccounts/bankaccount-list/bankaccount-list.component';
import { BankaccountCardComponent } from './BankAccounts/bankaccount-card/bankaccount-card.component';
import { HomeComponent } from './home/home.component';
import { JwtModule } from '@auth0/angular-jwt';
import { AccountListResolver } from './_resolvers/account-list.resolver';
import { AccountTypeResolver } from './_resolvers/account-type.resolver';
import { RouterModule } from '@angular/router';
import { BankaccountCreateComponent } from './BankAccounts/bankaccount-create/bankaccount-create.component';
import { BankaccountDetailComponent } from './BankAccounts/bankaccount-detail/bankaccount-detail.component';
import { TransactionListComponent } from './transaction-list/transaction-list.component';
import { LoanApplyComponent } from './loan-apply/loan-apply.component';
import { LoanRequestsListComponent } from './loan-requests-list/loan-requests-list.component';
import { LoanRequestsResolver } from './_resolvers/loan-requests.resolver';
import { ExchangeRateComponent } from './exchange-rate/exchange-rate.component';
import { ExchangeRateResolver } from './_resolvers/exchange-rate.resolver';

export function tokenGetter() {
  return localStorage.getItem('token');
}

@NgModule({
  declarations: [
    AppComponent,
    TransferComponent,
    NavbarComponent,
    LoginComponent,
    FooterComponent,
    RegisterComponent,
    BankaccountListComponent,
    BankaccountCardComponent,
    HomeComponent,
    BankaccountCreateComponent,
    BankaccountDetailComponent,
    TransactionListComponent,
    LoanApplyComponent,
    LoanRequestsListComponent,
    ExchangeRateComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    MaterialModule,
    AppRoutingModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        whitelistedDomains: ['localhost:5000'],
        blacklistedRoutes: ['localhost:5000/customers']
      }
    })
  ],
  providers: [
      AuthService,
      AccountListResolver,
      AccountTypeResolver,
      LoanRequestsResolver,
      ExchangeRateResolver,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
