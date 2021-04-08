import { Injectable } from '@angular/core';
import {environment} from '../../environments/environment';
import {HttpClient} from '@angular/common/http';
import {BehaviorSubject} from 'rxjs';
import {IAccount} from '../shared/models/account';
import {map} from 'rxjs/operators';
import {Router} from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = environment.apiUrl;
  private connectedAccountSource = new BehaviorSubject<IAccount>(null);
  connectedAccount$ = this.connectedAccountSource.asObservable();

  constructor(private http: HttpClient, private router: Router) { }

  // tslint:disable-next-line:typedef
  logout() {
    localStorage.removeItem('email');
    this.connectedAccountSource.next(null);
    this.router.navigateByUrl('/');
  }
}
