import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './core/home/home.component';
import { MusicComponent } from './core/music/music.component';
import { MyListComponent } from './core/my-list/my-list.component';
import {AuthGuard} from './core/Guard/auth.guard';
import {AccountRoutingModule} from './account/account-routing.module';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'accountChild', loadChildren: () => import('./account/account.module').then(mod => mod.AccountModule)},
  {path: 'music', component: MusicComponent},
  {path: 'myList', /*canActivate: [AuthGuard],*/ component: MyListComponent},
  {path: 'account', component: AccountRoutingModule},
  {path: '**', redirectTo: '', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
