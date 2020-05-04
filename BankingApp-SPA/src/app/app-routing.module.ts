import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { AuthGuard } from './_guards/auth.guard';
import { BankaccountListComponent } from './bankaccount-list/bankaccount-list.component';
import { AccountListResolver } from './_resolvers/account-list.resolver';
import { AccountTypeResolver } from './_resolvers/account-type.resolver';
import { BankaccountCreateComponent } from './bankaccount-create/bankaccount-create.component';
import { BankaccountDetailComponent } from './bankaccount-detail/bankaccount-detail.component';

const routes: Routes = [
  // { path: '', component: HomeComponent, canActivate: [AuthGuard], 
  //      resolve: { bankAccounts: AccountListResolver, bankAccountTypes: AccountTypeResolver}},
  // { path: 'openaccount', component: BankaccountCreateComponent, canActivate: [AuthGuard]},
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      { 
        path: '', component: HomeComponent, 
        resolve: { bankAccounts: AccountListResolver, bankAccountTypes: AccountTypeResolver}
      },
      { 
        path: 'openaccount', component: BankaccountCreateComponent,
        resolve: { bankAccountTypes: AccountTypeResolver } 
      },
      {
        path: ':id', component: BankaccountDetailComponent
      },
      ]
  },
  { path: '**', redirectTo: 'login', pathMatch: 'full' }
];


@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
