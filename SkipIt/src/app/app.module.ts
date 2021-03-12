import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';
import {HttpClientModule} from '@angular/common/http';

import {AppComponent} from './app.component';
import {LoginComponent} from './account/login/login.component';
import {RegisterComponent} from './account/register/register.component';
import {AccountPageComponent} from './account/account-page/account-page.component';
import {NavBarComponent} from './shared/nav-bar/nav-bar.component';
import {HomeComponent} from './home/home.component';
import {MusicComponent} from './music/music.component';
import {AppRoutingModule} from './app-routing.module';
import {NavMusicComponent} from './music/nav-music/nav-music.component';
import {ArtistsComponent} from './music/artists/artists.component';
import { MyListComponent } from './my-list/my-list.component';
import { NavMyListComponent } from './my-list/nav-my-list/nav-my-list.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    AccountPageComponent,
    NavBarComponent,
    HomeComponent,
    MusicComponent,
    NavMusicComponent,
    ArtistsComponent,
    MyListComponent,
    NavMyListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
}
