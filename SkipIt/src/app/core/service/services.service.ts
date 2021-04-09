import {Injectable} from '@angular/core';
import {environment} from '../../../environments/environment';
import {ReplaySubject} from 'rxjs';
import {IAccount} from '../../shared/models/account';
import {IMusic} from '../../shared/models/music';
import {ILink} from '../../shared/models/link';
import {HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ServicesService {
  public baseUrl = environment.apiUrl;
  private music: ReplaySubject<IMusic> = new ReplaySubject<IMusic>(null);
  private link: ReplaySubject<ILink> = new ReplaySubject<ILink>(null);


  constructor(private http: HttpClient) {
  }

  // tslint:disable-next-line:typedef
  getMusic() {
    const idAccount = localStorage.getItem('id');
    return this.http.get(this.baseUrl + 'api/music/' + idAccount);
  }

  // tslint:disable-next-line:typedef
  createMusic(values: any) {
    // tslint:disable-next-line:radix
    return this.http.post(this.baseUrl + 'api/music/' + parseInt(localStorage.getItem('id')), values);
  }

  // tslint:disable-next-line:typedef
  deleteMusic(idMusic: number) {
    // tslint:disable-next-line:radix
    return this.http.delete(this.baseUrl + 'api/music/' + idMusic + '/' + parseInt(localStorage.getItem('id')));
  }
}
