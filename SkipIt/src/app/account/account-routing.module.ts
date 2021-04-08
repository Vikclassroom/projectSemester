import { NgModule } from '@angular/core';
import { RouterModule, Routes} from '@angular/router';
import {UserPageComponent} from './user-page/user-page.component';
import {SignComponent} from './sign/sign.component';

const routes: Routes = [
  {path: 'account/user', component: UserPageComponent},
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
