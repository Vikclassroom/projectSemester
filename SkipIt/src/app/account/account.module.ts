import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {AccountRoutingModule} from './account-routing.module';
import {SharedModule} from '../shared/shared.module';
import { UserPageComponent } from './user-page/user-page.component';
import { SignComponent } from './sign/sign.component';



@NgModule({
  declarations: [
    UserPageComponent,
    SignComponent
  ],
  imports: [
    CommonModule,
    AccountRoutingModule,
    SharedModule
  ]
})
export class AccountModule { }
