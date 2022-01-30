import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { KeyboardComponent } from './keyboard/keyboard.component';
import { SwitchComponent } from './switch/switch.component';
import { DeskmatComponent } from './deskmat/deskmat.component';
import { KeycapComponent } from './keycap/keycap.component';
import { AccessoryComponent } from './accessory/accessory.component';
import { MerchComponent } from './merch/merch.component';
import { SpecialtyComponent } from './specialty/specialty.component';
import { ProfileComponent } from './profile/profile.component';
import { AdminComponent } from './admin/admin.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HomeComponent,
    KeyboardComponent,
    SwitchComponent,
    DeskmatComponent,
    KeycapComponent,
    AccessoryComponent,
    MerchComponent,
    SpecialtyComponent,
    ProfileComponent,
    AdminComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
