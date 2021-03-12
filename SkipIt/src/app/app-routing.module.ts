import { NgModule } from '@angular/core';
import {Routes, RouterModule} from '@angular/router';
import {HomeComponent} from './home/home.component';
import {LoginComponent} from './account/login/login.component';
import {AccountPageComponent} from './account/account-page/account-page.component';
import {MusicComponent} from './music/music.component';
import {MyListComponent} from './my-list/my-list.component';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'login', component: LoginComponent},
  {path: 'account', component: AccountPageComponent},
  {path: 'music', component: MusicComponent},
  {path: 'myList', component: MyListComponent},
  {path: '**', redirectTo: '', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
