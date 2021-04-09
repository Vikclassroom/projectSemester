import { NgModule } from '@angular/core';
import { RouterModule, Routes} from '@angular/router';
import {UserPageComponent} from './user-page/user-page.component';
import {SignComponent} from './sign/sign.component';
import {AuthGuard} from '../core/Guard/auth.guard';

const routes: Routes = [
  {path: 'account/user', canActivate: [AuthGuard], component: UserPageComponent},
  {path: 'sign', component: SignComponent}
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class AccountRoutingModule { }
