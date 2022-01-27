import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';

const routes: Routes = [
  {path:'', pathMatch: 'full', redirectTo: '/app-login'},
  {path:'login', component: LoginComponent},
  {path:'keyboard', component: LoginComponent},
  {path:'keycap', component: LoginComponent},
  {path:'deskmat', component: LoginComponent},
  {path:'switch', component: LoginComponent},
  {path:'accessory', component: LoginComponent},
  {path:'merch', component: LoginComponent},
  {path:'specialty', component: LoginComponent},
  {path:'profile', component: LoginComponent},
  {path:'admin', component: LoginComponent},
  {path:'**', component: LoginComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
