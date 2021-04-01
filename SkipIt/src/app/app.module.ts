import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { RegisterComponent } from './account/register/register.component';
import { NavBarComponent } from './shared/nav-bar/nav-bar.component';
import { HomeComponent } from './core/home/home.component';
import { MusicComponent } from './core/music/music.component';
import { AppRoutingModule } from './app-routing.module';
import { NavMusicComponent } from './core/music/nav-music/nav-music.component';
import { ArtistsComponent } from './core/music/artists/artists.component';
import { MyListComponent } from './core/my-list/my-list.component';
import { NavMyListComponent } from './core/my-list/nav-my-list/nav-my-list.component';
import { LoginComponent } from './account/login/login.component';
import { FormsModule } from '@angular/forms';
import { AccountComponent } from './account/account.component';

@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    HomeComponent,
    MusicComponent,
    NavMusicComponent,
    ArtistsComponent,
    MyListComponent,
    NavMyListComponent,
    AccountComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
}
