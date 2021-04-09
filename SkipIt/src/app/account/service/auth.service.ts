import {Injectable} from '@angular/core';
import {IAccount} from '../../shared/models/account';
import {Router} from '@angular/router';
import {HttpClient} from '@angular/common/http';
import {environment} from '../../../environments/environment';
import {map} from 'rxjs/operators';
import {ReplaySubject} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  public isAuth = false;
  public loginModel: IAccount;
  public baseUrl = environment.apiUrl;
  private currentUser: ReplaySubject<IAccount> = new ReplaySubject<IAccount>(null);
  currentUser$ = this.currentUser.asObservable();
  public id: number;

  constructor(private router: Router, private http: HttpClient) {
  }

  // tslint:disable-next-line:typedef
  login(values: any) {
    console.log(values);
    return this.http.post(this.baseUrl + 'api/account/login', values).pipe(
      map((user: IAccount) => {
        if (user) {
          console.log(user);
          localStorage.setItem('email', user.email);
          localStorage.setItem('urlPicture', user.urlPicture);
          localStorage.setItem('id', String(user.accountId));
          this.currentUser.next(user);
          console.log(user);
        }
      })
    );
  }

  // tslint:disable-next-line:typedef
  register(values: any) {
    return this.http.post(this.baseUrl + 'api/account', values).pipe(
      map((user: IAccount) => {
        if (user) {
          console.log(user);
          localStorage.setItem('email', user.email);
          localStorage.setItem('urlPicture', user.urlPicture);
          localStorage.setItem('id', String(user.accountId));
          this.currentUser.next(user);
          console.log(user);
        }
      })
    );
  }

  // tslint:disable-next-line:typedef
  logout() {
    localStorage.removeItem('email');
    localStorage.removeItem('urlPicture');
    localStorage.removeItem('id');
    this.currentUser.next(null);
    this.router.navigateByUrl('/');
  }

  // tslint:disable-next-line:typedef
  emailExist(email: string) {
    console.log('prout');
    return this.http.get(this.baseUrl + 'account/emailexist' + email);
  }

  // tslint:disable-next-line:typedef
  updateUser(values: any) {
    // tslint:disable-next-line:radix
    console.log('update');
    // tslint:disable-next-line:radix
    return this.http.put<IAccount>(this.baseUrl + 'account/' + parseInt(localStorage.getItem('id')), values);
  }

  // tslint:disable-next-line:typedef
  deleteAccount() {
    // tslint:disable-next-line:radix
    console.log('delete');
    // tslint:disable-next-line:radix
    this.http.delete(this.baseUrl + 'account/' + parseInt(localStorage.getItem('id')));
    return this.logout();
  }

  // tslint:disable-next-line:typedef
  updatePicture(values: any, idCurrentAccount: number) {
    console.log(values);
    return this.http.post(this.baseUrl + 'api/picture/upload/' + idCurrentAccount, values, {responseType: 'text'});
  }

  // tslint:disable-next-line:typedef
  downloadPicture(idAccount: number) {
    return this.http.get(this.baseUrl + 'api/picture/download/' + idAccount, {responseType: 'text'});
  }
}
