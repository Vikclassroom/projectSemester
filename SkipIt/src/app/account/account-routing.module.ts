import { NgModule } from '@angular/core';
import { RouterModule, Routes} from '@angular/router';
import {AuthComponent} from './auth/auth.component';
import {UserPageComponent} from './user-page/user-page.component';

const routes: Routes = [
  {path: 'auth', component: AuthComponent},
  {path: 'user', component: UserPageComponent}
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class AccountRoutingModule { }
