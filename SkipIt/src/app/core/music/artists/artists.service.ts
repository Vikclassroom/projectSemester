import { Injectable } from '@angular/core';
import {environment, environmentMusic} from '../../../../environments/environment';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import { map } from 'rxjs/operators';
import {ChartParams} from './chartParams';
import {BehaviorSubject} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ArtistsService {

  baseUrlMusic = environmentMusic.apiUrl;
  baseKeyMusic = environmentMusic.apiKey;
  baseUrl = environment.apiUrl;
  private chartSource = new BehaviorSubject<any>(null);
  chart$ = this.chartSource.asObservable();

  constructor(private http: HttpClient) { }

  // tslint:disable-next-line:typedef
  getChartList(){
    const header = new HttpHeaders({
      'X-RapidAPI-Key': this.baseKeyMusic,
      'X-RapidAPI-Host': 'shazam.p.rapidapi.com'
    });

    const option = {headers: header};
    return this.http.get(this.baseUrlMusic + 'charts/track', option);
  }
}
