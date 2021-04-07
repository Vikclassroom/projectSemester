import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {AccountRoutingModule} from './account-routing.module';
import {SharedModule} from '../shared/shared.module';
import { AuthComponent } from './auth/auth.component';
import { UserPageComponent } from './user-page/user-page.component';



@NgModule({
  declarations: [
    AuthComponent,
    UserPageComponent
  ],
  imports: [
    CommonModule,
    AccountRoutingModule,
    SharedModule
  ]
})
export class AccountModule { }
