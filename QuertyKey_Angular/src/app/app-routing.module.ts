import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {path:'', pathMatch: 'full', redirectTo: '/login'},
  {path:'/login', component: LoginComponent, canActivate: [AuthGuard]},
  {
    path:'Keyboards',
    canActivate: [KeyboardGuard],
    canload: [KeyboardGuard]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
