import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { AuthGuard } from './_guards/auth.guard';

const routes: Routes = [
    { path: '', component: HomeComponent },
    // { path: '',
    //   runGuardsAndResolvers: 'always',
    //   canActivate: [AuthGuard],
    //   childern: [
    //       // { path: 'user:'}
    //   ]
    // },
    { path: 'login', component: LoginComponent },
    { path: 'register', component: RegisterComponent },
    { path: '**', redirectTo: '', pathMatch: 'full' }
];


@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
