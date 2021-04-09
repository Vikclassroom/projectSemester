import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { NavBarComponent } from './shared/nav-bar/nav-bar.component';
import { HomeComponent } from './core/home/home.component';
import { MusicComponent } from './core/music/music.component';
import { AppRoutingModule } from './app-routing.module';
import { ArtistsComponent } from './core/music/artists/artists.component';
import { MyListComponent } from './core/my-list/my-list.component';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { SharedComponent } from './shared/shared.component';
import { TrackComponent } from './core/music/track/track.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    HomeComponent,
    MusicComponent,
    ArtistsComponent,
    MyListComponent,
    SharedComponent,
    TrackComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    FontAwesomeModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
}
