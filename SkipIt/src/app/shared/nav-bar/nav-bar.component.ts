import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../account/service/auth.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {
  public user: number;
  constructor(private service: AuthService) { }

  ngOnInit(): void {
  }

  // tslint:disable-next-line:typedef
  isLogged() {
    // tslint:disable-next-line:radix
    this.user = parseInt(localStorage.getItem('id'));
    if (this.user > 0) {
      return true;
    }
    return false;
  }

  // tslint:disable-next-line:typedef
  logout() {
    this.service.logout();
  }
}
