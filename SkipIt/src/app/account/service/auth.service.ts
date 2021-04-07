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
  constructor(private router: Router, private http: HttpClient) {
  }

  // tslint:disable-next-line:typedef
  login(values: any) {
    return this.http.post(this.baseUrl + 'api/account', values).pipe(
      map((user: IAccount) => {
        if (user) {
          console.log(user);
          localStorage.setItem('email', user.email);
          localStorage.setItem('urlPicture', user.urlPicture);
          localStorage.setItem('id', String(user.accountId));
          this.currentUser.next(user);
        }
      })
    );
  }

  logout() {
    localStorage.removeItem('email');
    localStorage.removeItem('urlPicture');
    localStorage.removeItem('id');
    this.currentUser.next(null);
    this.router.navigateByUrl('/');
  }
}
