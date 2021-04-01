import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './core/home/home.component';
import { LoginComponent } from './account/login/login.component';
import { MusicComponent } from './core/music/music.component';
import { MyListComponent } from './core/my-list/my-list.component';
import { RegisterComponent } from './account/register/register.component';
import { AccountComponent } from './account/account.component';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'account', loadChildren: () => import('./account/account.module').then(mod => mod.AccountModule)},
  {path: 'music', component: MusicComponent},
  {path: 'myList', component: MyListComponent},
  {path: '**', redirectTo: '', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
