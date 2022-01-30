import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AccessoryComponent } from './accessory/accessory.component';
import { AdminComponent } from './admin/admin.component';
import { DeskmatComponent } from './deskmat/deskmat.component';
import { HomeComponent } from './home/home.component';
import { KeyboardComponent } from './keyboard/keyboard.component';
import { KeycapComponent } from './keycap/keycap.component';
import { LoginComponent } from './login/login.component';
import { MerchComponent } from './merch/merch.component';
import { ProfileComponent } from './profile/profile.component';
import { SpecialtyComponent } from './specialty/specialty.component';
import { SwitchComponent } from './switch/switch.component';

const routes: Routes = [
  {path:'', component: HomeComponent},
  {path:'login', component: LoginComponent},
  {path:'keyboard', component: KeyboardComponent},
  {path:'keycap', component: KeycapComponent},
  {path:'deskmat', component: DeskmatComponent},
  {path:'switch', component: SwitchComponent},
  {path:'accessory', component: AccessoryComponent},
  {path:'merch', component: MerchComponent},
  {path:'specialty', component: SpecialtyComponent},
  {path:'profile', component: ProfileComponent},
  {path:'admin', component: AdminComponent},
  {path:'**', component: HomeComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
